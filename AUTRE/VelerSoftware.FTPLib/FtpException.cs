﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VelerSoftware.FTPLib
{
    public class FtpException : Exception
    {
        public FtpException(int error, string message)
            : base(message)
        {
            _error = error;
        }

        private int _error;

        public int ErrorCode
        {
            get { return _error; }
        }
    }
}
