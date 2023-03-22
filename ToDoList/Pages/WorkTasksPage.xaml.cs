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
        private readonly WorkTaskPageViewModel viewModel;

        public WorkTasksPage()
        {
            InitializeComponent();

            viewModel = new WorkTaskPageViewModel(this);
            DataContext = viewModel;
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
