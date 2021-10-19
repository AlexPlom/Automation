using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    internal class AppSettings
    {
        public AppSettings(string email, string password)
        {
            Email = email;
            Password = password;
        }

        AppSettings()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
