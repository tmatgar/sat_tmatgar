using Sat.Recruitment.Domain.Core.Entities;
using Sat.Recruitment.Domain.Core.Enums;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Core.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetItemsAsync(FileType fileType, CancellationToken cancellationToken);             
    }
}