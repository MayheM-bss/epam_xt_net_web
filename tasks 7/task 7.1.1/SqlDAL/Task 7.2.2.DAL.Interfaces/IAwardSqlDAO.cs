using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task_7._2._2.DAL.Interfaces
{
    public interface IAwardSqlDAO
    {
        void Save(Award award);
        void DeleteById(Guid id);
        IEnumerable<Award> GetAll();
        Award GetById(Guid id);
    }
}
