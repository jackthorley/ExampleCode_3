namespace GiftAidCalculator.Tests.Events
{
    using System.Collections.Generic;
    using Model.Events;
    using NUnit.Framework;
    
    public class GivenADonationWhenCalculatingAnEventSuppliment
    {
        public IEnumerable<TestCaseData> EventTestCases
        {
            get
            {
                yield return new TestCaseData(EventType.Default, 100, 0);
                yield return new TestCaseData(EventType.Swimming, 100, 3);
                yield return new TestCaseData(EventType.Running, 100, 5);
            }
        }

        [TestCaseSource("EventTestCases")]
        public void GivenADonation_WhenCalculatingAnEventSuppliment_ThenTheCorrectSupplimentIsAdded(Event @event, int donation, int expectedSuppliment)
        {
            var suppliment = @event.CalculateSuppliment(donation);
            Assert.AreEqual(suppliment,expectedSuppliment);
        }
    }
}
