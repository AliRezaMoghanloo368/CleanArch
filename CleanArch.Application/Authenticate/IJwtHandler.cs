using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Authenticate
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
    }
}
