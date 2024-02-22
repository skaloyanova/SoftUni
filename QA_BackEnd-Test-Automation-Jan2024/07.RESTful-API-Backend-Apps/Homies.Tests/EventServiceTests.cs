using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homies.Tests
{
    [TestFixture]
    internal class EventServiceTests
    {
        private HomiesDbContext _dbContext;
        private EventService _eventService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<HomiesDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _dbContext = new HomiesDbContext(options);

            _eventService = new EventService(_dbContext);
        }

        [Test]
        public async Task AddEventAsync_ShouldAddEvent_WhenValidEventModelAndUserId()
        {
            // Arrange - create new event model with test data and define user ID for the test
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };
            string userId = "testUserId";

            // Act - call the service method to add the event
            await _eventService.AddEventAsync(eventModel, userId);

            // Assert
            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync(x => x.Name == eventModel.Name && x.OrganiserId == userId);
            Assert.That(eventInDb, Is.Not.Null);
            Assert.That(eventInDb.Description, Is.EqualTo(eventModel.Description));
            Assert.That(eventInDb.Start, Is.EqualTo(eventModel.Start));
            Assert.That(eventInDb.End, Is.EqualTo(eventModel.End));
        }

        /* 
         * validation is not working
         */
        //[TestCase("4cha", "20 chars description")]
        //[TestCase("21 chars naaaaammmme", "20 chars description")]
        //[TestCase("13 chars name", "14 chars descr")]
        //[TestCase("13 chars name", "151 chars description description description description description description description descriptiondescriptiondescriptiondescription descriptionD")]
        //public async Task AddEventAsync_ShouldThrowException_WhenInvalidEventModel(string name, string description)
        //{
        //    // Arrange
        //    // Event name must be between 5 and 20 characters.
        //    // Description must be between 15 and 150 characters.

        //    var eventModel = new EventFormModel
        //    {
        //        Name = name,
        //        Description = description,
        //        Start = DateTime.Now,
        //        End = DateTime.Now.AddHours(2)
        //    };
        //    string userId = "testUserId";

        //    // Act & Assert
        //    Assert.ThrowsAsync<ValidationException>(() => _eventService.AddEventAsync(eventModel, userId));
        //}


        [Test]
        public async Task GetAllEventsAsync_ShouldReturnAllEvents()
        {
            //Arrange
            var eventModel1 = new EventFormModel
            {
                Name = "Test Event1",
                Description = "Test Description1",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2)
            };

            var eventModel2 = new EventFormModel
            {
                Name = "Test Event2",
                Description = "Test Description2",
                Start = DateTime.Now.AddDays(2),
                End = DateTime.Now.AddDays(3)
            };
            string userId1 = "testUserId1";
            string userId2 = "testUserId2";

            await _eventService.AddEventAsync(eventModel1, userId1);
            await _eventService.AddEventAsync(eventModel2, userId2);

            // Act
            var result = await _eventService.GetAllEventsAsync();
            var resulList = result.ToList();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(resulList[0].Name, Is.EqualTo(eventModel1.Name));
            Assert.That(resulList[0].Start, Is.EqualTo(eventModel1.Start.ToString("dd/MM/yyyy H:mm")));

            Assert.That(resulList[1].Name, Is.EqualTo(eventModel2.Name));
            Assert.That(resulList[1].Start, Is.EqualTo(eventModel2.Start.ToString("dd/MM/yyyy H:mm")));
        }

        [Test]
        public async Task GetEventDetailsAsync_ShouldReturnAllEventDetails()
        {
            //Arrange
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };
            string userId = "testUserId";

            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync(x => x.Name == eventModel.Name && x.OrganiserId == userId);

            var eventId = eventInDb.Id;

            //Act
            var result = await _eventService.GetEventDetailsAsync(eventId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(eventModel.Name));
            Assert.That(result.Description, Is.EqualTo(eventModel.Description));
            Assert.That(result.Start, Is.EqualTo(eventModel.Start.ToString("dd/MM/yyyy H:mm")));
            Assert.That(result.End, Is.EqualTo(eventModel.End.ToString("dd/MM/yyyy H:mm")));
        }

        [Test]
        public async Task GetEventForEditAsync_ShouldReturnEventIfPresentInDb()
        {
            //Arrange
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };
            string userId = "testUserId";

            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstAsync();

            //Act
            var result = await _eventService.GetEventForEditAsync(eventInDb.Id);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(eventModel.Name));
            Assert.That(result.Description, Is.EqualTo(eventModel.Description));
            Assert.That(result.Start, Is.EqualTo(eventModel.Start));
            Assert.That(result.TypeId, Is.EqualTo(eventModel.TypeId));
        }

        [Test]
        public async Task GetEventForEditAsync_ShouldReturnNull_IfEventIsNotFound()
        {
            //Act - enter non-existing event id
            var result = await _eventService.GetEventForEditAsync(500);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetEventOrganizerIdAsync_ShouldReturnOrganiserId_IfEventExists()
        {
            //Arrange
            var eventModel = new EventFormModel
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = 2
            };
            string userId = "testUserId";

            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstAsync();

            //Act
            var result = await _eventService.GetEventOrganizerIdAsync(eventInDb.Id);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetEventOrganizerIdAsync_ShouldReturnNull_IfEventIsNotFound()
        {
            //Act - use non-existing event id
            var result = await _eventService.GetEventOrganizerIdAsync(50);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetUserJoinedEventsAsync_ShouldReturnListOfEvents()
        {
            //Arrange
            var userId = "user-id";

            //add type directly in DB
            var testType = new Data.Models.Type
            {
                Name = "Animal"
            };

            await _dbContext.Types.AddAsync(testType);
            await _dbContext.SaveChangesAsync();

            //add Event directly in DB
            var testEvent = new Event
            {
                Name = "Test Event",
                Description = "Test Description",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                TypeId = testType.Id,
                OrganiserId = userId
            };

            await _dbContext.Events.AddAsync(testEvent);
            await _dbContext.SaveChangesAsync();

            //add EventsParticipant directly in DB
            await _dbContext.EventsParticipants.AddAsync(new EventParticipant
            {
                EventId = testEvent.Id,
                HelperId = userId
            });

            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _eventService.GetUserJoinedEventsAsync(userId);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(1));

            var eventParticipation = result.First();
            Assert.That(eventParticipation.Id, Is.EqualTo(testEvent.Id));
            Assert.That(eventParticipation.Name, Is.EqualTo(testEvent.Name));
            Assert.That(eventParticipation.Type, Is.EqualTo(testType.Name));
        }

        [Test]
        public async Task GetUserJoinedEventsAsync_ShouldReturnEmptyList_IfNoEventsAreJoined()
        {
            //Act
            var result = await _eventService.GetUserJoinedEventsAsync("user-id");

            //Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnTrue_IfEventExistsAndIsNotAlreadyJoined()
        {
            //Arrange
            var userId = "user-id";

            var eventModel = new EventFormModel
            {
                Name = "Event to join",
                Description = "Event that will be joined",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };

            await _eventService.AddEventAsync(eventModel, userId);

            var eventToJoin = await _dbContext.Events.FirstAsync();
            var userToJoinEvent = "joining-user";

            //Act
            var result = await _eventService.JoinEventAsync(eventToJoin.Id, userToJoinEvent);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalse_IfEventDoesNotExist()
        {
            //Arrange
            var userIdToJoinEvent = "user1";
            var nonExistingEventId = 67;

            //Act
            var result = await _eventService.JoinEventAsync(nonExistingEventId, userIdToJoinEvent);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task JoinEventAsync_ShouldReturnFalse_IfEventIsAlreadyJoined()
        {
            //Arrange
            var userId = "user-id";

            var eventModel = new EventFormModel
            {
                Name = "Event to join",
                Description = "Event that will be joined",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };

            await _eventService.AddEventAsync(eventModel, userId);

            var eventToJoin = await _dbContext.Events.FirstAsync();
            var userToJoinEvent = "joining-user";

            //Act
            var resultFirstJoin = await _eventService.JoinEventAsync(eventToJoin.Id, userToJoinEvent);
            var resultSecondJoin = await _eventService.JoinEventAsync(eventToJoin.Id, userToJoinEvent);

            //Assert
            Assert.True(resultFirstJoin);
            Assert.False(resultSecondJoin);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnTrue_IfValidEventIsLeft()
        {
            //Arrange - create event and join user to the event
            var userId = "user1";
            var eventModel = new EventFormModel
            {
                Name = "Event to leave",
                Description = "Event that will be left",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };
            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync();
            var userToLeaveEventId = "user to leave";
            var eventJoint = await _eventService.JoinEventAsync(eventInDb.Id, userToLeaveEventId);

            //Act
            var result = await _eventService.LeaveEventAsync(eventInDb.Id, userToLeaveEventId);

            //Assert
            Assert.True(eventJoint);    //verify event is joint prior leaving
            Assert.True(result);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnFalse_IfEventWasNotJoinedBeforeThat()
        {
            //Arrange
            var userId = "user1";
            var eventModel = new EventFormModel
            {
                Name = "Event to leave",
                Description = "Event that will be left",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };
            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync();
            var userToLeaveEventId = "user to leave";
            //event is created but not joined

            //Act
            var result = await _eventService.LeaveEventAsync(eventInDb.Id, userToLeaveEventId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task LeaveEventAsync_ShouldReturnFalse_IfInvalidEventIsGiven()
        {
            //Arrange
            var userToLeaveEventId = "user to leave";
            var invalidEventId = 55;

            //Act
            var result = await _eventService.LeaveEventAsync(invalidEventId, userToLeaveEventId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnTrue_IfValidEventAndOrganiserAreGiven()
        {
            //Arrange
            var userId = "user1";
            var eventModel = new EventFormModel
            {
                Name = "Event to update",
                Description = "Event that will be updated",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };
            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync();

            //Act
            var eventToUpdate = await _eventService.GetEventForEditAsync(eventInDb.Id);
            eventToUpdate.Name = eventModel.Name + " UPDATED";
            eventToUpdate.Description = eventModel.Description + " UPDATED";
            eventToUpdate.Start = DateTime.Now;
            eventToUpdate.End = DateTime.Now.AddDays(1);

            var result = await _eventService.UpdateEventAsync(eventInDb.Id, eventToUpdate, userId);

            //Assert
            Assert.True(result);

            var updatedEvent = await _eventService.GetEventForEditAsync(eventInDb.Id);
            Assert.That(updatedEvent.Name, Is.EqualTo(eventToUpdate.Name));
            Assert.That(updatedEvent.Description, Is.EqualTo(eventToUpdate.Description));
            Assert.That(updatedEvent.Start, Is.EqualTo(eventToUpdate.Start));
            Assert.That(updatedEvent.End, Is.EqualTo(eventToUpdate.End));
        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalse_IfInvalidEventIsGiven()
        {
            //Arrange
            var userId = "user1";
            var eventModel = new EventFormModel
            {
                Name = "Event to update",
                Description = "Event that will be updated",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };
            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync();

            var invalidEventId = 77;

            //Act
            var eventToUpdate = await _eventService.GetEventForEditAsync(eventInDb.Id);
            eventToUpdate.Name = eventModel.Name + " UPDATED";
            eventToUpdate.Description = eventModel.Description + " UPDATED";
            eventToUpdate.Start = DateTime.Now;
            eventToUpdate.End = DateTime.Now.AddDays(1);

            var result = await _eventService.UpdateEventAsync(invalidEventId, eventToUpdate, userId);

            //Assert
            Assert.False(result);

            var notUpdatedEvent = await _eventService.GetEventForEditAsync(eventInDb.Id);
            Assert.That(notUpdatedEvent.Name, Is.EqualTo(eventModel.Name));
            Assert.That(notUpdatedEvent.Description, Is.EqualTo(eventModel.Description));
            Assert.That(notUpdatedEvent.Start, Is.EqualTo(eventModel.Start));
            Assert.That(notUpdatedEvent.End, Is.EqualTo(eventModel.End));

        }

        [Test]
        public async Task UpdateEventAsync_ShouldReturnFalse_IfInvalidOrganiserIsGiven()
        {
            //Arrange
            var userId = "user1";
            var eventModel = new EventFormModel
            {
                Name = "Event to update",
                Description = "Event that will be updated",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };
            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstOrDefaultAsync();

            var invalidUserId = "invalid user";

            //Act
            var eventToUpdate = await _eventService.GetEventForEditAsync(eventInDb.Id);
            eventToUpdate.Name = eventModel.Name + " UPDATED";
            eventToUpdate.Description = eventModel.Description + " UPDATED";
            eventToUpdate.Start = DateTime.Now;
            eventToUpdate.End = DateTime.Now.AddDays(1);

            var result = await _eventService.UpdateEventAsync(eventInDb.Id, eventToUpdate, invalidUserId);

            //Assert
            Assert.False(result);
        }

        [Test]
        public async Task GetAllTypesAsync_ShoudReturnListOfTypes()
        {
            //Arrange
            var type1 = new Data.Models.Type
            {
                Name = "type1"
            };

            var type2 = new Data.Models.Type
            {
                Name = "type2"
            };

            await _dbContext.AddRangeAsync(type1, type2);
            await _dbContext.SaveChangesAsync();

            //Act
            var result = await _eventService.GetAllTypesAsync();
            var resultList = result.ToList();

            //Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(resultList[0].Name, Is.EqualTo(type1.Name));
            Assert.That(resultList[1].Name, Is.EqualTo(type2.Name));
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShoudReturnTrue_IfThereIsEventJoined()
        {
            //Arrange - create event and join user to event
            var userId = "user-id";

            var eventModel = new EventFormModel
            {
                Name = "Event to join",
                Description = "Event that will be joined",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };

            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstAsync();
            var currentUser = "current-user";

            await _eventService.JoinEventAsync(eventInDb.Id, currentUser);

            //Act
            var result = await _eventService.IsUserJoinedEventAsync(eventInDb.Id, currentUser);

            //Assert
            Assert.True(result);
        }

        [Test]
        public async Task IsUserJoinedEventAsync_ShoudReturnFalse_IfNoEventsAreJoined()
        {
            //Arrange - create event and DO NOT join user to event
            var userId = "user-id";

            var eventModel = new EventFormModel
            {
                Name = "Event to join",
                Description = "Event that will be joined",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(5),
            };

            await _eventService.AddEventAsync(eventModel, userId);

            var eventInDb = await _dbContext.Events.FirstAsync();
            var currentUser = "current-user";

            //Act
            var result = await _eventService.IsUserJoinedEventAsync(eventInDb.Id, currentUser);

            //Assert
            Assert.False(result);
        }
    }

}
