using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task7._1._1.DAL.Interfaces
{
    public interface IAwardDAO
    {
        void Save(Award award);
        void DeleteById(Guid id);
        IEnumerable<Award> GetAll();
        Award GetById(Guid id);
    }
}
