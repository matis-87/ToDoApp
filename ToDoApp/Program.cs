using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Helper;

namespace ToDoApp
{
    class Program
    {
        static Menu menu;
        
        static void Main(string[] args)
        {
            ConsoleHelper.SetCurrentFont("Consolas", 14);
            menu = new Menu(new List<string> { "Przeglądaj zadania", "Dodaj zadanie","Zapisz" ,"Koniec" });
            menu.Title = "TODOs";
            Tasks tasks = new Tasks();
            tasks.LoadTasks();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Window mainWindow = new Window();
            mainWindow.AddWinMenu(new List<string> { "Wyjście - ESC"});

            NewTaskView newTaskView = new NewTaskView();
            newTaskView.AddTask += tasks.AddTask;
            TasksView tasksView = new TasksView();
            tasksView.ReadTasks += tasks.ToList;
            tasksView.TaskStatus += tasks.Status;
            tasksView.UpdateStatus += tasks.UpdateStatus;
            tasksView.DeleteTask += tasks.DeleteTask;
            WinPoints winPos =  mainWindow.RedrawWindow(menu.GetMaxWidth()+4, menu.GetMaxHeight() + 7);
            menu.UpdatePos(winPos.xP + 2, winPos.yP + 2);
            do
            {
                Console.CursorVisible = false;
                menu.DrawMainMenu(null);
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
                        if(menu.Pos == 1)
                        {
                            newTaskView.ShowView();
                            Console.Clear();
                            mainWindow.ShowWindow();

                        }

                        if (menu.Pos == 2)
                        {
                            tasks.SaveTasks();
                            ModalWindow info = new ModalWindow();
                            info.ShowModal("Zapisywanie", "Zapisano listę");
                            mainWindow.ShowWindow();
                        }

                        if (menu.Pos == 0)
                        {   
                            tasksView.ShowView();
                            Console.Clear();
                            mainWindow.ShowWindow();

                        }

                        if (menu.Pos == 3)
                        {

                            return;

                        }
                        break;
                }
            

            }
            while (key.Key != ConsoleKey.Escape);
        }
    }
}
