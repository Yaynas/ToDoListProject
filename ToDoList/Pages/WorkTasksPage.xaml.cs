using System.Windows;
using System.Windows.Controls;
using ToDoList.Core;
namespace ToDoList
{
    /// <summary>
    /// Interaction logic for WorkTasksPage.xaml
    /// </summary>
    public partial class WorkTasksPage : Page, IMessageService
    {

        public WorkTasksPage()
        {
            InitializeComponent();

            DataContext = new WorkTaskPageViewModel(this);
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
