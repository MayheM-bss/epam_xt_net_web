using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL.Interfaces
{
    public interface IUserManager
    {
        void AddAward(Guid userId, Guid awardId);
        void Create(string name, DateTime dateOfBirth);
        void DeleteById(Guid id);
        IEnumerable<User> GetAll();
    }
}
