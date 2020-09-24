using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_7._2._2.DAL.Interfaces;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL
{
    public class AwardManager : IAwardManager
    {
        private readonly IUserSqlDAO _userDAO;
        private readonly IAwardSqlDAO _awardDAO;
        public AwardManager(IUserSqlDAO userDAO, IAwardSqlDAO awardDAO)
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
            if (award != null)
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

        public void Edit(Guid id, string newTitle)
        {
            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                Award award = _awardDAO.GetById(id);
                if (award != null)
                {
                    Award newAward = new Award(id, newTitle, award.Users);
                    _awardDAO.Save(newAward);
                    foreach (var item in award.Users)
                    {
                        var user = _userDAO.GetById(item.ID);
                        for (int i = 0; i < user.Awards.Count; i++)
                        {
                            if (user.Awards[i].ID == award.ID)
                            {
                                user.Awards[i] = newAward;
                            }
                        }
                        _userDAO.Save(user);
                    }
                }
            }
        }
    }
}
