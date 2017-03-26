using SoftStore.BindingModels;

namespace SoftStore.Services.Contracts
{
    public interface IUsersService
    {
        bool IsBindModelValid(RegisterUserBm bind);
        void RegisterUser(RegisterUserBm bind);
        bool IsLoginSuccessful(LoginUserBm bind, string sessionId);
    }
}
