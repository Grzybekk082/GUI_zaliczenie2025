using GUI_zaliczenie2025.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task = GUI_zaliczenie2025.Classes.Task;

namespace GUI_zaliczenie2025.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AssignTaskToUser_Window.xaml
    /// </summary>
    public partial class AssignTaskToUser_Window : Window
    {
        private List<Classes.Task> SelectedTask;
        private List<Classes.Task> SelectedTaskId;
        public AssignTaskToUser_Window()
        {
            InitializeComponent();
            AssignTaskContent_DataGrid.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();
            SelectedTask = new List<Classes.Task>();
            //SelectedTaskId = new List<string>();
        }
        
        private void SelectTaskToList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (SelectedTask.Count > 0)
            {
                
            }
            SelectedTask.Add(AssignTaskContent_DataGrid.SelectedItem as Task);
            //SelectedTaskId.Add(this Task.id);
            

            SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
            SelectedTasksToAssign_DataGrid.Items.Refresh();



        }
        
    }
}
