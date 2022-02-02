using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace BotApp
{
    internal class registry
    {
        public static string get_config_option(string name, string defaultvalue)
        {
            //checks if a value with that name exists, if no, make a new one with a default value
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\Loaflover\\TwitchBot");
            if(reg == null)
            {
                Registry.CurrentUser.CreateSubKey("\\SOFTWARE\\Loaflover\\TwitchBot");
            }
            if (!reg.GetValueNames().Contains(name))
            {
                reg.SetValue(name, defaultvalue);
                return defaultvalue;
            }
            else
            {
                return reg.GetValue(name).ToString();
            }
        }
        public static void set_config_option(string name, string value)
        {
            //sets a config value
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\Loaflover\\TwitchBot");
            if (reg == null)
            {
                Registry.CurrentUser.CreateSubKey("\\SOFTWARE\\Loaflover\\TwitchBot");
            }
            reg.SetValue(name, value);
        }
        public static void delete_all_data()
        {
            //deletes everything from the registry regarding this application, used for uninstalls
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("\\SOFTWARE\\Loaflover\\");
            reg.DeleteSubKey("TwitchBot");
        }
    }
}
