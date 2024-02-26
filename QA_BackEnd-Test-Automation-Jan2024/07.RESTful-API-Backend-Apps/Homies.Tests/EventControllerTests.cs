using NUnit.Framework;
using Moq;
using Homies.Controllers;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace Homies.Tests
{
    [TestFixture]
    public class EventControllerTests
    {
        private Mock<IEventService> _mockEventService;
        private EventController _controller;

        [SetUp]
        public void Setup()
        {
            _mockEventService = new Mock<IEventService>();

            var user = new ClaimsPrincipal(new GenericPrincipal(new GenericIdentity("User"), null));
            _controller = new EventController(_mockEventService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };
        }

        [Test]
        public async Task Add_ReturnsViewResult()
        {
            // Act
            var result = await _controller.Add();

            // Assert
            //assert that the result is of the expected type
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Join_UserNotJoined_ReturnsRedirectToActionResult()
        {
            // Arrange
            //define ID of the event to be used in the test
            int eventId = 1;

            //setup the mock behaviour for the event service
            //assume the user is not already joined to the event
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(false);

            //setup the mock behaviour for joining the event
            //assume joining the event is successful
            _mockEventService.Setup(s => s.JoinEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(true);

            // Act
            //call the controller method to join the event
            var result = await _controller.Join(eventId);

            // Assert
            //assert that the result returned is of the expected type
            Assert.IsInstanceOf<RedirectToActionResult>(result);

            //convert the result to RedirectToActionResult for further assertions
            var redirectResult = result as RedirectToActionResult;

            //assert that the action name and controller name in the redirect result are as expected
            Assert.AreEqual("Joined", redirectResult.ActionName);
            Assert.AreEqual("Event", redirectResult.ControllerName);
        }

        [Test]
        public async Task Join_UserAlreadyJoined_ReturnsRedirectToActionResult()
        {
            // Arrange
            //define ID of the event to be used in the test
            int eventId = 1;

            //setup the mock behaviour for the event service
            //assume the user is already joined to the event
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>()))
                             .ReturnsAsync(true);

            // Act
            //call the controller method to join the event
            var result = await _controller.Join(eventId);

            // Assert
            //assert that the result returned is of the expected type
            Assert.IsInstanceOf<RedirectToActionResult>(result);

            //convert the result to RedirectToActionResult for further assertions
            var redirectResult = result as RedirectToActionResult;

            //assert that the action name and controller name in the redirect result are as expected
            Assert.AreEqual("Joined", redirectResult.ActionName);
            Assert.AreEqual("Event", redirectResult.ControllerName);
        }
    }
}
