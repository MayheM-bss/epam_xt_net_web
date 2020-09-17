﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.BLL.Interfaces;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task7._1._1.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUserDAO _userDAO;
        private readonly IAwardDAO _awardDAO;
        public UserManager(IUserDAO userDAO, IAwardDAO awardDAO)
        {
            _userDAO = userDAO;
            _awardDAO = awardDAO;
        }
            
        public void AddAward(Guid userId, Guid awardId)
        {
            User user = _userDAO.GetById(userId);
            Award award = _awardDAO.GetById(awardId);
            if(user != null && award != null)
            {
                user.Awards.Add(award);
                award.Users.Add(user);
                _userDAO.Save(user);
                _awardDAO.Save(award);
            }
        }

        public void Create(string name, DateTime dateOfBirth)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                _userDAO.Save(new User(name, dateOfBirth));
            }
        }

        public void DeleteById(Guid id)
        {
            User user = _userDAO.GetById(id);
            if (user != null)
            {
                _userDAO.DeleteById(id);
                foreach (var item in user.Awards)
                {
                    var award = _awardDAO.GetById(item.ID);
                    var temp = award.Users.FindAll(i =>
                    {
                        if (i.ID != award.ID)
                            return true;
                        return false;
                    });
                    award.Users.Clear();
                    award.Users.AddRange(temp);
                    _awardDAO.Save(award);
                }
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userDAO.GetAll();
        }
    }
}
