using System;
using System.Configuration;
using System.Collections.Specialized;

namespace TheGoodWorker_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Get a items list from the configuration file
            string ssAttr;
            ssAttr = ConfigurationManager.AppSettings.Get("data");

            Console.WriteLine("My Data : " + ssAttr);

            //Foreach configuration's items

            //If item is a application
            // --> Execute it

            //If item is a url
            // --> Browse it

            Console.ReadKey();
        }
    }
}
