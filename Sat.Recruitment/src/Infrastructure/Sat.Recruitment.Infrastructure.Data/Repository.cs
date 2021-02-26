using Sat.Recruitment.Domain.Core.Entities;
using Sat.Recruitment.Domain.Core.Enums;
using Sat.Recruitment.Domain.Core.Interfaces;
using Sat.Recruitment.Utils;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public Repository()
        {
        }

        public async Task<IEnumerable<T>> GetItemsAsync(FileType fileType, CancellationToken cancellationToken)
        {
            try
            {
                List<T> items = new List<T>();

                switch (fileType)
                {
                    case FileType.Users:
                        var reader = FileExtensions.ReadFromFile(Directory.GetCurrentDirectory() + "/Files/Users.txt");
                        while (reader.Peek() >= 0)
                        {
                            items.Add((T)(object)new User(await reader.ReadLineAsync()));
                        }
                        reader.Close();
                        break;
                    default:
                        break;
                }

                return items;
            }
            catch
            {
                throw;
            }
        }
    }
}