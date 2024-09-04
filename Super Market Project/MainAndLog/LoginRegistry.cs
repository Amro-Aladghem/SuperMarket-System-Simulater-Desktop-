using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Super_Market_Project
{
    public class LoginRegistry
    {

        private static string KeyPath= @"HKEY_CURRENT_USER\SOFTWARE\LoginUserSup";

        private static string SubKeyPath = @"SOFTWARE\LoginUserSup";

        public static string UserName = "UserName";
        public static string UserNameData { get; set; }

        public static string Password = "Password";
        public static string PasswordData { get; set;}
        

        public static void SetDataToRegsetry(string UserNameData,string PasswordData)
        {
            try
            {

                Registry.SetValue(KeyPath, UserName, UserNameData, RegistryValueKind.String);
                Registry.SetValue(KeyPath,Password,PasswordData,RegistryValueKind.String);

            }
            catch
            {
                Console.WriteLine("Somthing Error!");

            }

        }

        public static void GetDataFromRegsetry(ref string UserNameData,ref string PasswordData)
        {

            try
            {
                UserNameData = Registry.GetValue(KeyPath, UserName, null) as string;
                PasswordData= Registry.GetValue(KeyPath, Password,null) as string;

            }
            catch
            {
                Console.WriteLine("Somthing Error!");
            }
        }

        public static void DeleteDataFromRegsetry()
        {


            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(SubKeyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(UserName);
                            key.DeleteValue(Password);


                            Console.WriteLine($"Successfully deleted value '{UserName}' from registry key '{KeyPath}'");
                        }
                        else
                        {
                            Console.WriteLine($"Registry key '{KeyPath}' not found");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }



    }
}
