using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer;

namespace BuesineesLyer
{
    public  class clsEmployees
    {

        enum eMode { AddNew=1,Update=2 }
        eMode Mode =eMode.AddNew;
       
        public int EmployeeId {  get; set; }    
       public string  FirstName { get; set; }

        public string SecoundName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Salary { get; set; }
        public DateTime DateOfSet { get; set; }
        

        public clsEmployees()
        {
            EmployeeId = -1;
            FirstName = string.Empty;   
            LastName = string.Empty;
            SecoundName = string.Empty;
            DateOfBirth = DateTime.Now;
            DateOfSet=DateTime.Now;
            Salary = 0;
            Mode = eMode.AddNew;
        }
        public clsEmployees(int EmployeeeId,string FirstName,string SecoundName,string LastName,DateTime DateOfBirth,double Salary,DateTime DateOfSet)
        {
            this.EmployeeId = EmployeeeId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SecoundName = SecoundName;
            this.DateOfBirth = DateOfBirth;
            this.DateOfSet = DateOfSet;
            this.Salary = Salary;
            Mode = eMode.Update;
        }


        public static bool DeleteEmployee(int EmployeeID)
        {
            if (clsEmployeeData.DeleteRecord(EmployeeID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static  bool   isExist(int EmployeeID)
        {
            return clsEmployeeData.isExsits(EmployeeID);
        }

        public static DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllRecord();
        }


        public static clsEmployees FindEmployeeByID(int EmployeeID)
        {
            string FirstName = "", SecoundName = "", LastName = "";
            double Salary = 0;
            DateTime DateOfBirth = DateTime.Now, DateOfSet = DateTime.Now;
            if (clsEmployeeData.GetFullRecordByID(EmployeeID, ref FirstName, ref SecoundName, ref LastName, ref DateOfBirth, ref Salary, ref DateOfSet))
            {
                return new clsEmployees(EmployeeID, FirstName, SecoundName, LastName, DateOfBirth, Salary, DateOfSet);
            }
            else
            {
                return null;
            }
        }

        public static clsEmployees FindEmployeeByName(string EmployeeName)      
        {
            int EmployeeID = 0;
            string  SecoundName = "", LastName = "";
            double Salary = 0;
            DateTime DateOfBirth = DateTime.Now, DateOfSet = DateTime.Now;
            if (clsEmployeeData.GetFullRecordByFirstName(ref EmployeeID, EmployeeName, ref SecoundName, ref LastName, ref DateOfBirth, ref Salary, ref DateOfSet))
            {
                return new clsEmployees( EmployeeID, EmployeeName, SecoundName, LastName, DateOfBirth, Salary, DateOfSet);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewEmployee()
        {
            this.EmployeeId = clsEmployeeData.AddNewRecord(this.FirstName, this.SecoundName, this.LastName, this.DateOfBirth, this.Salary, this.DateOfSet);
            return EmployeeId != -1;
        }

        private  bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateRecord(this.EmployeeId,this.FirstName,this.SecoundName,this.LastName,this.DateOfBirth,this.Salary,this.DateOfSet);
        }

  
        public bool Save()
        {

            switch(Mode)
            {

                case eMode.AddNew:
                    {
                        if (_AddNewEmployee())
                        {
                            Mode = eMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                case eMode.Update:
                    {
                        if(_UpdateEmployee())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    return false;










            }






        }


      





     
       











    }
}
