namespace GiftAidCalculator.TestConsole.DI
{
    using Interfaces;
    using Microsoft.Practices.Unity;

    public class ContainerRegistrator
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICalculator>(new InjectionFactory(_ => CalculatorFactory.Create()));
        }
    }
}
