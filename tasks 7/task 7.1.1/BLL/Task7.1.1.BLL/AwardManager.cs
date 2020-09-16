using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL
{
    public class AwardManager : IAwardManager
    {
        private readonly IUserDAO _userDAO;
        private readonly IAwardDAO _awardDAO;
        public AwardManager (IUserDAO userDAO, IAwardDAO awardDAO)
        {
            _userDAO = userDAO;
            _awardDAO = awardDAO;
        }

        public void Create(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                _awardDAO.Save(new Award(title));
            }
        }

        public void DeleteById(Guid id)
        {
            Award award = _awardDAO.GetById(id);
            if(award != null)
            {
                _awardDAO.DeleteById(id);
                foreach (var item in award.Users)
                {
                    var user = _userDAO.GetById(item.ID);
                    var temp = user.Awards.FindAll(i =>
                    {
                        if (i.ID != award.ID)
                            return true;
                        return false;
                    });
                    user.Awards.Clear();
                    user.Awards.AddRange(temp);
                    _userDAO.Save(user);
                }
            }
        }

        public IEnumerable<Award> GetAll()
        {
            return _awardDAO.GetAll();
        }
    }
}
