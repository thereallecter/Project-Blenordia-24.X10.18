namespace Blenordia.Source.Handlers
{
    public struct TileInfo
    {
        public TileInfo(string name)
        {
            Name = name;

            Info = new FileInfo(name, ".tip", $"Data\\Tiles\\");
            File = new File(Info);
        }

        public string Name { get; set; }

        private FileInfo Info { get; set; }
        public File File { get; set; }
    }

    public class Tile
    {
        public Tile Self;
        public TileInfo Info;

        public Tile(TileInfo info)
        {
            Info = info;
            Self = this;
        }
    }
}
