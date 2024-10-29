namespace Blenordia.Source.Handlers
{
    public struct FileInfo
    {
        public FileInfo(string name, string extsn, string location)
        {
            Name = name + extsn;
            Location = location + Name;
        }

        public readonly string Name { get; }
        public readonly string Location { get; }
    }

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

        public string ReadAllText()
        {
            if (Exists(Info))
            {
                return System.IO.File.ReadAllText(Info.Location);
            }
            throw new FileNotFoundException($"File not found: {Info.Location}");
        }

        public void WriteAllText(string content)
        {
            System.IO.File.WriteAllText(Info.Location, content);
        }

        public void AppendText(string content)
        {
            System.IO.File.AppendAllText(Info.Location, content);
        }

        public void Delete()
        {
            if (Exists(Info))
            {
                System.IO.File.Delete(Info.Location);
            }
            else
            {
                Console.WriteError($"Cannot delete file: {Info.Location} - File not found.");
            }
        }

        public void CopyTo(string destinationPath)
        {
            if (Exists(Info))
            {
                System.IO.File.Copy(Info.Location, destinationPath, overwrite: false);
            }
            else
            {
                Console.WriteError($"Cannot copy file: {Info.Location} - File not found.");
            }
        }

        private static bool Exists(FileInfo info)
        {
            return System.IO.File.Exists(info.Location);
        }

        /*
                public void MoveTo(string destinationPath)
                {
                    if (Exists(Info))
                    {
                        System.IO.File.Move(Info.FullName, destinationPath);
                        Info = new FileInfo(Path.GetFileNameWithoutExtension(destinationPath),
                                            Path.GetExtension(destinationPath),
                                            Path.GetDirectoryName(destinationPath) +
                                            Path.DirectorySeparatorChar);
                    }
                    else
                    {
                        Console.WriteError($"Cannot move file: {Info.FullName} - File not found.");
                    }
                }
        */
    }
}
