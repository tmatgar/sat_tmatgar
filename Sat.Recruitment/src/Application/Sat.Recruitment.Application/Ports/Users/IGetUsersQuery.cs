using Sat.Recruitment.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Ports.Users
{
    public interface IGetUsersQuery
    {
        Task<IEnumerable<User>> Handle(CancellationToken cancellationToken);              
    }
}