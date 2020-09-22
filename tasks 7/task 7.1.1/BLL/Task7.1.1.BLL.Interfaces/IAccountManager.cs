using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1._1.BLL.Interfaces
{
    public interface IAccountManager
    {
        void Create (string login, string password, string role = "user");
        bool CanRegister (string login);
        bool CanLogin (string login, string password, out string errorMessage);
        void SetRole (string login, string role);
        string GetRole(string login);
    }
}
