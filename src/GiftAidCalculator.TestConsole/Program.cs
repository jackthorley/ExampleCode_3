using System;

namespace GiftAidCalculator.TestConsole
{
    using DI;
    using Interfaces;
    using Microsoft.Practices.Unity;
    using Model.Events;

    internal class Program
	{
        //This UI element is doing quite a few things
        internal static void Main()
        {
            var calculator = Initialise();

            var donationInput = SetDonation();
            var @event = SetEvent();

            Console.WriteLine("Gift Aid amount:");
            Console.WriteLine(calculator.Execute(decimal.Parse(donationInput), @event));
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static ICalculator Initialise()
        {
            var container = new UnityContainer();
            ContainerRegistrator.RegisterTypes(container);
            var calculator = container.Resolve<ICalculator>();
            return calculator;
        }

        private static string SetDonation()
        {
            Console.WriteLine("Please Enter donation amount:");
            var donationInput = Console.ReadLine();
            return donationInput;
        }

        private static Event SetEvent()
        {
            Console.WriteLine("Please Enter event:");
            var eventInput = Console.ReadLine();

            var @event = EventType.Default;

            if (EventType.Mappings.ContainsKey(eventInput))
                @event = EventType.Mappings[eventInput];
            return @event;
        }
    }
}
