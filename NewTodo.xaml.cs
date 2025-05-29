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
using static _5_WPF_Homework.MainWindow;

namespace _5_WPF_Homework
{
    /// <summary>
    /// Логика взаимодействия для NewTodo.xaml
    /// </summary>
    public partial class NewTodo : Window
    {
        public NewTodo()
        {
            InitializeComponent();
            dateToDo.SelectedDate = DateTime.Now;
        }

        private void SaveToDo(object sender, RoutedEventArgs e)
        {
            if (!dateToDo.SelectedDate.HasValue)
            {
                dateToDo.SelectedDate = DateTime.Now;
            }
            var mainWindow = (MainWindow)Owner;

            mainWindow.ToDoList.Add(new ToDo(titleToDo.Text,
                                    new DateTime(dateToDo.SelectedDate.Value.Year,
                                                dateToDo.SelectedDate.Value.Month,
                                                dateToDo.SelectedDate.Value.Day),
                                    descriptionToDo.Text));
            this.Close();
        }
    }

}
