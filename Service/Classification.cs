using Classifacation.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifacation.Service
{
    public class Classification
    {
        private Classification() { }

        private static Classification _instance;

        private static readonly object _lock = new object();

        public static Classification GetInstance()
        {
            if (_instance == null)
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Classification();
                    }
                }
            }
            return _instance;
        }
        public void pullAndClassification(string s, string d)
        {
            var log = Log.GetInstance();
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(s);
                string dir = Path.Combine(fileName.Split('_'));
                string dest = Path.Combine(d, dir);
                Directory.CreateDirectory(dest);
                dest = Path.Combine(dest, Path.GetFileName(s));

                //if (File.Exists(dest))
                //{
                //    File.Delete(s);
                //}
                //else
                //{
                File.Move(s, dest);
                log.LogToFile("Move File, " + s + " ,to " + dest + " ,at " + DateTime.Now);
                log.LogToDataBase("Move", "Move File " + s + " to " + dest);
                //}
            }
            catch (Exception ex)
            {
                log.LogToFile(ex.Message);
            }
        }
    }
}
