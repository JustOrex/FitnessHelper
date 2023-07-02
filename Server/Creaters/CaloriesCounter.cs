using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessHelper
{
    internal class CaloriesCounter
    {
        

        public double BasicCaloriesPerDay { get; private set; }
        public CaloriesCounter(double _hieght, double _weight, double _activityRate, int _age, string _gender)
        {

            BasicCaloriesPerDay = CaloriesCount(_hieght, _weight, _activityRate, _age, _gender);

        }

       
        private static double CaloriesCount(double hieght, double weight, double activityRate, int age, string gender)
        {
            double calc = 0;
            if (gender == "man")
            {
                calc = (9.99 * weight) + (6.25 * hieght) - (4.92 * age) + 5;
                calc = calc * activityRate;

            }
            else if (gender == "women")
            {
                calc = (9.99 * weight) + (6.25 * hieght) - (4.92 * age) - 161;
                calc = calc * activityRate;

            }

            return calc;

        }

    }
}
