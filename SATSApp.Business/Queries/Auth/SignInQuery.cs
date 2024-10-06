namespace SATSApp.Business.Queries.Auth
{
    public class SignInQuery : IRequest<string>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
