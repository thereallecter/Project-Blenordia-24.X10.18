namespace Blenordia.Source.Handlers
{
    public struct TileInfo
    {
        public TileInfo(string name)
        {
            Name = name;

            FileInfo = new FileInfo(name, ".tip", $"Data\\Tiles\\");
            File = File.Create(FileInfo);
        }

        public string Name { get; set; }

        private FileInfo FileInfo { get; set; }
        public File File { get; set; }
    }

    public class Tile
    {
        public TileInfo Info { get; }

        private Tile(TileInfo info)
        {
            Info = info;
        }

        public static Tile Create(TileInfo info)
        {
            return new Tile(info);
        }
    }
}
