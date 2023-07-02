using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHelper
{
    internal class TablesCreater
    {


        public void AccountCreating(string Name, string Password, string Email, double height, double weight, double activityRate, int age, string gender, string typeOfDiet, double basicСalories, string title, string fileName, byte[] fileData, byte[] wheightChanges)
        {
            using (var context = new UsersContext())
            {
                var account = new Account();
                {

                    account.Name = Name;
                    account.Password = Password;
                    account.Email = Email;

                }

                context.Accounts.Add(account);
                context.SaveChanges();
               
                var UserData = new UsersDatum();
                {

                    UserData.Height = height;
                    UserData.Weight = weight;
                    UserData.ActivityRate = activityRate;
                    UserData.Age = age;
                    UserData.Gender = gender;
                    UserData.TypeOfDiet = typeOfDiet;
                    UserData.BasicСalories = basicСalories;
                    UserData.WheightChanges = wheightChanges;
                    UserData.Account = account;
                    


                }

                context.UsersData.Add(UserData);
                context.SaveChanges();

               
                
                var file = new FilesWithTrainingProgramm()
                {
                    Title = title,
                    FileName = fileName,
                    FileData = fileData,
                    Account = account
                    
                };

                context.FilesWithTrainingProgramms.Add(file);
                context.SaveChanges();
                
            }
            

        }
    }
}
