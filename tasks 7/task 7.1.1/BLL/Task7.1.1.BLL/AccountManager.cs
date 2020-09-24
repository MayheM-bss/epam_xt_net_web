using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_7._2._2.DAL.Interfaces;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountSqlDAO _accountDAO;

        public AccountManager(IAccountSqlDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public bool CanLogin(string login, string password, out string errorMessage)
        {
            if (!(string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password)))
            {
                var account = _accountDAO.GetByLogin(login);
                if (account != null)
                {
                    if (account.Password == password)
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Введён неверный пароль";
                        return false;
                    }
                }
                else
                {
                    errorMessage = $"Аккаунт с логином \"{login}\" не зарегистрирован";
                    return false;
                }
            }
            else
            {
                errorMessage = "Поле логин или пароль не было заполнено";
                return false;
            }
        }

        public bool CanRegister(string login)
        {
            return (_accountDAO.GetByLogin(login) == null);
        }

        public void Create(string login, string password, string role = "user")
        {
            if (!(string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password)))
            {
                _accountDAO.Save(new Account(login, password, role));
            }
        }

        public void SetRole(string login, string role)
        {
            var account = _accountDAO.GetByLogin(login);
            if (account != null)
            {
                _accountDAO.Save(new Account(account.Login, account.Password, role));
            }
        }

        public string GetRole(string login)
        {
            return _accountDAO.GetByLogin(login).Role ?? string.Empty;
        }
    }
}
