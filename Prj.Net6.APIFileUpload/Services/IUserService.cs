using Prj.Net6.APIFileUpload.Resources;

namespace Prj.Net6.APIFileUpload.Services
{
    public interface IUserService
    {
        Task<UserResource> Register(RegisterResource resource, CancellationToken cancellationToken);
        Task<UserResource> Login(LoginResource resource, CancellationToken cancellationToken);
    }
}
