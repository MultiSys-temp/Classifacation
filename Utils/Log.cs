using Classifacation.Context;
using Classifacation.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classifacation.Utils
{
    public class Log
    {
        private Log() { }

        private static Log _instance;

        private static readonly object _lock = new object();

        public static Log GetInstance()
        {
            if (_instance == null)
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Log();
                    }
                }
            }
            return _instance;
        }

        public void LogToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Files";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Files\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        public  void LogToDataBase(string name="test", string Desc="test")
        {
            using (var db = new TestContext())
            {
                var ev = new Event()
                {
                    eventName = name,
                    eventnDesc = Desc,
                    eventDate = DateTime.Now
                };
                db.Events.Add(ev);
                db.SaveChanges();
            }
        }
    }
}
