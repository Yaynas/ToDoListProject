﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Core.ViewModels.Controls;

namespace ToDoList.Core.ViewModels.Pages
{
    internal class WorkTaskPageViewModel
    {
        public List<WorkTaskViewModel> WorkTasks = new List<WorkTaskViewModel>();

        public string NewWorkTaskTitle { get; set; }
        public string NewWorkTaskDescription { get; set; }
        private void AddNewTask()
        {
            var NewTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            };

            WorkTasks.Add(NewTask);
        }
    }
}
