using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHelper
{
    internal class AccountCreater
    {
        private string name; 

        private string email;

        private string password;

        private string gender;

        private string typeOfDiet;

        private string typeOfTraining;

        private double height;

        private double weight;

        private double activityRate;

        private int age;

        private string date;

        public AccountCreater(string Name, string Password, string Email, double Hieght, double Weight, double ActivityRate, int Age, string Gender, string TypeOfDiet, string TypeOfTraining, string Date)
        {
            name = Name;
            password = Password;
            email = Email;
            height = Hieght;
            weight = Weight;
            activityRate = ActivityRate;
            age = Age;
            gender = Gender;
            typeOfDiet = TypeOfDiet;
            typeOfTraining = TypeOfTraining;
            date = Date;

        }


        private byte[] filedata;

        private double BasicCaloriesCounting(double height, double weight, double activityRate, int age, string gender)
        {
            var ws = new CaloriesCounter(height, weight, activityRate, age, gender);
            return ws.BasicCaloriesPerDay;
        }

        private string[] TrainingProgramm_creating(string gender, string type)
        {

            var tp = new TrainingProgrammCreater(gender, type);
            filedata = tp.trainingProgrammData;
            return tp.trainigpPogramm;

        }

        private byte[] WheightChengesDataCreating(double wheight, string date)
        {
            byte[] Data = Encoding.Unicode.GetBytes($"{date} - {wheight}kg");

            return Data;
        }

        private void creating()
        {
            double basicCalories = BasicCaloriesCounting(height, weight, activityRate, age, gender);

            string [] trainingProgramsData = TrainingProgramm_creating(gender, typeOfTraining);

            byte[] wheightChanges = WheightChengesDataCreating(weight, date);
            
            
            var creater = new TablesCreater();
            creater.AccountCreating(name, password, email, height, weight, activityRate, age, gender, typeOfDiet, basicCalories, trainingProgramsData[0], trainingProgramsData[1], filedata, wheightChanges);

        }

        public async Task account_creatingAsync()
        {
            await Task.Run(() =>
            {
                creating();
            });
        }




    }
}
