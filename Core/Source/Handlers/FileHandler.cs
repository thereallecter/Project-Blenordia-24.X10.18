namespace Blenordia.Source.Handlers
{
    public struct FileInfo
    {
        public FileInfo(string name, string extsn, string location)
        {
            Name = name;
            Extension = extsn;
            Location = location;

            FullName = location + name + extsn;
        }

        public readonly string Name { get; }
        public readonly string Extension { get; }
        public readonly string Location { get; }
        public string FullName { get; set; }
    }

    public class File
    {
        public File Self;
        public FileInfo Info;

        public File[] LoadedFiles = [];

        public File(FileInfo info)
        {
            Info = info;
            Self = this;

            if (!Exists(info))
            {
                Console.WriteError($"{this.Info.Name} could not be found.");
            }
        }

        public static File Create(FileInfo info)
        {
            return new File(info);
        }

        private static bool Exists(FileInfo info)
        {
            return System.IO.File.Exists(info.FullName);
        }

        // New methods

        public string ReadAllText()
        {
            if (Exists(Info))
            {
                return System.IO.File.ReadAllText(Info.FullName);
            }
            throw new FileNotFoundException($"File not found: {Info.FullName}");
        }

        public void WriteAllText(string content)
        {
            System.IO.File.WriteAllText(Info.FullName, content);
        }

        public void AppendText(string content)
        {
            System.IO.File.AppendAllText(Info.FullName, content);
        }

        public void Delete()
        {
            if (Exists(Info))
            {
                System.IO.File.Delete(Info.FullName);
            }
            else
            {
                Console.WriteError($"Cannot delete file: {Info.FullName} - File not found.");
            }
        }

        public void CopyTo(string destinationPath)
        {
            if (Exists(Info))
            {
                System.IO.File.Copy(Info.FullName, destinationPath, overwrite: false);
            }
            else
            {
                Console.WriteError($"Cannot copy file: {Info.FullName} - File not found.");
            }
        }

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
    }
}
