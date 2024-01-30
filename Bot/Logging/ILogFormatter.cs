namespace Bot.Logging
{
    public interface ILogFormatter
    {
        public object Format(object message);
    }
}
