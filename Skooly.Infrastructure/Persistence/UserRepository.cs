using Skooly.Application.Common.Interfaces.Persistence;
using Skooly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skooly.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email.Equals(email));
        }
    }
}
