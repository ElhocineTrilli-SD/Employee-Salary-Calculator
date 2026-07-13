using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer
{
    public class GlobalClass
    {
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\Software\EMS";

            string UserNameTitel = "UserName";
            string UserNameData = Username;
            string PasswordTitel = "Password";
            string PasswordData = Password;

            try
            {
                Registry.SetValue(KeyPath, UserNameTitel, UserNameData, RegistryValueKind.String);
                Registry.SetValue(KeyPath, PasswordTitel, PasswordData, RegistryValueKind.String);

                return true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string keyPath = @"HKEY_CURRENT_USER\Software\EMS";
            string PasswordTitel = "Password";
            string UserNameTitel = "UserName";

            try
            {
                Username = Registry.GetValue(keyPath, UserNameTitel, null) as string;
                Password = Registry.GetValue(keyPath, PasswordTitel, null) as string;
                return true;

            }
            catch (Exception ex)
            {
               // MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }
}
