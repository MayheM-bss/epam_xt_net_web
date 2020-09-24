using System;
using System.Collections.Generic;
using System.Configuration;
using Task_7._2._2.DAL;
using Task_7._2._2.DAL.Interfaces;
using Task7._1._1.BLL;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL;
using Task7._1._1.DAL.Interfaces;

namespace Task7._1._1.DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IAwardSqlDAO _awardDAO;
        private static readonly IAwardManager _awardManager;
        public static IAwardSqlDAO AwardDAO => _awardDAO;
        public static IAwardManager AwardManager => _awardManager;

        private static readonly IUserSqlDAO _userDAO;
        private static readonly IUserManager _userManager;

        public static IUserSqlDAO UserDAO => _userDAO;
        public static IUserManager UserManager => _userManager;

        private static readonly IAccountSqlDAO _accountDAO;
        private static readonly IAccountManager _accountManager;

        public static IAccountSqlDAO AccountDAO => _accountDAO;
        public static IAccountManager AccountManager => _accountManager;
        static DependencyResolver()
        {
            _awardDAO = new AwardSqlDAO();
            _userDAO = new UserSqlDAO();

            _userManager = new UserManager(_userDAO, _awardDAO);
            _awardManager = new AwardManager(_userDAO, _awardDAO);

            _accountDAO = new AccountSqlDAO();

            _accountManager = new AccountManager(_accountDAO);
        }
    }
}
