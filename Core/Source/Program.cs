using Blenordia.Source.Handlers;

namespace Blenordia
{
    public static class Program
    {
        private static AccountInfo MasterAccountInfo =
            new AccountInfo("HuskyJew", "anotheremail@gmail.com", "!Password2024", Rank.Player);

        private static Account MasterAccount = Account.Register(MasterAccountInfo);

        public static void Main(string[] args)
        {
            System.Console.Title = "Project Blenordia Console";

            _ = new Application(MasterAccount);
        }
    }
}
