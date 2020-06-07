using System;
using System.Threading;
class Pr
{
    public static void Main()
    {
        //while (status)
        {
            ConsoleKeyInfo info = Console.ReadKey(true);
            if (info.Key == ConsoleKey.UpArrow)
            {
                Console.Write("up");
            }
        }
    }
}