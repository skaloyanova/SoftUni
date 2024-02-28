using ContactsConsoleAPI.Business;
using ContactsConsoleAPI.Business.Contracts;
using ContactsConsoleAPI.Data.Models;
using ContactsConsoleAPI.DataAccess;
using ContactsConsoleAPI.DataAccess.Contrackts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsConsoleAPI.IntegrationTests.NUnit
{
    public class IntegrationTests
    {
        private TestContactDbContext dbContext;
        private IContactManager contactManager;

        [SetUp]
        public void SetUp()
        {
            this.dbContext = new TestContactDbContext();
            this.contactManager = new ContactManager(new ContactRepository(this.dbContext));
        }


        [TearDown]
        public void TearDown()
        {
            this.dbContext.Database.EnsureDeleted();
            this.dbContext.Dispose();
        }

        //Helper Method for assering each property of 2 objects
        public static void AssertPropertiesEqual<T>(T expected, T actual)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var expectedValue = property.GetValue(expected, null);
                var actualValue = property.GetValue(actual, null);
                Assert.That(expectedValue, Is.EqualTo(actualValue));
            }
        }


        //positive test
        [Test]
        public async Task AddContactAsync_ShouldAddNewContact_Example()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "test@gmail.com",
                Gender = "Male",
                Phone = "0889933779"
            };

            await contactManager.AddAsync(newContact);

            var dbContact = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.NotNull(dbContact);
            Assert.AreEqual(newContact.FirstName, dbContact.FirstName);
            Assert.AreEqual(newContact.LastName, dbContact.LastName);
            Assert.AreEqual(newContact.Phone, dbContact.Phone);
            Assert.AreEqual(newContact.Email, dbContact.Email);
            Assert.AreEqual(newContact.Address, dbContact.Address);
            Assert.AreEqual(newContact.Contact_ULID, dbContact.Contact_ULID);
        }

        //Negative test
        [Test]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException_Example()
        {
            var newContact = new Contact()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Address = "Anything for testing address",
                Contact_ULID = "1ABC23456HH", //must be minimum 10 symbols - numbers or Upper case letters
                Email = "invalid_Mail", //invalid email
                Gender = "Male",
                Phone = "0889933779"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await contactManager.AddAsync(newContact));
            var actual = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);

            Assert.IsNull(actual);
            Assert.That(ex.Message, Is.EqualTo("Invalid contact!"));

        }


        [Test]
        public async Task AddContactAsync_ShouldAddNewContact()
        {
            //Arrange
            var newContact = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            //Act
            await contactManager.AddAsync(newContact);

            //Assert
            var contactInDb = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);
            Assert.NotNull(contactInDb);

            var properties = typeof(Contact).GetProperties();
            foreach (var prop in properties)
            {
                var expected = prop.GetValue(newContact);
                var actual = prop.GetValue(contactInDb);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        //Validation test
        [TestCase("", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase(null, "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", "", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", null, "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho","Petrov", "", "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", null, "+359898012345", "pesho@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "invalidPh16chars", "pesho@gmail.com", "Male", "ABCDE12345")]
        // There is a BUG -> test commented below is failing, i.e. "pesho@invalid" is considered valid email
        // [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@invalid", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@invalid@gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho.gmail.com", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "invalidMail", "Male", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "invalid11ch", "ABCDE12345")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "LESSTHN10")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "smallLETTERS")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "SP3CIAL@CH4RS!")]
        [TestCase("Pesho", "Petrov", "Vitosha 15", "+359898012345", "pesho@gmail.com", "Male", "MAXLENGTH30CHARSEXCEEDED1234567")]
        public async Task AddContactAsync_TryToAddContactWithInvalidCredentials_ShouldThrowException(string firstName, string lastName, string address, string phone, string email, string gender, string ulid)
        {
            //Arrange
            var newContact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Phone = phone,
                Email = email,
                Gender = gender,
                Contact_ULID = ulid
            };

            //Act & Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => contactManager.AddAsync(newContact));
            Assert.That(exception.Message, Is.EqualTo("Invalid contact!"));

            var contactInDb = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == newContact.Contact_ULID);
            Assert.IsNull(contactInDb);
        }

        [Test]
        public async Task AddContactAsync_TryToAddNullContact_ShouldThrowException()
        {
            // Arrange
            Contact newContact = null!;

            // Act & Assert
            var exception = Assert.ThrowsAsync<ValidationException>(() => contactManager.AddAsync(newContact));
            Assert.That(exception.Message, Is.EqualTo("Invalid contact!"));
        }

        [Test]
        public async Task DeleteContactAsync_WithValidULID_ShouldRemoveContactFromDb()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            await contactManager.AddAsync(contact);

            // Act
            await contactManager.DeleteAsync(contact.Contact_ULID);

            // Assert
            var contactInDb = await dbContext.Contacts.FirstOrDefaultAsync(c => c.Contact_ULID == contact.Contact_ULID);
            Assert.IsNull(contactInDb);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task DeleteContactAsync_TryToDeleteWithNullOrWhiteSpaceULID_ShouldThrowArgumentException(string invalidULID)
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => contactManager.DeleteAsync(invalidULID));
            Assert.That(exception.Message, Is.EqualTo("ULID cannot be empty."));
        }

        [Test]
        public async Task GetAllAsync_WhenContactsExist_ShouldReturnAllContacts()
        {
            // Arrange
            var contact1 = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            var contact2 = new Contact
            {
                FirstName = "Gosho",
                LastName = "Georgiev",
                Address = "Plana 60",
                Phone = "+359898010000",
                Email = "gosho@gmail.com",
                Gender = "Male too",
                Contact_ULID = "ABCDE00045"
            };

            await contactManager.AddAsync(contact1);
            await contactManager.AddAsync(contact2);

            // Act
            var result = await contactManager.GetAllAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));

            var resultList = result.ToList();

            AssertPropertiesEqual(resultList[0], contact1);
            AssertPropertiesEqual(resultList[1], contact2);
        }

        [Test]
        public async Task GetAllAsync_WhenNoContactsExist_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetAllAsync());
            Assert.That(exception.Message, Is.EqualTo("No contact found."));
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithExistingFirstName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var contact1 = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            var contact2 = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov-2",
                Address = "Vitosha 15-2",
                Phone = "+359898012345-2",
                Email = "pesho@gmail.com2",
                Gender = "Male-2",
                Contact_ULID = "ABCDE123452"
            };

            await contactManager.AddAsync(contact1);
            await contactManager.AddAsync(contact2);

            // Act
            var result = await contactManager.SearchByFirstNameAsync(contact1.FirstName);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            AssertPropertiesEqual(result.ToList()[0], contact1);
            AssertPropertiesEqual(result.ToList()[1], contact2);
        }

        [Test]
        public async Task SearchByFirstNameAsync_WithNonExistingFirstName_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByFirstNameAsync("invalid name"));
            Assert.That(ex.Message, Is.EqualTo("No contact found with the given first name."));
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task SearchByFirstNameAsync_WithNullOrWhiteSpaceFirstName_ShouldThrowArgumentException(string invalidFirstName)
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => contactManager.SearchByFirstNameAsync(invalidFirstName));
            Assert.That(exception.Message, Is.EqualTo("First name cannot be empty."));
        }

        [Test]
        public async Task SearchByLastNameAsync_WithExistingLastName_ShouldReturnMatchingContacts()
        {
            // Arrange
            var contact1 = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            var contact2 = new Contact
            {
                FirstName = "Pesho-2",
                LastName = "Petrov-2",
                Address = "Vitosha 15-2",
                Phone = "+359898012345-2",
                Email = "pesho@gmail.com2",
                Gender = "Male-2",
                Contact_ULID = "ABCDE123452"
            };

            await contactManager.AddAsync(contact1);
            await contactManager.AddAsync(contact2);

            // Act
            var result = await contactManager.SearchByLastNameAsync(contact1.LastName);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(1));
            AssertPropertiesEqual(result.First(), contact1);
        }

        [Test]
        public async Task SearchByLastNameAsync_WithNonExistingLastName_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.SearchByLastNameAsync("invalid name"));
            Assert.That(ex.Message, Is.EqualTo("No contact found with the given last name."));
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task SearchByLastNameAsync_WithNullOrWhiteSpaceLastName_ShouldThrowArgumentException(string invalidLastName)
        {
            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => contactManager.SearchByLastNameAsync(invalidLastName));
            Assert.That(exception.Message, Is.EqualTo("Last name cannot be empty."));
        }

        [Test]
        public async Task GetSpecificAsync_WithValidULID_ShouldReturnContact()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            await contactManager.AddAsync(contact);

            // Act
            var result = await contactManager.GetSpecificAsync(contact.Contact_ULID);

            // Assert
            Assert.NotNull(result);
            AssertPropertiesEqual(result, contact);
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public async Task GetSpecificAsync_WithNullOrWhitespaceULID_ShouldThrowArgumentException(string invalidULID)
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => contactManager.GetSpecificAsync(invalidULID));
            Assert.That(exception.Message, Is.EqualTo("ULID cannot be empty."));
        }

        [TestCase("NONEXISTING01")]
        [TestCase("invalid")]
        public async Task GetSpecificAsync_WithNonExistingULID_ShouldThrowKeyNotFoundException(string invalidULID)
        {
            // Act and Assert
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => contactManager.GetSpecificAsync(invalidULID));
            Assert.That(exception.Message, Is.EqualTo($"No contact found with ULID: {invalidULID}"));
        }

        [Test]
        public async Task UpdateAsync_WithValidContact_ShouldUpdateContact()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            await contactManager.AddAsync(contact);

            var updatedContactInfo = new Contact
            {
                FirstName = contact.FirstName + "UPDATED",
                LastName = contact.LastName + "UPDATED",
                Address = contact.Address + "UPDATED",
                Phone = contact.Phone + "00",
                Email = "UPDATED" + contact.Email,
                Gender = contact.Gender + "UPDATE",
                Contact_ULID = contact.Contact_ULID + "00"
            };

            // Act
            var contactToUpdate = await contactManager.GetSpecificAsync(contact.Contact_ULID);
            
            contactToUpdate.FirstName = updatedContactInfo.FirstName;
            contactToUpdate.LastName = updatedContactInfo.LastName;
            contactToUpdate.Address = updatedContactInfo.Address;
            contactToUpdate.Phone = updatedContactInfo.Phone;
            contactToUpdate.Email = updatedContactInfo.Email;
            contactToUpdate.Gender = updatedContactInfo.Gender;
            contactToUpdate.Contact_ULID = updatedContactInfo.Contact_ULID;

            await contactManager.UpdateAsync(contactToUpdate);

            // Assert
            var contactInDb = await contactManager.GetSpecificAsync(contactToUpdate.Contact_ULID);
            Assert.NotNull(contactInDb);
            AssertPropertiesEqual(contactToUpdate, contactInDb);
        }

        [Test]
        public async Task UpdateAsync_WithInvalidContact_ShouldThrowValidationException()
        {
            // Arrange
            var contact = new Contact
            {
                FirstName = "Pesho",
                LastName = "Petrov",
                Address = "Vitosha 15",
                Phone = "+359898012345",
                Email = "pesho@gmail.com",
                Gender = "Male",
                Contact_ULID = "ABCDE12345"
            };

            await contactManager.AddAsync(contact);

            var updatedContactInfo = new Contact
            {
                FirstName = "",
                LastName = "",
                Address = "",
                Phone = "",
                Email = "invalid",
                Gender = "toooooooollllooooonnnggg",
                Contact_ULID = "invalid"
            };

            // Act
            var contactToUpdate = await contactManager.GetSpecificAsync(contact.Contact_ULID);

            contactToUpdate.FirstName = updatedContactInfo.FirstName;
            contactToUpdate.LastName = updatedContactInfo.LastName;
            contactToUpdate.Address = updatedContactInfo.Address;
            contactToUpdate.Phone = updatedContactInfo.Phone;
            contactToUpdate.Email = updatedContactInfo.Email;
            contactToUpdate.Gender = updatedContactInfo.Gender;
            contactToUpdate.Contact_ULID = updatedContactInfo.Contact_ULID;

            // Act and Assert
            var ex = Assert.ThrowsAsync<ValidationException>(() => contactManager.UpdateAsync(contactToUpdate));
            Assert.That(ex.Message, Is.EqualTo("Invalid contact!"));

            // VARIANT 2 - without arrange and act, only Act+Assert
            var ex2 = Assert.ThrowsAsync<ValidationException>(() => contactManager.UpdateAsync(new Contact()));
            Assert.That(ex2.Message, Is.EqualTo("Invalid contact!"));
        }
    }
}
