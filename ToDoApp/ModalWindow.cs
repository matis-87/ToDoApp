using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class  ModalWindow:Window
    {
        public int ShowModal(string title, string text)
        {
            WinPoints points = RedrawWindow(40, 10);
            Console.SetCursorPosition(points.xP + 2, points.yP + 2);
            Console.Write(title);
            Console.SetCursorPosition(points.xP + 2, points.yP + 4);
            Console.Write(text);
            Console.SetCursorPosition(points.xP + 16, points.yP + 6);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("  OK  ");
            Console.BackgroundColor = ConsoleColor.Black;
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
     

            return 0;
        }
    }
}
