using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TheBell.Instance.Ring();
            TheBell.Instance.Ring();
        }
    }
}
