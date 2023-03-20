using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Core;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for WorkTasksPage.xaml
    /// </summary>
    public partial class WorkTasksPage : Page
    {
        public WorkTasksPage()
        {
            InitializeComponent();

            DataContext = new WorkTaskPageViewModel();

        }

        private void AddTask_ButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(TaskNameTextBox.Text))
            {
                MessageBox.Show("You must name the task before adding it!");
            }
        }

    }
}
