using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace task_7._1._2_UI.Models
{
    public class Task_7_2_1_RoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string username)
        {

            if (Dependencies.AccountManager.GetRole(username).Equals("admin"))
            {
                return new string[] { "admin" };
            }
            else if (Dependencies.AccountManager.GetRole(username).Equals("user"))
            {
                return new string[] { "user" };
            }
            else
            {
                return new string[] { "guest" };
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (roleName == Dependencies.AccountManager.GetRole(username))
            {
                return true;
            }
            return false;
        }


        #region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }



        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}