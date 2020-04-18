using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personnel_Management
{
    public class Sex
    {
        public int ID { get; set; }
        public string sex { get; set; }

        public Sex(int ID, string sex) {

            this.ID = ID;
            this.sex = sex;
        
        }

   

    }

}