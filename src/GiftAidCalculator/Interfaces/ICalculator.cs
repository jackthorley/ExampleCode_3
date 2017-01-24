namespace GiftAidCalculator.Interfaces
{
    using Model.Events;

    public interface ICalculator
    {
        decimal Execute(decimal donation, Event @event);
    }
}