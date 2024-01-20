namespace JajaSithTgBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await BotHelper.Start(BotHelper.LoadSettigs());

            Console.ReadLine();

            BotHelper.Stop();
        }
    }
}