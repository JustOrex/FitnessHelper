using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Net.Sockets;
using System.Net;

namespace FitnessHelper
{
    internal class DataFilter
    {
        

        public string TakingData(string data)
        {
            string state = DataFiltering(data);
            
            return state;
        }



        private DataManager dm = new DataManager();

        private User user;

        private string DataFiltering(string data)
        {
            bool check = false;

            string ret = "";
            
            while (true)
            {
                if (data == "END")
                {
                    ret = "END";

                    return ret;
                }

                if (data.Last() == '1')
                {
                    data = data.Remove(data.Length - 1);             
                    
                    dm.operation = data;

                    check = true;
                    break;

                }

                if (data.Last() == '2')
                {
                    data = data.Remove(data.Length - 1);

                    check = DataCheckingForName(data);  
                    
                    
                    break;
                }

                if (data.Last() == '3')
                {
                    data = data.Remove(data.Length - 1);

                    check = DataCheckingForEmail(data);

                    break;

                }

                if (data.Last() == '4')
                {
                    data = data.Remove(data.Length - 1);

                    check = DataCheckingForPassword(data);

                    break;

                }

                if (data.Last() == '5')
                {
                    data = data.Remove(data.Length - 1);

                    dm.gender = data;

                    check = true;
                    break;
                }

                if (data.Last() == '6')
                {
                    data = data.Remove(data.Length - 1);

                    dm.typeOfDiet = data;

                    check = true;
                    break;
                }

                if (data.Last() == '7')
                {
                    data = data.Remove(data.Length - 1);

                    dm.typeOfTraining = data;

                    check = true;
                    break;
                }

                if (data.Last() == '8')
                {
                    data = data.Remove(data.Length - 1);

                    if (double.TryParse(data, out double value))
                    {
                        dm.height = value;
                        check = true;
                    }

                    break;
                }

                if (data.Last() == '9')
                {
                    data = data.Remove(data.Length - 1);

                    if (double.TryParse(data, out double value))
                    {
                        dm.weight = value;
                        check = true;
                    }

                    break;
                }

                if (data.Last() == 'a')
                {
                    data = data.Remove(data.Length - 1);

                    if (double.TryParse(data, out double value))
                    {
                        dm.activityRate = value;
                        check = true;
                    }

                    break;
                }

                if (data.Last() == 'b')
                {
                    data = data.Remove(data.Length - 1);

                    if (int.TryParse(data, out int value))
                    {
                        dm.age = value;
                        check = true;
                    }
                    
                    break;
                }

                if(data.Last() == 'c')
                {
                    data = data.Remove(data.Length - 1);

                    check = DataCheckingForCode(data);

                    break;
                }
                
                if(data.Last() == '0')
                {
                    data = data.Remove(data.Length - 1);

                    dm.date = data;

                    break;
                }

                
                if(data == "getData#")
                {    

                    ret = dm.AuthorizeAccount();

                    user = dm.user;

                    return ret;

                }

                if(data == "createAccount#")
                {
                    dm.CreatAccount();

                    ret = "true";

                    return ret;
                }

                if(data.Last() == '!')
                {
                    data = data.Remove(data.Length - 1);
                    
                    var dc = new DataChenger(dm.UserID);

                    dm.operation = "chengingData";

                    
                    
                    if(data.Last() == '2')
                    {
                        data = data.Remove(data.Length - 1);

                        check = DataCheckingForName(data);

                        if(check == true)
                        {
                            dc.ChangeName(dm.name);
                        }


                        break;
                    }

                    if (data.Last() == '3')
                    {
                        data = data.Remove(data.Length - 1);

                        check = DataCheckingForEmail(data);

                        dm.email = data;

                        break;
                    }

                    if (data.Last() == '4')
                    {
                        data = data.Remove(data.Length - 1);

                        dm.password = data;

                        dc.ChangePassword(data);

                        break;
                    }

                    if (data.Last() == '8')
                    {
                        data = data.Remove(data.Length - 1);

                        if (double.TryParse(data, out double value))
                        {
                            dm.height = value;
                            dc.ChangeHeight(value);
                            check = true;
                        }

                        break;
                    }

                    if (data.Last() == '9')
                    {
                        data = data.Remove(data.Length - 1);

                        if (double.TryParse(data, out double value))
                        {
                            dm.weight = value;
                            dc.ChangeWeight(value);
                            check = true;
                        }

                        break;
                    }

                    if (data.Last() == '5')
                    {
                        data = data.Remove(data.Length - 1);

                        dm.gender = data;

                        dc.ChangeGender(data);

                        check = true;
                        break;
                    }

                    if (data.Last() == '6')
                    {
                        data = data.Remove(data.Length - 1);

                        dm.typeOfDiet = data;

                        dc.ChangeTypeOfDiet(data);

                        check = true;
                        break;
                    }

                    if (data.Last() == '7')
                    {
                        data = data.Remove(data.Length - 1);

                        dm.typeOfTraining = data;

                        var tpc = new TrainingProgrammCreater(user.gender, data);

                        dc.ChangeTrainingProgramm(tpc.trainingProgrammData,tpc.trainigpPogramm[0],tpc.trainigpPogramm[1]); 
                        
                        check = true;
                        
                        break;
                    }

                    if (data.Last() == '0')
                    {
                        data = data.Remove(data.Length - 1);

                        dm.date = data;

                        dc.ChangeWheightChanges(data);

                        check = true;

                        break;
                    }

                    if (data.Last() == 'a')
                    {
                        data = data.Remove(data.Length - 1);

                        if (double.TryParse(data, out double value))
                        {
                            dm.activityRate = value;
                            dc.ChangeActivityRate(value);
                            check = true;
                        }

                        break;
                    }

                    if (data.Last() == 'b')
                    {
                        data = data.Remove(data.Length - 1);

                        if (int.TryParse(data, out int value))
                        {
                            dm.age = value;
                            dc.ChangeAge(value);
                            check = true;
                        }

                        break;
                    }

                    if (data.Last() == 'c')
                    {
                        data = data.Remove(data.Length - 1);

                        check = DataCheckingForCode(data);
                        if(check == true)
                        {
                            dc.ChangeEmail(dm.email);
                        }

                        break;
                    }

                }
                
                
            }
            
            
            if (check == true)
            {
                ret = "true";
            }
            else if (check == false)
            {                   
                ret = "false";
            }
            
            
            return ret;
        }

        private bool DataCheckingForName(string data)
        {
            var datachecker = new CheckerForData();
            bool check = false;
            if (dm.operation == "authorization")
            {

                bool result = datachecker.DataCkeckingForNameOnAuthorisation(data);

                if (result == true)
                {
                    dm.name = data;
                    check = true;

                }
                else if (result == false)
                {

                    check = false;


                }
            }
            else if (dm.operation == "registration")
            {

                bool result = datachecker.DataCheckingForNameOnRegistration(data);
                if (result == true)
                {
                    dm.name = data;
                    check = true;

                }
                else
                {
                    check = false;

                }
            }
            else if (dm.operation == "chengingData")
            {
                bool result = datachecker.DataCheckingForNameOnRegistration(data);
                if (result == true)
                {
                    dm.name = data;
                    check = true;

                }
                else
                {
                    check = false;

                }
            }

            return check;
        }

        private bool DataCheckingForEmail(string data)
        {
            var datachecker = new CheckerForData();
            bool check = false;
            if (dm.operation == "authorization")
            {
                

                bool result = datachecker.DataCkeckingForEmailOnAuthorisation(dm.name, data);

                if (result == true)
                {
                    var es = new EmailSender(data, "Authorization");

                    dm.codeOfRedANDAuth = es.Code;
                    dm.email = data;
                    check = true;

                }
                else if (result == false)
                {

                    check = false;


                }
            }
            else if (dm.operation == "registration")
            {

                bool result = datachecker.DataCheckingForEmailOnRegistration(data);
                if (result == true)
                {

                    var es = new EmailSender(data, "Registration");

                    
                        dm.email = data;
                        dm.codeOfRedANDAuth = es.Code;
                        check = true;

                }
                else
                {
                    check = false;

                }
            }
            else if (dm.operation == "chengingData")
            {
                

                bool result = datachecker.DataCheckingForEmailOnRegistration(data);
                if (result == true)
                {

                    var es = new EmailSender(data, "Registration");


                    dm.codeOfRedANDAuth = es.Code;
                    check = true;

                }
                else
                {
                    check = false;

                }
            }

            return check;
        }

        private bool DataCheckingForPassword(string data)
        {
            var datachecker = new CheckerForData();
            bool check = false;
            if (dm.operation == "authorization")
            {
                
                bool result = datachecker.DataCkeckingForPasswordOnAuthorisation(dm.email, data);

                if (result == true)
                {
                    dm.password = data;
                    check = true;

                }
                else if (result == false)
                {
                    check = false;

                }
            }
            else if (dm.operation == "chengingData")
            {
                bool result = datachecker.DataCkeckingForPasswordOnAuthorisation(dm.email, data);

                if (result == true)
                {

                    check = true;

                }
                else if (result == false)
                {
                    check = false;

                }
            }
            else
            {
                dm.password = data;

                check = true;

            }

            return check;
        }

        private bool DataCheckingForCode(string data)
        {
            bool check = false;

            if(dm.codeOfRedANDAuth == data)
            {
                check = true;
            }

            return check;
        }



        

        







    }
}
