using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    class SortTasksByProgress : IComparer<Task>
    {
        public int Compare(Task x, Task y)
        {
            int res = x.Name.CompareTo(y.Name);
            //return res;

               if ((x.Done == true) && (y.Done == false) && (x.Name.CompareTo(y.Name)!=0))
                   return 1;
               if (((x.Done == false) && (y.Done == true)|| (x.Done == false) && (y.Done == false)|| (x.Done == true) && (y.Done == true)) && (x.Name.CompareTo(y.Name) != 0))
                
                return -1;
                else
                   return 0;

        
        }
    }
}
