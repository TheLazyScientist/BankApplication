using System;
using System.Collections.Generic;
using System.Text;

namespace Bankkonto
{

    class Window
    {
        static public void Write(int length, string[] message)
        {
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= 119; j++)
                {
                    if ((i == 1 || i == length) && j >= 1)
                    {
                        Console.Write("#");
                    }
                    else if (j == 1 || j == 119)
                    {
                        Console.Write("#");
                    }                   
                    else if (i >= 2 && j == Math.Round(119d/2-message[i - 2].Length/2))
                    {
                        Console.Write(message[i - 2]);
                        j += message[i - 2].Length - 1;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();

            }
        }
    }
}
