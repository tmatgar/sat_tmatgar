using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Business.Users.Responses;
using Sat.Recruitment.Application.Ports.Users;
using Sat.Recruitment.Domain.Core.Entities;
using Sat.Recruitment.Domain.Core.Exceptions;
using Sat.Recruitment.Utils;

namespace Sat.Recruitment.Application.Business.Users
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string Money { get; set; }
    }

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("Campo Name no puede ser nulo");

            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage("Campo Email no puede ser nulo");

            RuleFor(request => request.Address)
                .NotEmpty()
                .WithMessage("Campo Address no puede ser nulo");

            RuleFor(request => request.Phone)
                .NotEmpty()
                .WithMessage("Campo Phone no puede ser nulo");

            RuleFor(request => request.UserType)
                .NotEmpty()
                .WithMessage("Campo UserType no puede ser nulo");

            RuleFor(request => request.Money)
                .NotEmpty()
                .WithMessage("Campo Money no puede ser nulo");
        }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {       
        private readonly IGetUsersQuery _getUsersQuery;

        public CreateUserHandler(IGetUsersQuery getUsersQuery)
        {            
            _getUsersQuery = getUsersQuery;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new User(request.Name,
                    EmailExtensions.Normalize(request.Email),
                    request.Address,
                    request.Phone,
                    request.UserType,
                    decimal.Parse(request.Money)
                );

                var users = await _getUsersQuery.Handle(cancellationToken);

                if (!newUser.CheckDuplicateUser(users))
                {                   
                    return new CreateUserResponse();
                }

                throw new EntityAlreadyExistsException(typeof(User), newUser.Name);
            }
            catch
            {
                throw;
            }
        }
    }
}