using System;

namespace SingletonPattern
{
    public sealed class TheBell
    {
        private static TheBell _theBell;
        private static object sync = new object();
        private TheBell() { }

        public static TheBell Instance
        {
            get
            {
                lock (sync)
                {
                    if (_theBell == null)
                    {
                        _theBell = new TheBell();
                    }
                }

                return _theBell;
            }
        }

        public void Ring()
        {
            Console.WriteLine("Ding! Order up!");
        }
    }
}