using Blenordia.Source.Handlers;
using Console = Blenordia.Source.Console;
using Shell = System.Console;

namespace Blenordia
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Shell.Title = "Project Blenordia Console";

            _ = new Application(
                    Account.Create(
                        new AccountInfo("Player", "player@gmail.com", "password", Rank.Player)));

            Map PirateCave = Map.Create(new MapInfo("PirateCave"));
            Map EpicPirateCave = Map.Create(new MapInfo("EpicPirateCave"));

            Map HollowForest = Map.Create(new MapInfo("HollowForest"));
        }
    }
}
