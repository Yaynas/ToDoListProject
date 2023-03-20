using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.Core.ViewModels.BaseViewModel;

namespace ToDoList.Core;

public class WorkTaskPageViewModel : BaseViewModel
{
    public ObservableCollection<WorkTaskViewModel> WorkTasksList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

    public string NewWorkTaskTitle { get; set; }
    public string NewWorkTaskDescription { get; set; }
    public ICommand AddNewTaskCommand { get; set; }
    public ICommand DeleteSelectedTaskCommand { get; set; }

    public WorkTaskPageViewModel()
    {        
        AddNewTaskCommand = new RelayCommand(AddNewTask);
        DeleteSelectedTaskCommand = new RelayCommand(DeleteSelectedTask);
    }
    private void AddNewTask()
    {
        if(!String.IsNullOrEmpty(NewWorkTaskTitle))
        {
            var NewTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            };

            WorkTasksList.Add(NewTask);

            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;
        }
                 
    }

    private void DeleteSelectedTask()
    {
        var selectedTasks = WorkTasksList.Where(x => x.IsSelected).ToList();

        foreach (var task in selectedTasks)
        {
            WorkTasksList.Remove(task);
        }       
    }

}
