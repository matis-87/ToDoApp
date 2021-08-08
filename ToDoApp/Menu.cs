using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
 public   class Menu
    {
        int lastPos;
        int startX;
        int startTop;
        int _pos;
        public int Pos { 
            get { return _pos;  } 
            set {
                lastPos = _pos;
                _pos = value;
                if (_pos > menuList.Count-1)
                    _pos = menuList.Count-1;
                if (_pos < 0)
                    _pos = 0;
            } }
        int maxwidth;
        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = "*****  " + value + " *****"; }
        }
        List<string> menuList;
        public Menu()
        {
            menuList = new List<string>();
            lastPos = 0;
            Pos = 0;
            maxwidth = 1;
            startX = 10;
            startTop = 10;
        }

        public Menu(List<string> items)
        {
            menuList = new List<string>();
            lastPos = 0;
            Pos = 0;
            maxwidth = 1;
            foreach (string item in items)
            {
                menuList.Add(item);
                if (item.Length > maxwidth)
                    maxwidth = item.Length;
            }
        }
        public void UpdatePos(int _x, int _top)
        {
            startX = _x;
            startTop = _top;
        }
        public void DrawMainMenu(Func<int,int> status)
        {
            if (Pos < 0)
                Pos = 0;
            // if (lastPos != Pos)
            //  {
            int maxwidth = 0;
            if (menuList.Count>0)
                maxwidth = menuList.Max<string>((t) => t.Length) +4;
            int startPos = startX;
                Console.SetCursorPosition(startPos, startTop);
                Console.WriteLine(Title);
                Console.SetCursorPosition(startPos, startTop+2);
                for (int i = 0; i < menuList.Count; i++)
                {
                    if (i == Pos)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(startPos, startTop + i + 2);
                    int TaskStatus = status?.Invoke(i) ?? 0;
                    switch(TaskStatus)
                    {
                    case 0: Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case 1: Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2: Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 3: Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }

                    Console.Write(menuList[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    for (int j = 0; j < maxwidth - menuList[i].Length; j++)
                    {
                        Console.Write(" ");
                    }


                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0,0);
          //  }
        }

        public int GetMaxWidth()
        {
            int maxwidth = Math.Max(menuList.Max<string>((t) => t.Length) + 4, Title.Length);
            return maxwidth;
        }
        public int GetMaxHeight()
        {

            return menuList.Count;
        }
        public void AddToMenu(string MenuItem)
        {
            menuList.Add(MenuItem);
        }
        public void ClearMenu()
        {
            menuList.Clear();
        }
      
    }
}
