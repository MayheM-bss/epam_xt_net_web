using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task_7._2._2.DAL.Interfaces
{
    public interface IAccountSqlDAO
    {
        Account GetByLogin(string login);
        void Save(Account account);
    }
}
