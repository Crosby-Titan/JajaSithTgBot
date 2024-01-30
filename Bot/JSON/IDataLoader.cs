namespace Bot.JSON
{
    public interface IDataLoader
    {
        T? Load<T>(Stream obj);
    }
}
