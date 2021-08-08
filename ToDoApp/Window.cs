using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class Window
    {
        int width;
        int height;
        int x;
        int y;
        WinMenu WinMenu;
        public Window()
        {
            width = 40;
            height = 20;
            x = Console.WindowWidth / 2 - width / 2;
            y = Console.WindowHeight / 2 - height / 2;
            WinMenu = new WinMenu();
        }
        public Window(int _width, int _height)
        {
            width = _width;
            height = _height;
            x = Console.WindowWidth / 2 - width / 2;
            y = Console.WindowHeight / 2 - height / 2;

        }
        public void AddWinMenu(List<string> items)
        {
            WinMenu.items = items;
        }
        public void ShowWindow(bool clear=true)
        { if(clear)
            Console.Clear();
            WinMenu?.ShowMenu();
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for(int i=0;i<width-2;i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
           for (int i = y+1; i < y + height - 2; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("║");
                Console.SetCursorPosition(x+width-1, i);
                Console.Write("║");

            }
            Console.SetCursorPosition(x, y+height-2);
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }

        public void EraseWindow()
        {
           // Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            for (int i = y + 1; i < y + height - 2; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(" ");
                Console.SetCursorPosition(x + width - 1, i);
                Console.Write(" ");

            }
            Console.SetCursorPosition(x, y + height - 2);
            Console.Write(" ");
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write(" ");
        }
        public WinPoints RedrawWindow(int twidth, int theight, bool clear = true)
        {
            SetDim(twidth, theight);
            ShowWindow(clear);
            return GetPoints();
        }
        public void SetDim(int _width, int _hieght)
        {
            if (_width < Console.WindowWidth)
                width = _width;
            else
                width = Console.WindowWidth;
            if (_hieght < Console.WindowHeight)
                height = _hieght;
            else
                height = Console.WindowHeight;
            x = Console.WindowWidth / 2 - width / 2;
            y = Console.WindowHeight / 2 - height / 2;
        }
        public WinPoints GetPoints()
        {
            return new WinPoints { xP = x, yP = y, heightP = height, widthP = width };
        }

    }
}
