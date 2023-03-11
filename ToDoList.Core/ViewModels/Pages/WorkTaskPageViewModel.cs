using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.Core;

namespace ToDoList.Core;

public class WorkTaskPageViewModel
{
    public ObservableCollection<WorkTaskViewModel> WorkTasksList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

    public string NewWorkTaskTitle { get; set; }
    public string NewWorkTaskDescription { get; set; }
    public ICommand AddNewTaskCommand { get; set; }

    public WorkTaskPageViewModel()
    {
        AddNewTaskCommand = new RelayCommand(AddNewTask);
    }
    private void AddNewTask()
    {
        var NewTask = new WorkTaskViewModel
        {
            Title = NewWorkTaskTitle,
            Description = NewWorkTaskDescription,
            CreatedDate = DateTime.Now
        };

        WorkTasksList.Add(NewTask);
    }
}
