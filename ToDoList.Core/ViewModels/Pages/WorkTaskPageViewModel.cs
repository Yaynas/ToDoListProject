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

    private readonly IMessageService messageService;
    public string NewWorkTaskTitle { get; set; }
    public string NewWorkTaskDescription { get; set; }
    public ICommand AddNewTaskCommand { get; set; }
    public ICommand DeleteSelectedTaskCommand { get; set; }
    public ICommand CloseApp { get; set; }
    public ICommand MinimizeApp { get; set; }

    public WorkTaskPageViewModel(IMessageService messageService)
    {
        this.messageService = messageService;

        AddNewTaskCommand = new RelayCommand(AddNewTask);
        DeleteSelectedTaskCommand = new RelayCommand(DeleteSelectedTask);
        CloseApp = new RelayCommand(CloseAppPageViewModel);
        MinimizeApp = new RelayCommand(MinimizeAppPageViewModel);

        DBLocator.ListDatabase.WorkTask.ToList();

        foreach(var task in DBLocator.ListDatabase.WorkTask.ToList())
        {
            WorkTasksList.Add(new WorkTaskViewModel
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedDate = task.CreatedDate
            });


        }
    }
    private void AddNewTask()
    {
        var countedTasks = WorkTasksList.ToList();
        int IdTemp;
        if(countedTasks.Count > 0)
        {
            IdTemp = DBLocator.ListDatabase.WorkTask.OrderByDescending(x => x.Id).First().Id + 1;
        }
        else
        {
            IdTemp = 1;
        }
        if (!String.IsNullOrEmpty(NewWorkTaskTitle))
        {

            
            var NewTask = new WorkTaskViewModel
            {                
                Id = IdTemp,
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            };

            WorkTasksList.Add(NewTask);
            DBLocator.ListDatabase.WorkTask.Add(new Database.WorkTask
            {
                Id = NewTask.Id,
                Title = NewTask.Title,
                Description = NewTask.Description,
                CreatedDate = NewTask.CreatedDate
            });

            DBLocator.ListDatabase.SaveChanges();

            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;
        }
        else
        {
            messageService.DisplayMessage("Title is required. Add it before saving task");
        }

    }

    private void DeleteSelectedTask()
    {
        var selectedTasks = WorkTasksList.Where(x => x.IsSelected).ToList();
        
        if(selectedTasks.Count == 0) 
        {
            messageService.DisplayMessage("You must choose at least 1 task to delete. Do it by clicking on checkbox.");
        }
        foreach (var task in selectedTasks)
        {
            WorkTasksList.Remove(task);
            var foundTask = DBLocator.ListDatabase.WorkTask.FirstOrDefault(x => x.Id == task.Id);

            if (foundTask != null)
            {
                DBLocator.ListDatabase.WorkTask.Remove(foundTask);
            }
        }

        DBLocator.ListDatabase.SaveChanges();
    }

    private void CloseAppPageViewModel()
    {
        messageService.CloseAppMessage();
    }

    private void MinimizeAppPageViewModel()
    {
        messageService.MinimizeAppMessage();
    }


}
