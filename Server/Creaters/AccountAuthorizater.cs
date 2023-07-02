using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FitnessHelper
{
    internal class AccountAuthorizater
    {
        private string Name;
        public AccountAuthorizater(string Name)
        {
            this.Name = Name;
        }
        public int Id { get; private set; }

        private string Password;

        private string Email;

        private double height;

        private double weight;

        private double activityRate;

        private int age;

        private string gender;

        private string typeOfDiet;

        private double basicCalories;

        private byte[] FileWithTrainingProgrammData;

        private byte[] WheightChanges;

        public User User { get; private set; }     
        
        public string CreatingJSONstring()
        {
            GettingData();
            
            User user = CreatingUser();
            string SerStr = JsonConvert.SerializeObject(user);

            return SerStr;
        }

        private User CreatingUser()
        {
            User user = new User();
            user.Name = Name;
            user.Email = Email;
            user.Password = Password;
            user.height = height;
            user.weight = weight;
            user.activityRate = activityRate;
            user.age = age;
            user.gender = gender;
            user.typeOfDiet = typeOfDiet;
            user.basicCalories = basicCalories;
            user.FileWithTrainingProgrammData = FileWithTrainingProgrammData;
            user.WheightChanges = WheightChanges;

            User = user;

            return user;
        }

        private void GettingData()
        {

             SearchingUsersIDandDATA(Name);

             using (var context = new UsersContext())
             {
                SqlParameter param = new SqlParameter("@name", $"%{Id}%");
                
                var data = context.UsersData.FromSqlRaw("SELECT * FROM UsersData WHERE AccountID LIKE @name", param).OrderBy(x => x.AccountId == Id).ToList();
                
                height = data[0].Height;
                weight = data[0].Weight;
                activityRate = data[0].ActivityRate;
                age = data[0].Age;
                gender = data[0].Gender;
                typeOfDiet = data[0].TypeOfDiet;
                basicCalories = data[0].BasicСalories;
                WheightChanges = data[0].WheightChanges;

                var fileWithTrainingProgramm = context.FilesWithTrainingProgramms.FromSqlRaw("SELECT * FROM FilesWithTrainingProgramms WHERE AccountID LIKE @name", param).OrderBy(x => x.AccountId == Id).ToList();
                
                FileWithTrainingProgrammData = fileWithTrainingProgramm[0].FileData;


             }
        }

        private void SearchingUsersIDandDATA(string name)
        {
            
            using (var context = new UsersContext())
            {
                SqlParameter param = new SqlParameter("@name", $"%{name}%");
                var account = context.Accounts.FromSqlRaw("SELECT * FROM Accounts WHERE Name LIKE @name", param).OrderBy(x => x.Name == name).ToList();
                Email = account[0].Email;
                Password = account[0].Password;
                Id = account[0].Id;


                
            }
            
        }

        

       


    }
}
