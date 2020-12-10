using System;

namespace TheGoodWorker_Launcher
{
    internal class Messanger
    {
        //Create color variables
        private ConsoleColor title = ConsoleColor.Yellow;
        private ConsoleColor error = ConsoleColor.Red;
        private ConsoleColor normal = ConsoleColor.Gray;

        internal void ColoredMessage(string message, Type type)
        {
            switch (type)
            {
                case Type.Error: //Write error with red color
                    Console.ForegroundColor = error;
                    Console.WriteLine("\n[Error] {0}\n", message);
                    break;
                case Type.Title: //Write title
                    Console.ForegroundColor = title;
                    Console.WriteLine("\n\n** [ {0} ] **\n", message);
                    break;
                case Type.Normal: //Normal Text
                    Console.ForegroundColor = normal;
                    Console.WriteLine(message);
                    break;
                default:
                    Console.ForegroundColor = normal;
                    Console.WriteLine("<[ BAD ENUM ]>", message);
                    break;
            }
        }

        public enum Type
        {
            Normal,
            Error,
            Title
        }
    }
}