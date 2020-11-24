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
            //Get a items list from the configuration file
            Hashtable applicationList = (Hashtable)ConfigurationManager.GetSection("items/applications");

            //Display the application list
            foreach (DictionaryEntry d in applicationList)
            {
                Console.WriteLine("{0} ; {1}", d.Key, d.Value);
            }

            //Foreach configuration's items

            //If item is a application
            // --> Execute it

            //If item is a url
            // --> Browse it

            Console.ReadKey();
        }
    }
}
