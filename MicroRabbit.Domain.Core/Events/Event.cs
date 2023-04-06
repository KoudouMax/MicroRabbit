namespace MicroRabbit.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime TimeStamp { get; }
        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
