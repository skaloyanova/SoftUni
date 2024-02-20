using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        // Field to hold the mock repository and the service being tested
        private ItemService _itemService;
        private Mock<IItemRepository> _mockItemRepository;


        [SetUp]
        public void Setup()
        {
            // Arrange: Create a mock instance of IItemRepository
            _mockItemRepository = new Mock<IItemRepository>();

            // Instantiate ItemService with the mocked repository
            _itemService = new ItemService(_mockItemRepository.Object);
        }

        [Test]
        public void AddItem_ShouldCallAddItemOnRepository()
        {
            // Act: Call AddItem on the service
            _itemService.AddItem(It.IsAny<string>());

            // Assert: Verify that AddItem was called on the repository
            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once);
        }

        [Test]
        public void AddItem_ShouldThrowException_IfNameIsInvalid()
        {
            //Arrange
            var invalidItemName = "";
            _mockItemRepository.Setup(x => x.AddItem(It.IsAny<Item>())).Throws<ArgumentException>();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _itemService.AddItem(invalidItemName));
            _mockItemRepository.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Once);
        }

        [Test]
        public void GetAllItems_ShouldReturnAllItems()
        {
            //Arrange
            var items = new List<Item> { new Item { Id = 1, Name = "Some item" } };
            _mockItemRepository.Setup(x => x.GetAllItems()).Returns(items);

            //Act
            var result = _itemService.GetAllItems();

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));
            CollectionAssert.AreEqual(items, result);
            _mockItemRepository.Verify(x => x.GetAllItems(), Times.Once);
        }

        [Test]
        public void GetItemById_ShouldReturnItemById_IfItemExist()
        {
            //Arrange
            var item = new Item { Id = 1, Name = "returned" };
            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);

            //Act
            var result = _itemService.GetItemById(item.Id);

            //Assert
            Assert.NotNull(result);
            Assert.That(result.Name, Is.EqualTo(item.Name));
            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once);
        }

        [Test]
        public void GetItemById_ShouldReturnNull_IfItemDoesNotExist()
        {
            //Arrange
            _mockItemRepository.Setup(x => x.GetItemById(It.IsAny<int>())).Returns<Item>(null);

            //Act
            var result = _itemService.GetItemById(It.IsAny<int>());

            //Assert
            Assert.IsNull(result);
            _mockItemRepository.Verify(x => x.GetItemById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void UpdateItem_ShouldCallUpdateItemOnRepository()
        {
            //Arrange
            var item = new Item { Id = 5, Name = "initial" };
            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));

            //Act
            _itemService.UpdateItem(item.Id, "updated");

            //Assert
            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once);
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);

        }

        [Test]
        public void UpdateItem_ShouldNotUpdateItem_IfItemDoesNotExist()
        {
            //Arrange
            var nonExistingId = 1;
            _mockItemRepository.Setup(x => x.GetItemById(nonExistingId)).Returns<Item>(null);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>()));

            //Act
            _itemService.UpdateItem(nonExistingId, "anything");

            //Assert
            _mockItemRepository.Verify(x => x.GetItemById(nonExistingId), Times.Once);
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Never);

        }

        [Test]
        public void UpdateItem_ShouldThrowException_IfItemNameIsInvalid()
        {
            //Arrange
            var item = new Item { Id = 1, Name = "some name" };

            _mockItemRepository.Setup(x => x.GetItemById(item.Id)).Returns(item);
            _mockItemRepository.Setup(x => x.UpdateItem(It.IsAny<Item>())).Throws<ArgumentException>();

            //Act and Assert
            Assert.Throws<ArgumentException>(() => _itemService.UpdateItem(item.Id, ""));

            _mockItemRepository.Verify(x => x.GetItemById(item.Id), Times.Once);
            _mockItemRepository.Verify(x => x.UpdateItem(It.IsAny<Item>()), Times.Once);
        }

        [Test]
        public void DeleteItem_ShouldCallDeleteItemOnRepository()
        {
            //Arrange
            int id = 5;
            //_mockItemRepository.Setup(x => x.DeleteItem(id));

            //Act
            _itemService.DeleteItem(id);

            //Assert
            _mockItemRepository.Verify(x => x.DeleteItem(id), Times.Once);

        }

        [Test]
        public void ValidateItemName_WhenNameIsValid_ShouldReturnTrue()
        {
            //Arrange
            var validName = "item name";

            //Act
            var result = _itemService.ValidateItemName(validName);

            //Assert
            Assert.True(result);
        }

        [Test]
        public void ValidateItemName_WhenNameIsTooLong_ShouldReturnFalse()
        {
            //Arrange
            var invalidName = "nameWith11c";

            //Act
            var result = _itemService.ValidateItemName(invalidName);

            //Assert
            Assert.False(result);
        }

        [TestCase("")]
        //[TestCase("  ")]
        [TestCase(null)]
        public void ValidateItemName_WhenNameIsEmpty_ShouldReturnFalse(string invalidName)
        {
            //Act
            var result = _itemService.ValidateItemName(invalidName);

            //Assert
            Assert.False(result);
        }

        //Alternative for validation tests
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("looooooonnnnggggg", false)]
        [TestCase("A", true)]
        [TestCase("some item", true)]
        public void ValidateItemName_ShouldReturnCorrectValidation(string name, bool isValid)
        {
            //Act
            var result = _itemService.ValidateItemName(name);

            //Assert
            Assert.That(result, Is.EqualTo(isValid));
        }
    }
}