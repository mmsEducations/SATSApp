namespace SATSApp.Business.Command.Auth
{
    public class CreateRoleCommand : IRequest<string>
    {
        public string Role { get; set; }
    }
}
