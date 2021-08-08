using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class TasksView
    {
        Menu menu;
        Window window;
        public Func<List<string>> ReadTasks;
        public Func<string, int> TaskStatus;
        public Action<string> UpdateStatus;
        public Action<string> DeleteTask;
        public TasksView()
        {
            menu = new Menu();
            window = new Window();
            window.AddWinMenu(new  List<string>{ "Wyjście - ESC", "Zmień status - ENTER", "USUŃ - Del" });
          

        }

        public void ShowView()
        {
            WinPoints winPos = new WinPoints();
            Console.CursorVisible = false;
            List<string> tasks = ReadTasks?.Invoke();
            menu.Title = "Przegląd zadań";
            int h = menu.Title.Length;
            if (tasks.Count>0)
                h = Math.Max(tasks.Max<string>((t) => t.Length), menu.Title.Length); 
            winPos = window.RedrawWindow(h + 8, tasks.Count + 7);
            menu.Pos = winPos.yP + 5;
            menu.Pos = 0;
            menu.UpdatePos(winPos.xP+2, winPos.yP+2);

            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                tasks = ReadTasks?.Invoke();

                menu.ClearMenu();
                foreach (string task in tasks)
                {
                    menu.AddToMenu(task);
                }
                menu.DrawMainMenu( (i) => { return (TaskStatus?.Invoke(tasks[i])) ?? 0; });
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        menu.Pos--;
                        break;
                    case ConsoleKey.DownArrow:
                        menu.Pos++;
                        break;
                    case ConsoleKey.Enter:
                        if(tasks.Count>0)
                            UpdateStatus?.Invoke(tasks[menu.Pos]);
                        break;
                    case ConsoleKey.Delete:
                        if (tasks.Count == 0)
                            break;
                        DeleteTask?.Invoke(tasks[menu.Pos]);
                        ModalWindow modal = new ModalWindow();
                        modal.ShowModal("Info", "Zadanie zostało usunięte");
                        Console.Clear();
                        window.RedrawWindow(h + 8, tasks.Count + 7);
                        break;
                }


            }
            while (key.Key != ConsoleKey.Escape);


        }

       




    }
}

