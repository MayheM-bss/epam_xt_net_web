using System;
using System.Collections.Generic;
using Task7._1._1.BLL;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL;
using Task7._1._1.DAL.Interfaces;

namespace Task7._1._1.DependencyResolver
{
    public static class DependencyResolver
    {
        private static readonly IAwardDAO _awardDAO;
        private static readonly IAwardManager _awardManager;
        public static IAwardDAO AwardDAO => _awardDAO;
        public static IAwardManager AwardManager => _awardManager;

        private static readonly IUserDAO _userDAO;
        private static readonly IUserManager _userManager;

        public static IUserDAO UserDAO => _userDAO;
        public static IUserManager UserManager => _userManager;

        private static readonly IAccountDAO _accountDAO;
        private static readonly IAccountManager _accountManager;

        public static IAccountDAO AccountDAO => _accountDAO;
        public static IAccountManager AccountManager => _accountManager;
        static DependencyResolver()
        {
            _awardDAO = new AwardDAO();
            _userDAO = new UserDAO();

            _userManager = new UserManager(_userDAO, _awardDAO);
            _awardManager = new AwardManager(_userDAO, _awardDAO);

            _accountDAO = new AccountDAO();

            _accountManager = new AccountManager(_accountDAO);
        }
    }
}
