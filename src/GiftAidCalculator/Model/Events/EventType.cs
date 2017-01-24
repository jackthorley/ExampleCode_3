namespace GiftAidCalculator.Model.Events
{
    using System.Collections.Generic;

    public sealed class EventType
    {
        public static readonly Event Default = new DefaultEvent();
        public static readonly Event Running = new RunningEvent();
        public static readonly Event Swimming = new SwimmingEvent();

        public static Dictionary<string, Event> Mappings = new Dictionary<string, Event>()
        {
            {"default", Default},
            {"running", Running},
            {"swimming", Swimming}
        };
    }
}