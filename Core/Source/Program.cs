using Blenordia.Source.Handlers;

using Console = Blenordia.Source.Console;
using File = Blenordia.Source.Handlers.File;
using FileInfo = Blenordia.Source.Handlers.FileInfo;

namespace Blenordia
{
    public static class Program
    {
        private static AccountInfo info = new AccountInfo();
        private static Account MasterAccount = Account.Register(info);

        public static void Main(string[] args)
        {
            System.Console.Title = "Project Blenordia Console";

            _ = new Application(MasterAccount);
        }
    }
}
