using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerProject
{
    public class MyTask
    {
        public uint id;
        public string title;
        public string description;
        public DateTime createdAt;
        public bool isCompleted;
        public uint priority;
        public float estimateHours;


        public MyTask(uint id, string title, string description,uint priority)
        {
            this.id=id;
            this.title=title;
            this.description=description;
            this.createdAt= DateTime.Now;
            this.isCompleted= false;
            this.priority=0;

        }

        public MyTask() { }
    }
}
