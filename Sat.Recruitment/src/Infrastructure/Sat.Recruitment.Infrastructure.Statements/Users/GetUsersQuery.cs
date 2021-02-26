using Sat.Recruitment.Application.Ports.Users;
using Sat.Recruitment.Domain.Core.Entities;
using Sat.Recruitment.Domain.Core.Enums;
using Sat.Recruitment.Domain.Core.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Infrastructure.Statements.Users
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly IRepository<User> _userRepository;

        public GetUsersQuery(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(CancellationToken cancellationToken)
        {
            try
            {
                return await _userRepository.GetItemsAsync(FileType.Users, cancellationToken);               
            }
            catch
            {
                throw;
            }
        }       
    }
}
