using mcs.api.Models.Interface;

namespace mcs.api.Security.Interface
{
    public interface IAuthHelper
    {
        object AuthenticateUser(IUserAccount user);

        object AuthentiacteAPI(IAccessKey ApiKey);
    }
}