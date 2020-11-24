using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;

namespace TheGoodWorker_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get a application list from the configuration file
            Hashtable applicationList = (Hashtable)ConfigurationManager.GetSection("items/applications");

            //Display the application list
            Console.WriteLine("Display application list");
            foreach (DictionaryEntry a in    applicationList)
            {
                Console.WriteLine("{0} : {1}", a.Key, a.Value);
                // -> Execute the application
                Console.WriteLine("Launching {0}...", a.Key);
                var p = new Process();
                p.StartInfo = new ProcessStartInfo((string)a.Value)
                {
                    UseShellExecute = true
                };
                p.Start();
            }

            //Get a urls list from the configuration file
            Hashtable urlList = (Hashtable)ConfigurationManager.GetSection("items/urls");

            //Display the application list
            Console.WriteLine("Display url list");
            foreach (DictionaryEntry u in urlList)
            {
                Console.WriteLine("{0} : {1}", u.Key, u.Value);
                // -> Browse the url

                
            }
            Console.ReadKey();
        }
    }
}
