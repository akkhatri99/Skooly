using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skooly.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        Guid id,
        string FirstName,
        string LastName,
        string Email,
        string token
    );
}
