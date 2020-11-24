using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

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
            foreach (DictionaryEntry d in applicationList)
            {
                Console.WriteLine("{0} : {1}", d.Key, d.Value);
                // -> Execute the application
            }

            //Get a urls list from the configuration file
            Hashtable urlList = (Hashtable)ConfigurationManager.GetSection("items/urls");

            //Display the application list
            Console.WriteLine("Display url list");
            foreach (DictionaryEntry d in urlList)
            {
                Console.WriteLine("{0} : {1}", d.Key, d.Value);
                // -> Browse the url
            }

            Console.ReadKey();
        }
    }
}
