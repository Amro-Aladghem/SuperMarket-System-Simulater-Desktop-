using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuesineesLyer
{


    public class clsApplication
    {
        public static void AddNewApplicationToSystem(int ApplicationTypeID, DateTime DateOfApplication, int? ProductID, int? vegAndfruitId, int? OfferID, int UserID)
        {
            clsApplicationData.AddNewApplication(ApplicationTypeID, DateOfApplication, ProductID, vegAndfruitId, OfferID, UserID);
        }

        public static DataTable GetAllApplicationRecord()
        {
            return clsApplicationData.GetAllRecord();
        }



    }






}
