using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
  public  class NewTaskView
    {
        Menu menu;
        Window window;
        public  Action<string> AddTask;
        public NewTaskView()
        {
            menu = new Menu();
            window = new Window();
          
           
        }

        public void ShowView()
        {
            WinPoints winPos = new WinPoints();
            Console.CursorVisible = true;
            window.SetDim(60, 10);
            window.AddWinMenu(new List<string> { "Wyjście - ESC" });
            window.ShowWindow();
            winPos = window.GetPoints();
            Console.SetCursorPosition(winPos.xP + winPos.widthP/2-9, winPos.yP + 2);
            Console.Write("Podaj nowe zadanie");
            Console.CursorTop += 3;
            Console.CursorLeft = winPos.xP +3;
            Console.BackgroundColor = ConsoleColor.Blue;
            for(int i=0;i<winPos.widthP-6;i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft = winPos.xP + 4;
            ConsoleKeyInfo key = Console.ReadKey();
            int MaxdelPos = Console.CursorLeft;
            string newtask = string.Empty;
            while((key.Key!= ConsoleKey.Enter )&&(key.Key != ConsoleKey.Escape))
            {
                if ((key.Key == ConsoleKey.Backspace) && (newtask.Length > 0))
                {
                    if (newtask.Length > 0)
                    {
                        if(newtask.Length==42)
                            Console.CursorLeft = winPos.xP + 46;
                        Console.Write(" ");
                        newtask = newtask.Substring(0, newtask.Length -1);
                           
                    }
                   if ((Console.CursorLeft > MaxdelPos) && (newtask.Length > 0))
                        Console.CursorLeft--;
            
             
                }
                else
                {
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if (newtask.Length < 42)
                        {
                            newtask += key.KeyChar;
                        }
                        else
                            Console.CursorLeft = winPos.xP + 46;
          
                        
                    }
                    else
                    {
                        Console.CursorLeft = winPos.xP + 4;
                    }
                }
                   key = Console.ReadKey();

            }

            if(key.Key == ConsoleKey.Enter)
            {
                AddTask?.Invoke(newtask);
            }


            Console.BackgroundColor = ConsoleColor.Black;
        }

       

            

    }
}
