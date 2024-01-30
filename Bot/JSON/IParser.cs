namespace Bot.JSON
{
    public interface IParser
    {
        public dynamic Parse(string json);
        public dynamic Parse(Stream json);
    }

}
