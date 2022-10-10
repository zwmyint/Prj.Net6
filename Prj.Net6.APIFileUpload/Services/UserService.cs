using Microsoft.EntityFrameworkCore;
using Prj.Net6.APIFileUpload.Data;
using Prj.Net6.APIFileUpload.Entities;
using Prj.Net6.APIFileUpload.Resources;

namespace Prj.Net6.APIFileUpload.Services
{
    public sealed class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserService(AppDbContext context)
        {
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
        }

        public async Task<UserResource> Register(RegisterResource resource, CancellationToken cancellationToken)
        {
            var user = new UserPwd
            {
                Username = resource.Username,
                Email = resource.Email,
                PasswordSalt = PasswordHasher.GenerateSalt()
            };
            user.PasswordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            await _context.UserPWD.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new UserResource(user.Id, user.Username, user.Email);
        }

        public async Task<UserResource> Login(LoginResource resource, CancellationToken cancellationToken)
        {
            var user = await _context.UserPWD
                .FirstOrDefaultAsync(x => x.Username == resource.Username, cancellationToken);

            if (user == null)
                throw new Exception("Username or password did not match.");

            var passwordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Username or password did not match.");

            return new UserResource(user.Id, user.Username, user.Email);
        }
    }
}
