using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL.Interfaces
{
    public interface IAwardManager
    {
        void Create(string title);
        void DeleteById(Guid id);
        IEnumerable<Award> GetAll();
        void Edit(Guid id, string newTitle);
    }
}
