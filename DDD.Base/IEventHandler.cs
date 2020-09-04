namespace DDD.Base
{
    public interface IEventHandler<in TEvent>   where TEvent : IEvent
    {
    }

    
}