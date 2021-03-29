namespace FV.PaymentCalculator.Core.Observer
{
    public interface ICalculateObserver
    {
        void Execute(ICalculateSubject subject);
    }
}
