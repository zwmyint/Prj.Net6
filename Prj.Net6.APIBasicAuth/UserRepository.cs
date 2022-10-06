using System.Collections.Generic;

namespace Prj.Net6.APIBasicAuth
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>()
        {
            new User
            {
                Id = 1, Username = "admin", Password = "admin123"
            },
            new User
            {
                Id = 2, Username = "peter", Password = "peter123"
            },
            new User
            {
                Id = 3, Username = "joydip", Password = "joydip123"
            },
            new User
            {
                Id = 4, Username = "james", Password = "james123"
            }
        };

        public async Task<bool> Authenticate(string username, string password)
        {
            if (await Task.FromResult(_users.SingleOrDefault(x => x.Username == username && x.Password == password)) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<User> Authenticate2(string username, string password)
        {
            // wrapped in "await Task.Run" to mimic fetching user from a db
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // on auth fail: null is returned because user is not found
            // on auth success: user object is returned
            return user;
        }

        public async Task<List<User>> GetUserNames()
        {
            List<User> xUserlist = new List<User>
            {
                new User { Id = 5, Username = "Username5", Password = "password5" },
                new User { Id = 6, Username = "Username6", Password = "password6" },
                new User { Id = 7, Username = "Username7", Password = "password7" },
            };
            _users.AddRange(xUserlist);

            List<User> users = new List<User>();
            foreach (var u in _users)
            {
                users.Add(new User { Id = u.Id, Username = u.Username, Password = u.Password });
            }
            return await Task.FromResult(users);

            //await Task.Delay(200);
            //return _users.ToList();

            //// wrapped in "await Task.Run" to mimic fetching users from a db
            //return await Task.Run(() => _users);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // wrapped in "await Task.Run" to mimic fetching users from a db
            return await Task.Run(() => _users);
        }


    }
}




