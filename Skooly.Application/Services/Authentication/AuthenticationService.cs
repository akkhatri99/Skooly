using Skooly.Application.Common.Interfaces.Authentication;
using Skooly.Application.Common.Interfaces.Persistence;
using Skooly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skooly.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJWTTokenGenerator _jWTTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJWTTokenGenerator jWTTokenGenerator, IUserRepository userRepository)
        {
            _jWTTokenGenerator = jWTTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Validate the user doesn't exist
            if(_userRepository.GetByEmail(email) is not null)
            {
                throw new Exception("User with Email already exists.");
            }

            // Create user (Generate unique ID) & Persist to DB

            var user = new User { FirstName = firstName, LastName = lastName ,Email = email, Password = password };
            _userRepository.Add(user);

            // Create JWT Token
            var token = _jWTTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
        public AuthenticationResult Login(string email, string password)
        {
            // Check if user exists
            if(_userRepository.GetByEmail(email) is not User user)
            {
                throw new Exception("User with given Email doesn't exists.");
            }

            // Validate the password is correct
            if(user.Password != password)
            {
                throw new Exception("Password is incorrect.");
            }

            // Create JWT Token
            var token = _jWTTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
