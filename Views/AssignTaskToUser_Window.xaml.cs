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
        private List<Classes.Device> SelectedDevice;
        private List<string> SelectedTaskId;
        

        //Konstruktor klasy AssignTaskToUser_Window
        public AssignTaskToUser_Window()
        {
            InitializeComponent();
            AssignTaskContent_DataGrid.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();
            SelectedTask = new List<Task>();
            SelectedDevice = new List<Device>();
            SelectedTaskId = new List<string>();
        }
        //Metoda przypisująca zadanie do użytkownika
        //private void SelectTaskToList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        //{
        //    Task Selected = (Task)AssignTaskContent_DataGrid.SelectedItem ;
        //    bool isOcupated = false;


        //    foreach (var tasks in SelectedTask)
        //    {
        //        if (tasks == Selected)
        //        {
        //            isOcupated = true;
        //        }
        //    }

        //    if (isOcupated)
        //    {
        //        MessageBox.Show("Task is already selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    else
        //    {
        //        SelectedTask.Add(AssignTaskContent_DataGrid.SelectedItem as Task);

        //        if (SelectedTask!= null)
        //        {
        //            SelectedTaskId.Add(Selected.Id);

        //        }
        //        SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
        //        SelectedTasksToAssign_DataGrid.Items.Refresh();
        //    }
        //}
        ////Metoda usuwająca zadanie z listy
        //private void RemoveTaskFromList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        //{
        //    if (SelectedTasksToAssign_DataGrid.SelectedItem is Task selectedTask)
        //    {
        //        SelectedTask.Remove(selectedTask);
        //        SelectedTaskId.Remove(selectedTask.Id);

        //        SelectedTasksToAssign_DataGrid.ItemsSource = null;
        //        SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
        //        SelectedTasksToAssign_DataGrid.Items.Refresh();
        //    }
        //}



        private void SelectObject(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {

            string buttonName = (sender as Button).Name;
            if (buttonName == "AssignTaskContent_DataGrid")
            {
                SelectedTask = new List<Classes.Task>();
                SelectTaskToList<Task>();
            }
            

            SelectTaskToList<Device>();
        }


        //Metoda przypisująca zadanie do użytkownika

        private void SelectTaskToList<T>() where T : Task
        {
            List<T> SelectedObject = new List<T>();
            T Selected = (T)AssignTaskContent_DataGrid.SelectedItem;
            bool isOcupated = false;


            foreach (var tasks in SelectedObject)
            {
                if (tasks == Selected)
                {
                    isOcupated = true;
                }
            }

            if (isOcupated)
            {
                MessageBox.Show("Object is already selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedTask.Add((T)AssignTaskContent_DataGrid.SelectedItem);

                if (SelectedTask != null)
                {
                    SelectedTaskId.Add(Selected.Id);

                }
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }

            if (typeof(T) is Task)
            {
                SelectedTask = SelectedObject as List<Task>;
            }
            if (typeof(T) is Device)
            {
                SelectedDevice = SelectedObject as List<Device>;
            }
        }

        //Metoda usuwająca zadanie z listy
        private void RemoveTaskFromList<T>(object sender, MouseButtonEventArgs mouseButtonEventArgs) where T : Task
        {
            if (SelectedTasksToAssign_DataGrid.SelectedItem is T selectedTask)
            {
                SelectedTask.Remove(selectedTask);
                SelectedTaskId.Remove(selectedTask.Id);

                SelectedTasksToAssign_DataGrid.ItemsSource = null;
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }
        }
    }
}
