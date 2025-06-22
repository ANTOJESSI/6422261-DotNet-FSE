using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        //  Create a private static instance of Logger
        private static Logger? _instance;

        //  Lock object to make thread-safe
        private static readonly object _lock = new object();

        //  constructor 
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        //  global access to the instance
        public static Logger Instance
        {
            get
            {
                // Double-checked locking
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        // log method
        public void Log(string message)
        {
            Console.WriteLine($"[Logger Message] {DateTime.Now}: {message}");
        }
    }
}
