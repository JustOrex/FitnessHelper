using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHelper
{
    internal class DataManager
    {
        public string operation { get; set; } //1

        public string name { get; set; } // 2

        public string email { get; set; } // 3

        public string password { get; set; } // 4

        public string gender { get; set; } // 5

        public string typeOfDiet { get; set; } // 6

        public string typeOfTraining { get; set; } // 7

        public double height { get; set; } // 8

        public double weight { get; set; } // 9

        public double activityRate { get; set; } // a

        public int age { get; set; } // b

        public string date { get; set; } //0


        public User user {get; private set; }

        public int UserID { get; private set; }

        public string codeOfRedANDAuth { get; set; }







        public string AuthorizeAccount()
        {
            var aa = new AccountAuthorizater(name);

            string acDataJSON = aa.CreatingJSONstring();

            user = aa.User;

            UserID = aa.Id;

            return acDataJSON;
        }
        public void CreatAccount()
        {
            var ac = new AccountCreater(name, password, email, height, weight, activityRate, age, gender, typeOfDiet, typeOfTraining, date);
            ac.account_creatingAsync();
        }


    }
}
