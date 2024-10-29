using System;
using System.IO;

namespace Blenordia.Source.Handlers
{
    /// <summary>
    /// Represents the configuration for a game tile
    /// </summary>
    public readonly struct TileInfo
    {
        /// <summary>
        /// Creates a new TileInfo instance
        /// </summary>
        /// <param name="name">The name of the tile</param>
        public TileInfo(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Tile name cannot be empty", nameof(name));

            Name = name;
            FileInfo = new FileInfo(name, ".tip", Path.Combine("Data", "Tiles"));
            File = File.Create(FileInfo);
        }

        public string Name { get; }
        internal FileInfo FileInfo { get; }
        public File File { get; }
    }

    /// <summary>
    /// Represents a game tile and handles tile-related operations
    /// </summary>
    public sealed class Tile
    {
        public TileInfo Info { get; }

        private Tile(TileInfo info)
        {
            Info = info;
        }

        /// <summary>
        /// Creates a new tile with the specified configuration
        /// </summary>
        /// <param name="info">The tile configuration</param>
        /// <returns>A new Tile instance</returns>
        public static Tile Create(TileInfo info)
        {
            // Here you might want to add initialization logic for new tiles
            return new Tile(info);
        }
    }
}
