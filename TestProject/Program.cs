namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestService svc = new RequestService();

            svc.MakePlayerRequest(new string[] {"Liquid_Fire_", "ShawtyDaBomb" });
        }
    }
}
