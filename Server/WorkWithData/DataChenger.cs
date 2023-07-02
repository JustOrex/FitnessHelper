using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace FitnessHelper
{
    internal class DataChenger
    {

        private int id;

        public DataChenger(int _id)
        {
            id = _id;
        }

        public void ChangeName(string name)
        {          
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Id LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Name = name;

                context.Accounts.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeEmail(string email)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Id LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Email = email;

                context.Accounts.Update(data[0]);

                context.SaveChanges();
            }

        }

        public void ChangePassword(string password)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE id LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Password = password;

                context.Accounts.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeHeight(double height)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Height = height;

                ChangeCalories(data[0]);

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeWeight(double weight)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Weight = weight;

                ChangeCalories(data[0]);

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }
        
        public void ChangeGender(string gender)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Gender = gender;

                ChangeCalories(data[0]);

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeAge(int age)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].Age = age;

                ChangeCalories(data[0]);

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeActivityRate(double activityRate)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].ActivityRate = activityRate;

                ChangeCalories(data[0]);

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeTypeOfDiet(string typeOfDiet)
        {
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].TypeOfDiet = typeOfDiet;

                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeTrainingProgramm(byte[] dat, string title, string filename)
        {
            using(var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.FilesWithTrainingProgramms.FromSqlRaw("SELECT * FROM FilesWithTrainingProgramms WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                data[0].FileData = dat;

                data[0].Title = title;

                data[0].FileName = filename;

                context.FilesWithTrainingProgramms.Update(data[0]);

                context.SaveChanges();
            }
        }

        public void ChangeWheightChanges(string date)
        {

            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{id}%");

                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.Id == id).ToList();

                double wheight = data[0].Weight;

                string a = Encoding.Unicode.GetString(data[0].WheightChanges);

                byte[] change = Encoding.Unicode.GetBytes(a + $"\n{date} - {wheight}kg");

                data[0].WheightChanges = change;
                
                context.UsersData.Update(data[0]);

                context.SaveChanges();
            }
        }

            
        private void ChangeCalories(UsersDatum user)
        {
            double calc = CaloriesCount(user.Height, user.Weight, user.ActivityRate, user.Age, user.Gender);

            user.BasicСalories = calc;
        }
        private double CaloriesCount( double hieght, double weight, double activityRate, int age, string gender)
        {
            var cc = new CaloriesCounter(hieght, weight, activityRate, age, gender);

            double calc = cc.BasicCaloriesPerDay;
            
            return calc;
        }
    }
}
