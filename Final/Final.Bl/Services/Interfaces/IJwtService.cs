using Final.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Bl.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(AppUser appUser);
    }
}
