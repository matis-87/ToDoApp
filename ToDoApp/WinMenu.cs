using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    public class WinMenu
    {
        public List<string> items;

        public WinMenu()
        {
            items = new List<string>();

        }

        public WinMenu(List<string> _items)
        {
            items = _items;

        }
        public void ShowMenu()
        {
            Console.SetCursorPosition(1, 0);
            foreach(string item in items)
            {
                
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" "+item+" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("  ");

            }
            Console.ForegroundColor = ConsoleColor.Gray;

            

        }
    }
}
