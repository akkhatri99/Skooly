﻿using Skooly.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skooly.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user);    
    }
}
