namespace Blenordia.Source.Handlers
{
    public struct TileInfo
    {
        public TileInfo(string name)
        {
            Name = name;

            FileInfo = new FileInfo(name, ".tip", $"Data\\Tiles\\");
            File = new File(FileInfo);
        }

        public string Name { get; set; }

        private FileInfo FileInfo { get; set; }
        public File File { get; set; }
    }

    public class Tile
    {
        public Tile Self { get; }
        public TileInfo Info { get; }

        public Tile(TileInfo info)
        {
            Info = info;
            Self = this;
        }
    }
}
