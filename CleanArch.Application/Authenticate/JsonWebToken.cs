﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Authenticate
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
