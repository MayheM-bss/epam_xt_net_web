using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task7._1._1.DAL.Interfaces
{
    public interface IUserDAO
    {
        void Save(User user);
        void DeleteById(Guid id);
        IEnumerable<User> GetAll();
        User GetById(Guid id);

    }
}
