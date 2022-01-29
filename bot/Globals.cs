using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApp
{
    internal class globals
    {
        public static string token
        {
            get
            {
                return registry.get_config_option("token", "0");
            }
            set
            {
                registry.set_config_option("token", value);
            }
        }
        public static string config_path
        {
            get
            {
                return registry.get_config_option("config_path", ".\\config.json");
            }
            set
            {
                registry.set_config_option("config_path", value);
            }
        }
    }
}
