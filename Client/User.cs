using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [Serializable]
    public class User
    {
        public int Id;

        public string Name;

        public string Password;

        public string Email;

        public double height;

        public double weight;

        public double activityRate;

        public int age;

        public string gender;

        public string typeOfDiet;

        public double basicCalories;

        public byte[] FileWithTrainingProgrammData;

        public byte[] WheightChanges;
    }


}
