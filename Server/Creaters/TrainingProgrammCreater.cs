using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitnessHelper
{
    internal class TrainingProgrammCreater
    {

        public string[] trainigpPogramm { get; private set; }

        public byte[] trainingProgrammData { get; private set; }

        public TrainingProgrammCreater(string gender, string type)
        {
            
            trainigpPogramm = CreateTrainingProgramm(gender, type);

        }

       
        
        
        


        private string[] CreateTrainingProgramm(string gender, string type)
        {
            byte[] fileData;
            string title = "";
            string way = "";
            if(gender == "man")
            {
                if (type == "split")
                {
                    way = @"C:\Users\МЫ\source\repos\FitnessHelper\FitnessHelper\bin\Debug\net6.0\TForManSplit.txt";
                    title = "Тренировка для мужчины, Сплит";
                }
                else if (type == "fullbody")
                {
                    way = @"C:\Users\МЫ\source\repos\FitnessHelper\FitnessHelper\bin\Debug\net6.0\TForManFullBody.txt";
                    title = "Тренировка для мужчины, Фулбади";
                }
            }

            if(gender == "women")
            {
                if (type == "split")
                {
                    way = @"C:\Users\МЫ\source\repos\FitnessHelper\FitnessHelper\bin\Debug\net6.0\TForWomenSplit.txt";
                    title = "Тренировка для женщины, Сплит";
                }
                else if (type == "fullbody")
                {
                    way = @"C:\Users\МЫ\source\repos\FitnessHelper\FitnessHelper\bin\Debug\net6.0\TForWomenFullBody.txt";
                    title = "Тренировка для женщины, Фулбади";
                }
            }

            using (FileStream fs = new FileStream(way, FileMode.Open))
            {
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
                fs.Close();
            
            }

            string shortfileName = way.Substring(way.LastIndexOf('\\') + 1);
            
            trainingProgrammData = fileData;
            
            string[] result = new string[2] {title, shortfileName};
            return result;

        }
        
    }

}
