public interface IObservable<T>
{
    void Subscribe(IObserver<T> observer);
    void UnSubscribe(IObserver<T> observer);
    void NotifySubscribers(T subject);
}