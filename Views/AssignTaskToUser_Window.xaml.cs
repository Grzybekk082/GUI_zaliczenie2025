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
        private List<string> SelectedId;
        SelectedUser_UserControl CurrentInstance;
        bool isTask;


        //Konstruktory klasy AssignTaskToUser_Window
        public AssignTaskToUser_Window(){}

        public AssignTaskToUser_Window(SelectedUser_UserControl CurrentInstance, bool isTask)
        {
            
            InitializeComponent();
            this.isTask= isTask;
            this.CurrentInstance = CurrentInstance;
            if (isTask)
            {
                SelectedTask = new List<Task>();
                AssignTaskContent_DataGrid.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();

            }
            if(!isTask)
            {
                SelectedDevice = new List<Device>();
                AssignTaskContent_DataGrid.ItemsSource = UsersManagementOperations.ReturnDevicesListObject(true);
            }
            
            SelectedId = new List<string>();
        }

        private void SelectObject(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (isTask)
            {
                SelectTaskToList(sender, mouseButtonEventArgs);
            }
            else
            {
                SelectDeviceToList(sender, mouseButtonEventArgs);
            }
        }

        //Metoda przypisująca zadanie do użytkownika
        private void SelectTaskToList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Task Selected = (Task)AssignTaskContent_DataGrid.SelectedItem;
            bool isOcupated = false;


            foreach (var tasks in SelectedTask)
            {
                if (tasks == Selected)
                {
                    isOcupated = true;
                }
            }

            if (isOcupated)
            {
                MessageBox.Show("Task is already selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedTask.Add(AssignTaskContent_DataGrid.SelectedItem as Task);

                if (SelectedTask != null)
                {
                    SelectedId.Add(Selected.Id);

                }
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }
        }

        //Metoda przypisująca urządzenie do użytkownika
        private void SelectDeviceToList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Device Selected = (Device)AssignTaskContent_DataGrid.SelectedItem;
            bool isOcupated = false;


            foreach (var device in SelectedDevice)
            {
                if (device == Selected)
                {
                    isOcupated = true;
                }
            }

            if (isOcupated)
            {
                MessageBox.Show("Task is already selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedDevice.Add(AssignTaskContent_DataGrid.SelectedItem as Device);

                if (SelectedDevice != null)
                {
                    SelectedId.Add(Selected.Id);

                }
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedDevice;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }
        }

        private void RemoveObject(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (isTask)
            {
                RemoveTaskFromList(sender, mouseButtonEventArgs);
            }
            else
            {
                RemoveDeviceFromList(sender, mouseButtonEventArgs);
            }
        }
        //Metoda usuwająca zadanie z listy
        private void RemoveTaskFromList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (SelectedTasksToAssign_DataGrid.SelectedItem is Task selectedTask)
            {
                SelectedTask.Remove(selectedTask);
                SelectedId.Remove(selectedTask.Id);

                SelectedTasksToAssign_DataGrid.ItemsSource = null;
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedTask;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }
        }

        //Metoda usuwająca urzadzenie z listy
        private void RemoveDeviceFromList(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (SelectedTasksToAssign_DataGrid.SelectedItem is Device selectedDevice)
            {
                SelectedDevice.Remove(selectedDevice);
                SelectedId.Remove(selectedDevice.Id);

                SelectedTasksToAssign_DataGrid.ItemsSource = null;
                SelectedTasksToAssign_DataGrid.ItemsSource = SelectedDevice;
                SelectedTasksToAssign_DataGrid.Items.Refresh();
            }
        }









    }
}
