using System;
using System.Configuration;
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

            //Variables
            bool should_automatically_close = StringToBool(configuration["automatically_close_terminal"].ToString());
            string browser_path = configuration["browser_path"].ToString();
            Messanger messanger = new Messanger();

            //Displays applications
            messanger.ColoredMessage("Displays applications", Messanger.Type.Title);
            foreach (DictionaryEntry a in applicationList)
                messanger.ColoredMessage("--> " + a.Key, Messanger.Type.Normal);

            //Run applications
            messanger.ColoredMessage("Run applications", Messanger.Type.Title);
            foreach (DictionaryEntry a in applicationList)
            {
                messanger.ColoredMessage("Running " + a.Key + "...", Messanger.Type.Normal);

                if (File.Exists(a.Value.ToString())) //Check if file exists
                {
                    var p = new Process();
                    p.StartInfo = new ProcessStartInfo((string)a.Value)
                    {
                        UseShellExecute = true
                    };
                    p.Start();
                }
                else
                    messanger.ColoredMessage("The file '" + a.Value + "' doesn't exist.", Messanger.Type.Error);
            }

            //Displays URL
            messanger.ColoredMessage("Displays URL", Messanger.Type.Title);
            foreach (DictionaryEntry u in urlList)
                messanger.ColoredMessage("--> " + u.Key, Messanger.Type.Normal);
            
            //Browse URL
            messanger.ColoredMessage("Browse URL", Messanger.Type.Title);
            foreach (DictionaryEntry u in urlList)
            {
                messanger.ColoredMessage("Browsing " + u.Key + "...", Messanger.Type.Normal);
                Process.Start(browser_path, (string)u.Value);
            }

            messanger.ColoredMessage("Completed", Messanger.Type.Title);
            if (!should_automatically_close)
            {
                messanger.ColoredMessage("Press a key to exit the program...", Messanger.Type.Normal);
                Console.ReadKey();
            }
        }

        private static bool StringToBool(string strB)
        {
            bool b;

            if (bool.TryParse(strB, out b))
                return b;
            else{
                Messanger messanger = new Messanger();
                messanger.ColoredMessage("Impossible to parse the value '" + strB + "'. You should check the App.Config : The variable 'should_automatically_close' is set to false in the meantime.", Messanger.Type.Error);
            }

            return false;
        }
    }
}             
