using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Database;


namespace ToDoList.Core
{
    public class DBLocator
    {
        public static ToDoListDBContext ListDatabase { get; set; }
    }
}
