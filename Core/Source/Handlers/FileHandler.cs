using System;
using System.IO;

namespace Blenordia.Source.Handlers
{
    /// <summary>
    /// Represents metadata about a file in the system
    /// </summary>
    public readonly struct FileInfo
    {
        /// <summary>
        /// Creates a new FileInfo instance
        /// </summary>
        /// <param name="name">Base name of the file without extension</param>
        /// <param name="extension">File extension including the dot</param>
        /// <param name="location">Base directory path</param>
        public FileInfo(string name, string extension, string location)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("File name cannot be empty", nameof(name));
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentException("File extension cannot be empty", nameof(extension));

            Name = name + extension;
            Location = Path.Combine(location, Name);
        }

        public string Name { get; }
        public string Location { get; }
    }

    /// <summary>
    /// Provides a wrapper for file system operations
    /// </summary>
    public sealed class File
    {
        public FileInfo Info { get; }

        private File(FileInfo info)
        {
            Info = info;
        }

        public static File Create(FileInfo info)
        {
            return new File(info);
        }

        /// <summary>
        /// Reads all text from the file
        /// </summary>
        /// <returns>The contents of the file</returns>
        /// <exception cref="FileNotFoundException">Thrown when the file doesn't exist</exception>
        public string ReadAllText()
        {
            if (!Exists(Info))
                throw new FileNotFoundException($"File not found: {Info.Location}");

            return System.IO.File.ReadAllText(Info.Location);
        }

        /// <summary>
        /// Writes text to the file, overwriting any existing content
        /// </summary>
        public void WriteAllText(string content)
        {
            EnsureDirectoryExists();
            System.IO.File.WriteAllText(Info.Location, content);
        }

        /// <summary>
        /// Appends text to the end of the file
        /// </summary>
        public void AppendText(string content)
        {
            EnsureDirectoryExists();
            System.IO.File.AppendAllText(Info.Location, content);
        }

        /// <summary>
        /// Deletes the file if it exists
        /// </summary>
        public void Delete()
        {
            if (Exists(Info))
                System.IO.File.Delete(Info.Location);
            else
                Console.WriteError($"Cannot delete file: {Info.Location} - File not found.");
        }

        /// <summary>
        /// Copies the file to a new location
        /// </summary>
        public void CopyTo(string destinationPath)
        {
            if (!Exists(Info))
            {
                Console.WriteError($"Cannot copy file: {Info.Location} - File not found.");
                return;
            }

            string destinationDir = Path.GetDirectoryName(destinationPath)!;
            if (!string.IsNullOrEmpty(destinationDir))
                Directory.CreateDirectory(destinationDir);

            System.IO.File.Copy(Info.Location, destinationPath, overwrite: false);
        }

        private static bool Exists(FileInfo info) => System.IO.File.Exists(info.Location);

        private void EnsureDirectoryExists()
        {
            string directory = Path.GetDirectoryName(Info.Location)!;
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }
    }
}
