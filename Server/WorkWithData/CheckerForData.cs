using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace FitnessHelper
{
    internal class CheckerForData
    {

        public bool DataCheckingForEmailOnRegistration(string email)
        {
            bool result;

            using(var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{email}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Email LIKE @name", param).OrderBy(x => x.Email == email).ToList();
                if(account.Count == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
                
            }

            return result;
        }

        public bool DataCheckingForNameOnRegistration(string name)
        {
            bool result;

            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{name}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Name LIKE @name", param).OrderBy(x => x.Name == name).ToList();
                if (account.Count == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }



        public bool DataCkeckingForNameOnAuthorisation(string name)
        {
            bool result;

            using(var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{name}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Name LIKE @name", param).OrderBy(x => x.Name == name).ToList();

                if(account.Count == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }

        public bool DataCkeckingForEmailOnAuthorisation(string name, string email)
        {
            bool result;

            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{name}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Name LIKE @name", param).OrderBy(x => x.Name == name).ToList();

                if (account.Count == 0)
                {
                    result = false;
                }
                else
                {
                    if (account[0].Email == email)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool DataCkeckingForPasswordOnAuthorisation(string email, string password)
        {
            bool result;

            using (var context = new UsersContext())
            {

                SqlParameter paramEmail = new SqlParameter("@name", $"%{email}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Email LIKE @name", paramEmail).OrderBy(x => x.Email == email).ToList();

                if (account [0].Password == password)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }







    }
}
