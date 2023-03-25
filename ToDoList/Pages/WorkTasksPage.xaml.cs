using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToDoList.Core;
namespace ToDoList
{
    /// <summary>
    /// Interaction logic for WorkTasksPage.xaml
    /// </summary>
    public partial class WorkTasksPage : Page, IMessageService
    {
        private MainWindow mainWindowInstance;
        public WorkTasksPage()
        {
            InitializeComponent();

            DataContext = new WorkTaskPageViewModel(this);

            mainWindowInstance = (MainWindow)Application.Current.MainWindow;
        }

        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void CloseAppMessage()
        {
            App.Current.Shutdown();
        }

        public void MinimizeAppMessage()
        {
            mainWindowInstance.MinimizeMianWindow(); 
        }

    }
}
