using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DependencyResolver;


namespace task_7._1._2_UI
{
    public static class Dependencies
    {
        public  readonly static IUserManager UserManager = DependencyResolver.UserManager;
        public  readonly static IAwardManager AwardManager = DependencyResolver.AwardManager;
        public readonly static IAccountManager AccountManager = DependencyResolver.AccountManager;
    }
}