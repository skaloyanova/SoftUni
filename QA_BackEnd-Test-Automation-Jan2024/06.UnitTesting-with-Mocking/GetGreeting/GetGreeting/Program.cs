using GetGreeting;

class Program
{
    static void Main(string[] args)
    {
        DateTime fakeTime = new DateTime(2024, 2, 12, 9, 15, 0);
        DateTime realTime = new TimeProvider().GetCurrentTime();

        GreetingProvider greetingProviderFake = new GreetingProvider(new FakeTimeProvider(fakeTime));

        GreetingProvider greetingProviderReal = new GreetingProvider(new TimeProvider());

        string greetingFake = greetingProviderFake.GetGreeting();
        string greetingReal = greetingProviderReal.GetGreeting();

        Console.WriteLine("fake time: " + fakeTime + " - " + greetingFake);
        Console.WriteLine("real time: " + realTime + " - " + greetingReal);
    }
}