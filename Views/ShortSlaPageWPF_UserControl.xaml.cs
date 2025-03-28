﻿using GUI_zaliczenie2025.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Task = GUI_zaliczenie2025.Classes.Objects.Task;

namespace GUI_zaliczenie2025
{
    /// <summary>
    /// Logika interakcji dla klasy ShortSlaPageWPF_UserControl.xaml
    /// </summary>
    public partial class ShortSlaPageWPF_UserControl : UserControl
    {
        public static string Taskid;
        public static string TaskUser;
        public static string Choose;
        public static string Search;
        private bool IsUserViev = false;

        public ShortSlaPageWPF_UserControl()
        {
            InitializeComponent();
            DataGridShortSla.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();


        }

        public ShortSlaPageWPF_UserControl(bool isUSerViev)
        {


            InitializeComponent();
            IsUserViev = isUSerViev;
            DataGridShortSla.ItemsSource = ActualTasksOperations.ReturnRequestsListObject();




        }
        public ShortSlaPageWPF_UserControl(string choose, string search)
        {
            Choose = choose;
            Search = search;
            InitializeComponent();
            DataGridShortSla.ItemsSource = ActualTasksOperations.MessageBoxShowObject(choose, search);


        }

        //Metoda zwracająca wybrany z listy task i wyświetla go w kontrolce użytkownika
        public void RowDoubleClicktask(object sender, RoutedEventArgs e)
        {

            var hit = e.OriginalSource as DependencyObject;

            while (hit != null)
            {
                if (hit is DataGridColumnHeader)
                {
                    e.Handled = true;
                    return;
                }

                if (hit is TextBlock)
                {
                    if (DataGridShortSla.SelectedItem != null)
                    {
                        Taskid = null;
                        TaskUser = null;
                        var selectedItem = DataGridShortSla.SelectedItem as Task;

                        Taskid = selectedItem.Id;
                        TaskUser = selectedItem.Technican;

                        GridShortSla.Children.Clear();
                        GridShortSla.Children.Add(new TicketsShowUserControlWPF("normal", IsUserViev));

                    }

                }
                return;
            }

        }


    }
}
