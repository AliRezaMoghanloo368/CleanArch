﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Exceptions
{
    public class ActioException : Exception
    {
        public string Code { get; set; }
        public ActioException()
        {

        }

        public ActioException(string code)
        {
            this.Code = code;
        }

        public ActioException(string message, params object[] args)
            : this(string.Empty, message, args)
        {

        }

        public ActioException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {

        }

        public ActioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {

        }

        public ActioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message,args), innerException)
        {
            this.Code = code;
        }
    }
}
