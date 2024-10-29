﻿using System.Drawing.Imaging;
using System.Drawing;
using System;
using Microsoft.Win32.SafeHandles;
using System.IO.Compression;
using System.Security.Cryptography;

using Newtonsoft.Json;

namespace Blenordia.Source.Handlers
{
    public struct MapInfo
    {
        public MapInfo(string name, int width = 512, int height = 512)
        {
            Name = name;
            Width = width;
            Height = height;

            FileInfo = new FileInfo(name, ".cs", $"Data\\Maps\\{name}\\");
            File = File.Create(FileInfo);
        }

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private FileInfo FileInfo { get; set; }
        public File File { get; set; }
    }

    partial class Map
    {
        public MapInfo Info { get; }

        private Map(MapInfo info)
        {
            Info = info;
        }

        public static Map Create(MapInfo info)
        {
            DirectoryInfo dirInf = new DirectoryInfo(info.File.Info.Location);
            dirInf.Create();

            FileStream cs_file = System.IO.File.Create(info.File.Info.FullName);
            cs_file.Close();

            FileStream json_file = System.IO.File.Create((info.File.Info.FullName).Replace(".cs", ".json"));
            json_file.Close();

            string sjon = JsonConvert.SerializeObject(info);
            System.IO.File.WriteAllText(json_file.Name, sjon);

            Console.WriteInfo(sjon);

            string[]? MapCSTemplate =
                {
                    "namespace Blenordia.Maps \n{\n" +
                   $"    public class {info.Name} \n    {{\n" +
                    "        public MapInfo Info;\n\n" +
                   $"        public {info.Name}(MapInfo info) \n        {{\n" +
                    "            Info = info;\n" +
                    "        }\n" +
                    "    }\n" +
                    "}"
                };

            foreach (var line in MapCSTemplate)
            {
                info.File.WriteAllText(line);
            }

            // this is where a Map Generation function would go to start
            // generating the map that is calling this method
            // if the map already exists, it will load existing instead

            return new Map(info);
        }

        // Not fully implemented
        public static Map Load(MapInfo info)
        {
            if (!System.IO.File.Exists(info.File.Info.FullName))
            {
                Console.WriteInfo($"{info.Name} wasn't found");
                // System.IO.File.Create(info.File.Info.FullName);
            }

            return Create(info);
        }
    }
}
