﻿using System;
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
            //Get hastable lists
            Hashtable configuration = (Hashtable)ConfigurationManager.GetSection("items/applicationConfiguration");
            Hashtable applicationList = (Hashtable)ConfigurationManager.GetSection("items/applications");
            Hashtable urlList = (Hashtable)ConfigurationManager.GetSection("items/urls");

            //Set configuration varaibles
            bool should_automatically_close = StringToBool(configuration["should_automatically_close"].ToString());
            string browser_path = configuration["browser_path"].ToString();
            Messanger messager = new Messanger();

            //Tests
            messager.ColoredMessage("This is my title ;D", Messanger.Type.Title);
            messager.ColoredMessage("Error Error !", Messanger.Type.Error);
            messager.ColoredMessage("My normal text", Messanger.Type.Normal);



            //Display the application list

            messager.ColoredMessage("Display applications", Messanger.Type.Title);
            foreach (DictionaryEntry a in applicationList)
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

            //Display the application list
            Console.WriteLine("Display url list");
            foreach (DictionaryEntry u in urlList)
            {
                Console.WriteLine("{0} : {1}", u.Key, u.Value);
                // -> Browse the url
                Console.WriteLine("Launching {0}...", u.Key);

                Process.Start(browser_path, (string)u.Value);
            }

            Console.WriteLine(configuration["should_automatically_close"]);
            Console.WriteLine("Done ! :D");

            if(!should_automatically_close)
                Console.ReadKey();
        }

        private static bool StringToBool(string strB)
        {
            bool b;
            if (bool.TryParse(strB, out b))
                return b;

            Console.WriteLine("[Error] Impossible to parse the value " + strB + ". You should to check the App.Config ! The variable 'should_automatically_close' is set to false in the meantime."); 
            return false;
        }
    }
}             
