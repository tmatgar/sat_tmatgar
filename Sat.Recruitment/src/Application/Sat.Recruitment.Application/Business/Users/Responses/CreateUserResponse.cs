namespace Sat.Recruitment.Application.Business.Users.Responses
{
    public class CreateUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }        

        public CreateUserResponse()
        {
            IsSuccess = true;
            Message = "User created";
        }       
    }
}