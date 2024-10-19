using System.Drawing.Imaging;
using System.Drawing;
using System;

namespace Blenordia.Source.Handlers
{
    public struct MapInfo
    {
        public MapInfo(string name, int width = 512, int height = 512)
        {
            Name = name;
            Width = width;
            Height = height;

            Info = new FileInfo(name, ".mip", $"Data\\Maps\\");
            File = new File(Info);
        }

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private FileInfo Info { get; set; }
        public File File { get; set; }
        public Tile[]? Tiles { get; set; }
    }

    public class Map
    {
        public Map Self;
        public MapInfo Info;

        public Map(MapInfo info)
        {
            Info = info;
            Self = this;
        }

        public static Map Create(MapInfo info)
        {
            return new Map(info);
        }
    }
}
