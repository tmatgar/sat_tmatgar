using System.IO;

namespace Sat.Recruitment.Utils
{
    public static class FileExtensions
    {
        public static StreamReader ReadFromFile(string path)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);

                StreamReader reader = new StreamReader(fileStream);

                return reader;
            }
            catch
            {
                throw;
            }            
        }
    }
}