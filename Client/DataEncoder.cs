using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Client
{
    internal class DataEncoder
    {


        public User GettingUsersData(string data)
        {
           
            User user = JsonConvert.DeserializeObject<User>(data);
          
            return user;
                       
        }

        
    }
}
