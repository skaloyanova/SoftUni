
using System.Threading.Channels;

namespace IdeaCenter.Tests;

public class IdeaCenterTests : BaseTest
{
    public string lastCreatedIdeaTitle;
    public string lastCreatedIdeaDescription;

    [Test, Order(1)]
    public void CreateIdea_WithInvalidData_ShouldReceiveError()
    {
        createIdeaPage.openPage();

        createIdeaPage.CreateIdea("", "");

        createIdeaPage.AssertAllErrorMessages();
        Assert.That(createIdeaPage.IsPageOpen(), "Current page should be 'Create Idea'");
    }

    [Test, Order(2)]
    public void CreateIdea_WithRandomData_ShouldCreateIdea()
    {
        lastCreatedIdeaTitle = GetRandomTitle();
        lastCreatedIdeaDescription = GetRandomDescription();

        createIdeaPage.openPage();

        createIdeaPage.CreateIdea(lastCreatedIdeaTitle, lastCreatedIdeaDescription);

        Assert.That(myIdeasPage.IsPageOpen(), "Current page should be 'My Ideas'");

        var lastIdea = myIdeasPage.GetLastCreatedIdea();

        Assert.That(myIdeasPage.GetIdeaDescription(lastIdea), Is.EqualTo(lastCreatedIdeaDescription), "Description of last idea created does not match");

        Console.WriteLine("lastCreatedIdeaTitle: " + lastCreatedIdeaTitle);
        Console.WriteLine("lastCreatedIdeaDescription: " + lastCreatedIdeaDescription);
    }

    [Test, Order(3)]
    public void View_LastCreatedIdea()
    {
        myIdeasPage.openPage();
        var lastIdea = myIdeasPage.GetLastCreatedIdea();
        Assert.That(lastIdea, Is.Not.Null, "Idea not retrieved");

        myIdeasPage.ClickIdeaViewButton(lastIdea);
        Assert.That(viewIdeaPage.IsPageOpen(), "View page not loaded");

        Assert.Multiple(() =>
        {
            Assert.That(viewIdeaPage.GetIdeaTitle(), Is.EqualTo(lastCreatedIdeaTitle), "Title does not match");
            Assert.That(viewIdeaPage.GetIdeaDescription(), Is.EqualTo(lastCreatedIdeaDescription), "Description does not match");
        });
    }


    [Test, Order(4)]
    public void Edit_LastCreatedIdea_WithInvalidInput_ShouldReceiveError()
    {
        myIdeasPage.openPage();
        var lastIdea = myIdeasPage.GetLastCreatedIdea();
        Assert.That(lastIdea, Is.Not.Null, "Idea not retrieved");

        myIdeasPage.ClickIdeaEditButton(lastIdea);
        Assert.That(editIdeaPage.IsPageOpen(), "Edit page not loaded");

        Assert.Multiple(() =>
        {
            Assert.That(editIdeaPage.GetIdeaTitle(), Is.EqualTo(lastCreatedIdeaTitle), "Title does not match");
            Assert.That(editIdeaPage.GetIdeaDescription(), Is.EqualTo(lastCreatedIdeaDescription), "Description does not match");
        });

        //Update idea with empty fields
        editIdeaPage.UpdateTitle("");
        editIdeaPage.UpdateDescription("");
        editIdeaPage.ClickEditButton();

        Assert.That(editIdeaPage.GetErrorMessage, Is.EqualTo("Unable to edit the Idea!"), "Error message is not as expected");
    }

    [Test, Order(5)]
    public void Edit_LastCreatedIdea()
    {
        myIdeasPage.openPage();
        var lastIdea = myIdeasPage.GetLastCreatedIdea();
        Assert.That(lastIdea, Is.Not.Null, "Idea not retrieved");

        myIdeasPage.ClickIdeaEditButton(lastIdea);
        Assert.That(editIdeaPage.IsPageOpen(), "Edit page not loaded");

        Assert.Multiple(() =>
        {
            Assert.That(editIdeaPage.GetIdeaTitle(), Is.EqualTo(lastCreatedIdeaTitle), "Title does not match");
            Assert.That(editIdeaPage.GetIdeaDescription(), Is.EqualTo(lastCreatedIdeaDescription), "Description does not match");
        });

        string newTitle = "Changed Title: " + lastCreatedIdeaTitle;
        string newDescription = "Changed Description: " + lastCreatedIdeaDescription;

        //Edit idea
        editIdeaPage.UpdateTitle(newTitle);
        editIdeaPage.UpdateDescription(newDescription);
        editIdeaPage.ClickEditButton();

        Assert.That(myIdeasPage.IsPageOpen(), "User is not redirected to 'My Ideas'");

        lastIdea = myIdeasPage.GetLastCreatedIdea();
        myIdeasPage.ClickIdeaViewButton(lastIdea);
        Assert.That(viewIdeaPage.IsPageOpen(), "View page not loaded");

        Assert.Multiple(() =>
        {
            Assert.That(viewIdeaPage.GetIdeaTitle(), Is.EqualTo(newTitle), "Title is not as expected");
            Assert.That(viewIdeaPage.GetIdeaDescription(), Is.EqualTo(newDescription), "Description is not as expected");
        });
    }

    [Test, Order(6)]
    public void Delete_LastCreatedIdea()
    {
        myIdeasPage.openPage();
        var lastIdea = myIdeasPage.GetLastCreatedIdea();
        Assert.That(lastIdea, Is.Not.Null, "Idea not retrieved");

        var ideaDescription = myIdeasPage.GetIdeaDescription(lastIdea);

        myIdeasPage.ClickIdeaDeleteButton(lastIdea);
        Assert.That(myIdeasPage.IsPageOpen(), "My Idea page not loaded");
        Assert.That(myIdeasPage.GetIdeaByDescription(ideaDescription), Is.Null);
    }
}
