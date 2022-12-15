
public interface IObservableFloat
{
    void Subscribe(IObserverFloat obs);
    void Unsubscribe(IObserverFloat obs);
    void NotifyToObserver(float life);
}
