// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

namespace SingletonPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //  two instances of Logger
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            // logger to log messages
            logger1.Log("First logger instance message");
            logger2.Log("Second logger instance message");

            //  they are the same instance
            if (logger1 == logger2)
            {
                Console.WriteLine("Both logger1 and logger2 are the SAME instance.");
            }
            else
            {
                Console.WriteLine("They are different instances — Singleton failed.");
            }
        }
    }
}

