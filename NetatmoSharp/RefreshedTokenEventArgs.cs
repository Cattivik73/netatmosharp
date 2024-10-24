﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetatmoSharp
{
    public class RefreshedTokenEventArgs : EventArgs
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public RefreshedTokenEventArgs(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
