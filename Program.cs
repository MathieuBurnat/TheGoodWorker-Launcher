using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;
using System.IO;

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

            //Displays differents applications
            messager.ColoredMessage("Displays applications", Messanger.Type.Title);
            foreach (DictionaryEntry a in applicationList)
                messager.ColoredMessage("--> " + a.Key, Messanger.Type.Normal);

            //Run applications
            messager.ColoredMessage("Run applications", Messanger.Type.Title);
            foreach (DictionaryEntry a in applicationList)
            {
                messager.ColoredMessage("Running " + a.Key + "...", Messanger.Type.Normal);

                if (File.Exists(a.Value.ToString()))
                {
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo((string)a.Value)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
                else
                    messager.ColoredMessage("The file '" + a.Value + "' doesn't exist.", Messanger.Type.Error);
            }

            //Displays differents applications
            messager.ColoredMessage("Displays URL", Messanger.Type.Title);
            foreach (DictionaryEntry u in urlList)
                messager.ColoredMessage("--> " + u.Key, Messanger.Type.Normal);
            
            //Browse URL
            messager.ColoredMessage("Run applications", Messanger.Type.Title);
            foreach (DictionaryEntry u in urlList)
            {
                messager.ColoredMessage("Browsing " + u.Key + "...", Messanger.Type.Normal);
                Process.Start(browser_path, (string)u.Value);
            }

            messager.ColoredMessage("Completed", Messanger.Type.Title);

            if (!should_automatically_close)
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
