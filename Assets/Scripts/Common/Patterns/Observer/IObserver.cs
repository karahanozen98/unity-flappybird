public interface IObserver<T>
{
    void OnUpdate(T subject);
}