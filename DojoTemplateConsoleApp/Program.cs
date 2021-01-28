namespace DojoTemplateConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lift = new Lift();
            var engine = new Engine(lift);

            while (true)
            {
                //engine.Run();
            }
        }
    }
}
