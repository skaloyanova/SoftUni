using OpenQA.Selenium;

namespace RevueCrafters.Tests;

public class RevueCraftersTests : BaseTest
{
    private string? lastCreatedRevueTitle;
    private string? lastCreatedRevueDescription;

    [Test, Order(1)]
    public void CreateRevuew_WithInvalidData_ShouldGetErrorMessage()
    {
        createRevuePage.OpenPage();

        createRevuePage.CreateRevue("", "", "");

        createRevuePage.AssertErrors();

        Assert.That(createRevuePage.IsPageOpen(), "User should stay on 'Create Revue' Page");
    }

    [Test, Order(2)]
    public void CreateRevuew_WithRandomData_ShouldSucceed()
    {
        createRevuePage.OpenPage();

        string[] data = GetRandomRevueData();   // [title, imageUrl, description]

        lastCreatedRevueTitle = data[0];
        lastCreatedRevueDescription = data[2];

        createRevuePage.CreateRevue(lastCreatedRevueTitle, data[1], lastCreatedRevueDescription);

        Assert.Multiple(() =>
        {
            Assert.That(myRevuePage.IsPageOpen(), "User should be redirected to 'My Revues' Page");
            Assert.That(myRevuePage.GetTitleOfLastCreatedRevue(), Is.EqualTo(lastCreatedRevueTitle), "Revue Title does not match");
            Assert.That(myRevuePage.GetDescriptionOfLastCreatedRevue(), Is.EqualTo(lastCreatedRevueDescription), "Revue Description does not match");
        });

        Console.WriteLine($"Title: {lastCreatedRevueTitle}");
        Console.WriteLine($"Image URL: {data[1]}");
        Console.WriteLine($"Description: {lastCreatedRevueDescription}");
    }

    [Test, Order(3)]
    public void SearchForLastCreatedRevueTest()
    {
        myRevuePage.OpenPage();
        myRevuePage.SearchByKeyword(lastCreatedRevueTitle);

        string foundRevueTitle = myRevuePage.GetTitleOfFirstRevueInSearchList();

        Assert.That(foundRevueTitle, Is.EqualTo(lastCreatedRevueTitle), "Revue Title does not match");
    }

    [Test, Order(4)]
    public void EditLastCreatedRevueTest()
    {
        myRevuePage.OpenPage();
        Assert.That(myRevuePage.GetAllRevues(), Has.Count.GreaterThan(0), "Revue list should not be empty");

        myRevuePage.ClickEditButtonOnLastCreatedRevue();

        string currentTitle = editRevuePage.GetCurrentTitle();
        string currentDescription = editRevuePage.GetCurrentDescription();
        string currentImageUrl = editRevuePage.GetCurrentImageUrl();

        // Assert that last created revue is opened for Edit
        Assert.Multiple(() =>
        {
            Assert.That(currentTitle, Is.EqualTo(lastCreatedRevueTitle), "Title of the Revue to Edit does not match the title of last created revue");
            Assert.That(currentDescription, Is.EqualTo(lastCreatedRevueDescription), "Description of the Revue to Edit does not match the description of last created revue");
        });

        // Edit Title and Description fields
        string updatedTitle = currentTitle + "UPDATED";
        string updatedDescription = currentDescription + "UPDATED";

        editRevuePage.UpdateTitleAndDescription(updatedTitle, updatedDescription);

        // Assert data is updated
        Assert.Multiple(() =>
        {
            Assert.That(myRevuePage.IsPageOpen(), "User should be redirected to 'My Revues' Page");
            Assert.That(myRevuePage.GetTitleOfLastCreatedRevue(), Is.EqualTo(updatedTitle), "Revue Title does not match the updated Title");
            Assert.That(myRevuePage.GetDescriptionOfLastCreatedRevue(), Is.EqualTo(updatedDescription), "Revue Description does not match the updated Description");
        });
    }

    [Test, Order(5)]
    public void DeleteLastCreatedRevueTest()
    {
        myRevuePage.OpenPage();
        var allRevues = myRevuePage.GetAllRevues();
        Assert.That(allRevues, Has.Count.GreaterThan(0), "Revue list should not be empty");

        myRevuePage.ClickDeleteButtonOnLastCreatedRevue();

        Assert.Multiple(() =>
        {
            Assert.That(myRevuePage.IsPageOpen(), "User should be redirected to 'My Revues' Page");
            Assert.That(myRevuePage.GetAllRevues(), Has.Count.EqualTo(allRevues.Count - 1), "Revue count was not decreased");
            if (myRevuePage.GetAllRevues().Count > 0)
            {
                Assert.That(myRevuePage.GetTitleOfLastCreatedRevue(), Is.Not.EqualTo(lastCreatedRevueTitle), "Title of the last created revue should not exist");
                Console.WriteLine("Title of last revue in the list is: " + myRevuePage.GetTitleOfLastCreatedRevue());
            }
        });
    }

    [Test, Order(6)]
    public void SearchForDeletedOrNonExistentRevueTest()
    {
        myRevuePage.OpenPage();
        myRevuePage.SearchByKeyword(lastCreatedRevueTitle);

        Assert.Multiple(() =>
        {
            Assert.That(myRevuePage.GetAllRevues(), Has.Count.EqualTo(0), "Search List is not empty");
            Assert.That(myRevuePage.GetNoRevuesMessage(), Is.EqualTo("No Revues yet!"), "No Revues message does not match");
        });
    }
}
