using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DependencyResolver;

namespace Console.PL
{
    class Program
    {
        static void Main()
        {
            IUserManager Userq  = DependencyResolver.UserManager;
            IAwardManager Award = DependencyResolver.AwardManager;
            //Userq.Create("Alex", DateTime.Parse("25.12.1998"), 25);
            //Userq.Create("John", DateTime.Parse("25.12.1998"), 25);
            //Userq.Create("Gustav", DateTime.Parse("25.12.1998"), 25);
            //Userq.Create("Rust", DateTime.Parse("25.12.1998"), 25);
            //Award.Create("Best of the best");
            //Award.Create("Strongest");
            //Award.Create("Fastest");
            //Userq.AddAward(Guid.Parse("4e3d085b-946e-42d1-8029-24a44ee1373f"), Guid.Parse("d8485da4-b895-458f-a04a-cb26caf9413a"));
            //Userq.AddAward(Guid.Parse("9d1b6b53-276d-48e7-b4df-50a4e2516658"), Guid.Parse("d8485da4-b895-458f-a04a-cb26caf9413a"));
            //Award.DeleteById(Guid.Parse("d8485da4-b895-458f-a04a-cb26caf9413a"));
        }
    }
}
