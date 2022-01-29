using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BotApp
{
    public class Log
    {
        //taken from YandereSaveEditor
        public static void info(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " INFO]: " + input + "\n");
            sw.Close();
        }
        public static void earning(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " WARNING]: " + input + "\n");
            sw.Close();
        }
        public static void error(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void fatal_error(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " FATAL ERROR]: " + input + "\n");
            sw.Close();
        }
        public static void debug(string input)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " DEBUG]: " + input + "\n");
            sw.Close();
        }
        public static void header()
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\App\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.WriteLine("---------- BEGIN LOG: " + time + " ----------");
            sw.Close();
        }
        public static void chat_log(string chat)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = "." + "\\Logs\\Chat\\" + date + ".log";
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.WriteLine($"[{time}]: {chat}");
            sw.Close();
        }
    }
}