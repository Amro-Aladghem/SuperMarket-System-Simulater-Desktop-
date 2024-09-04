using BuesineesLyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Market_Project
{
    public static class LoggedInUser
    {
        public enum eOperationType { Add = 1, Update = 2, Delete = 3, AddUser = 4, UpdateUser = 5, DeleteUser = 6, EnteringSystem = 7 }


        public static clsUsers LogedInUser = null;

        public static clsUsers SetLoggedUser
        {
            get { return LogedInUser; }

            set { LogedInUser = value; }
        }
           
           

        public static  void ButLoggedInUser(clsUsers User)
        {
            
                LogedInUser = User;
            
        }

        
        








    }

}
