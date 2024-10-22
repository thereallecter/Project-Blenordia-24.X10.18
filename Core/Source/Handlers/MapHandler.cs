using System.Drawing.Imaging;
using System.Drawing;
using System;
using Microsoft.Win32.SafeHandles;

namespace Blenordia.Source.Handlers
{
    public struct MapInfo
    {
        public MapInfo(string name, int width = 512, int height = 512)
        {
            Name = name;
            Width = width;
            Height = height;

            FileInfo = new FileInfo(name, ".mip", "Data\\Maps\\");
            File = File.Create(FileInfo);
        }

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private FileInfo FileInfo { get; set; }
        public File File { get; set; }
    }

    public class Map
    {
        public MapInfo Info { get; }

        private Map(MapInfo info)
        {
            Info = info;
        }

        public static Map Create(MapInfo info)
        {

            if (System.IO.File.Exists(info.File.Info.FullName))
            {
                System.IO.File.Create(info.File.Info.FullName);
            }

            return new Map(info);
        }
    }
}
