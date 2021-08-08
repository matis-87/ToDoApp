using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoApp
{

    class Tasks
    {
        List<Task> Lista;
        List<Task> CompletedTasks;

        public Tasks()
        {
            Lista = new List<Task>();
            CompletedTasks = new List<Task>();
             
           
        }

        public void SaveTasks()
        {
            XDocument doc = new XDocument();
            doc.Add(new XElement("root"));
            DateTime tNow =  DateTime.Now;

            foreach(Task t in Lista)
            {
                XElement el = new XElement("task");
                XAttribute atrName = new XAttribute("name",t.Name);
                XAttribute atrStatus = new XAttribute("status", t.Done);
                XAttribute atrDate = new XAttribute("date", t.Date.ToString("dd.MM.yyyy"));
                el.Add(atrName);
                el.Add(atrStatus);
                el.Add(atrDate);
                doc.Root.Add(el);
            }
            foreach (Task t in CompletedTasks)
            {
                XElement el = new XElement("task");
                XAttribute atrName = new XAttribute("name", t.Name);
                XAttribute atrStatus = new XAttribute("status", t.Done);
                XAttribute atrDate = new XAttribute("date", t.Date.ToString("dd.MM.yyyy"));
                el.Add(atrName);
                el.Add(atrStatus);
                el.Add(atrDate);
                doc.Root.Add(el);
            }
            doc.Save("todo.xml");
        //   List<string> _list = doc.Elements().Where((el) => el.Attribute("status").Value.Equals(false)).ToList();
        }
        public void LoadTasks()
        {
           
            XDocument doc = XDocument.Load("todo.xml");
            List<XElement> tasksel = doc.Root.Elements("task").ToList();
            foreach(XElement el in tasksel)
            {
                Task _task = new Task();
                _task.Name = el.Attribute("name").Value;
                _task.Done = Convert.ToBoolean(el.Attribute("status").Value);
                
                string temp = el.Attribute("date").Value;
                DateTime _tdate = new DateTime(Convert.ToInt32(temp.Substring(6, 4)), Convert.ToInt32(temp.Substring(3, 2)), Convert.ToInt32(temp.Substring(0, 2)));
                _task.Date = _tdate;
                if ((DateTime.Now.Subtract(_tdate).Days > 1) && (_task.Done))
                    break;
                else
                    Lista.Add(_task);

            }


            int g = 0;
        }

        public void ReadTasks()
        {
            XDocument dpc = XDocument.Load("todo.xml");

        }
        public void AddTask(string name)
        {
            Lista.Add(new Task { Name = name, Status = 50, Date = DateTime.Now }) ;
        }

        public List<string> ToList()
        {
            List<string> temp = new List<string>();
            temp = Lista.Select(l => l.Name).ToList();
            temp.AddRange(CompletedTasks.Select(l => l.Name));
            return temp;
        }
        public int Status(string nazwa)
        {
            Task temp = Lista.Where<Task>((t) =>
            {
                if (t.Name.Equals(nazwa))
                    return true;
                else
                return false;
            }).FirstOrDefault();
           if(temp == null)
                temp = CompletedTasks.Where<Task>((t) =>
                {
                    if (t.Name.Equals(nazwa))
                        return true;
                    else
                        return false;
                }).FirstOrDefault();
            TimeSpan time =DateTime.Now.Subtract(temp.Date);
            if (temp.Done)
                return 1;
            else
            {
                if (time.Days < 2)
                    return 0;
                if ((time.Days >= 2) && (time.Days < 4))
                    return 2;
                return 3;
            }
        }

        public void DeleteTask(string _name)
        {
            Task temp = Lista.Where<Task>((t) =>
            {
                if (t.Name.Equals(_name))
                    return true;
                else
                    return false;
            }).FirstOrDefault();
            if (temp != null)
            
                
                Lista.Remove(temp);           
            else
                {
                    temp = CompletedTasks.Where<Task>((t) =>
                    {
                        if (t.Name.Equals(_name))
                            return true;
                        else
                            return false;
                    }).FirstOrDefault();
                    if (temp != null)
                    {
                        CompletedTasks.Remove(temp);
                    }
                }

            }
        public void UpdateStatus(string _name)
        {
            
             Task temp = Lista.Where<Task>((t) =>
            {
                if (t.Name.Equals(_name))
                    return true;
                else
                    return false;
            }).FirstOrDefault();
            if (temp != null)
            {
                Lista.Remove(temp);
                temp.Done = true;
                CompletedTasks.Add(temp);
            }
            else
            {
                temp = CompletedTasks.Where<Task>((t) =>
               {
                   if (t.Name.Equals(_name))
                       return true;
                   else
                       return false;
               }).FirstOrDefault();
                if (temp != null)
                {
                    CompletedTasks.Remove(temp);
                    temp.Done = false;
                    Lista.Add(temp);
                }
            }
        }
    }
}
