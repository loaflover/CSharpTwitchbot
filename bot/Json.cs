using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace BotApp
{
    //ported from Yandere Simulator JSON editor, how the fuck a made a thing meant for editing Students.JSON work with this app is beyond me.
    public static class json_edit
    {
        public static json get_info()
        {
            try
            {
                string line = File.ReadAllText(globals.config_path);
                json tempstudent = JsonConvert.DeserializeObject<json>(line);
                return tempstudent;
            }
            catch (Exception e)
            {
                json tempstudent = new json();
                //returns error as string
                Log.error("Error while getting student JSON:" + e.ToString());
                return tempstudent;
            }
        }
        public static string WriteInfo(json tempjson)
        {
            try
            {
                string Json = JsonConvert.SerializeObject(tempjson);
                string[] arrLine = File.ReadAllLines(globals.config_path);
                return "success";

            }
            catch (Exception e)
            {
                //returns error as string
                Log.error("Error while writing JSON:" + e.ToString());
                return "failed: got to horny jail *bonk*";
            }
        }
    }
}



public class json
{
    //DO NOT CHANGE THE ORDER OF THE STATEMENTS. I WILL BREAK YOU BACK
    public string Command { get; set; }
}