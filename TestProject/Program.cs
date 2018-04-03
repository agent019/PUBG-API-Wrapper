namespace TestProject
{
    class Program
    {
        private const string ApiKey = ""; // Ain't got one yet.



        static void Main(string[] args)
        {
            RequestService svc = new RequestService();

            svc.MakePlayerRequest(new string[] {"Liquid_Fire_", "ShawtyDaBomb" }, ApiKey);
        }
    }
}
