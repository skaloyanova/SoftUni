using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom _chatRoom = null!;
    
    [SetUp]
    public void Setup()
    {
        this._chatRoom = new();
    }
    
    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        //Arrange
        string sender = "stun";
        string message = "Hello World!";

        string expected = $"Chat Room Messages:{Environment.NewLine}" +
            $"{sender}: {message} - Sent at 14-12-2023";

        //Act
        _chatRoom.SendMessage(sender, message);
        string result = _chatRoom.DisplayChat();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        //Arrange
        string expected = "Chat Room Messages:";

        //Act
        string result = _chatRoom.DisplayChat();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        //Arrange
        string sender1 = "stun";
        string message1 = "Hello World!";

        string sender2 = "Me, myself and Irene";
        string message2 = "Aloha :)";

        string expected = $"Chat Room Messages:{Environment.NewLine}" +
            $"{sender1}: {message1} - Sent at 14-12-2023{Environment.NewLine}" +
            $"{sender2}: {message2} - Sent at 14-12-2023";

        //Act
        _chatRoom.SendMessage(sender1, message1);
        _chatRoom.SendMessage(sender2, message2);
        string result = _chatRoom.DisplayChat();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
