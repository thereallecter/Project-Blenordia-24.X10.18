using Blenordia.Source.Handlers;

using Console = Blenordia.Source.Console;
using Shell = System.Console;

namespace Blenordia
{
    public static class Program
    {
        private static AccountInfo MasterAccountInfo =
                   new("HuskyJew", "anotheremail@gmail.com", "!Password2024", Rank.Player);

        private static Account MasterAccount =
                       Account.Create(MasterAccountInfo);

        public static void Main(string[] args)
        {
            Shell.Title = "Project Blenordia Console";
            _ = new Application(MasterAccount);
        }
    }
}
