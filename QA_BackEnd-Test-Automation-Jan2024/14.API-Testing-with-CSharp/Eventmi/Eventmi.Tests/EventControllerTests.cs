using Eventmi.Core.Models.Event;
using Eventmi.Infrastructure.Data.Contexts;
using Eventmi.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Net;

namespace Eventmi.Tests
{
    public class EventControllerTests
    {
        private RestClient _client;
        private readonly string _baseURL = "https://localhost:7236";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseURL);
        }

        [Test]
        public async Task GetAllEvents_ReturnSuccessStatusCode()
        {
            //Arrange
            var request = new RestRequest("/Event/All");

            //Act
            var response = await _client.GetAsync(request);

            //Assert
            Console.WriteLine("status code: " + response.StatusCode);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_GetRequest_ReturnsAddView()
        {
            //Arrange
            var request = new RestRequest("/Event/Add", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Console.WriteLine("status code: " + response.StatusCode);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_AddsEvent()
        {
            //Arrange
            var input = new EventFormModel()
            {
                Name = "Test event via http post",
                Start = new DateTime(2024, 04, 05, 18, 0, 0, 0),
                End = new DateTime(2024, 04, 05, 22, 0, 0, 0),
                Place = "some place"
            };

            var request = new RestRequest("/Event/Add", Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End);
            request.AddParameter("Place", input.Place);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Console.WriteLine(input.Name);
            Assert.IsTrue(Helper.CheckEventExists(input.Name));
        }

        //[Test]
        //public async Task Add_PostRequest_InvalidModel_DoesNotAddsEvent()
        //{
        //    //Arrange
        //    var input = new EventFormModel()
        //    {
        //        Name = "Invalid event",
        //        End = new DateTime(2024, 04, 05, 22, 0, 0, 0),
        //        Place = "some place"
        //    };

        //    var request = new RestRequest("/Event/Add", Method.Post);

        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        //    request.AddParameter("Name", input.Name);
        //    //request.AddParameter("Start", input.Start);
        //    //request.AddParameter("End", input.End);
        //    request.AddParameter("Place", input.Place);

        //    //Act
        //    var response = await _client.ExecuteAsync(request);

        //    //Assert
        //    Console.WriteLine(response.StatusCode);
        //    Console.WriteLine(input.Name);
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        //    Assert.IsTrue(Helper.CheckEventExists(input.Name));
        //}

        [Test]
        public async Task Details_GetRequest_ValidId_ReturnsDetailsView()
        {
            //Arrange
            int eventId = 1;
            var request = new RestRequest($"/Event/Details/{eventId}", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Details_GetRequest_MissingId_ReturnsNotFound()
        {
            //Arrange
            var request = new RestRequest($"/Event/Details/", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Console.WriteLine(response.StatusCode);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Edit_GetRequest_ValidId_ReturnsEditView()
        {
            //Arrange
            int eventId = 1;
            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Edit_GetRequest_MissingId_ReturnsNotFound()
        {
            //Arrange
            var request = new RestRequest($"/Event/Edit/", Method.Get);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Edit_PostRequest_ValidId_EditEventSucessfully()
        {
            //Arrange
            int eventId = 21;

            var eventFromDb = await Helper.GetEventByIdAsync(eventId);

            var input = new EventFormModel
            {
                Name = eventFromDb.Name,
                Start = eventFromDb.Start,
                End = eventFromDb.End,
                Place = eventFromDb.Place
            };

            string updatedName = "Updated name";
            input.Name = updatedName;

            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start);
            request.AddParameter("End", input.End);
            request.AddParameter("Place", input.Place);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.True(Helper.CheckEventExists(updatedName));
        }

        [Test]
        public async Task Edit_PostRequest_WithIdMismatch_ReturnsNotFound()
        {
            //Arrange
            int urlEventId = 1;

            var eventFromDb = await Helper.GetEventByIdAsync(urlEventId);

            var input = new EventFormModel
            {
                Id = eventFromDb.Id,
                Name = eventFromDb.Name,
                Start = eventFromDb.Start,
                End = eventFromDb.End,
                Place = eventFromDb.Place
            };

            input.Id = 1000;
            input.Name = input.Name + " updated";

            var request = new RestRequest($"/Event/Edit/{urlEventId}", Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Id", input.Id);
            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start);
            request.AddParameter("End", input.End);
            request.AddParameter("Place", input.Place);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Console.WriteLine(response.StatusCode);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.IsFalse(Helper.CheckEventExists(input.Name));
        }

        [Test]
        public async Task Edit_PostRequest_InvalidModel_ReturnsSameEditView()
        {
            //Arrange
            int eventId = 22;

            var input = new EventFormModel
            {
                Id = eventId,
                Name = "Invalid place edit for event 22",
                Start = new DateTime(2024, 04, 07, 18, 0, 0, 0),
                Place = ""
            };

            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Post);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Id", input.Id);
            request.AddParameter("Name", input.Name);
            request.AddParameter("Start", input.Start);
            request.AddParameter("End", input.End);
            request.AddParameter("Place", input.Place);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsFalse(Helper.CheckEventExists(input.Name));

        }

        [Test]
        public async Task Delete_PostRequest_ShouldDeleteEvent()
        {
            //Arrange
            //Create event to delete later
            var input = new EventFormModel
            {
                Name = "Event to delete",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
                Place = "virtual"
            };

            var requestAddEvent = new RestRequest("/Event/Add", Method.Post);

            requestAddEvent.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            requestAddEvent.AddParameter("Name", input.Name);
            requestAddEvent.AddParameter("Start", input.Start);
            requestAddEvent.AddParameter("End", input.End);
            requestAddEvent.AddParameter("Place", input.Place);

            var responseAddEvent = await _client.ExecuteAsync(requestAddEvent);

            Assert.That(responseAddEvent.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.IsTrue(Helper.CheckEventExists(input.Name), "Event should exists, in order to be deleted later");

            //Arrange deletion
            var eventFromDb = await Helper.GetEventByNameAsync(input.Name);
            var request = new RestRequest($"/Event/Delete/{eventFromDb.Id}", Method.Post);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            var deletedEventInDb = await Helper.GetEventByNameAsync(input.Name);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                //Assert.IsNull(deletedEventInDb);
                Assert.IsFalse(Helper.CheckEventExists(input.Name));
            });
        }

        [Test]
        public async Task Delete_PostRequest_MissingId_RetunsNotFound()
        {
            //Arrange
            var request = new RestRequest("/Event/Delete/", Method.Post);

            //Act
            var response = await _client.ExecuteAsync(request);

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}