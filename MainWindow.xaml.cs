using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5_WPF_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> todo = new List<ToDo>();

        public MainWindow()
        {
            InitializeComponent();

            todo.Add(new ToDo("Дописать проект", new DateTime(2025, 5, 23), "Доделать проект с математическими классами"));
            ToDolist.ItemsSource = todo;
        }


        private void btnAdd(object sender, RoutedEventArgs e)
        {
            var NewTodo = new NewTodo();
            NewTodo.Show();
            NewTodo.Owner = this;
        }


        private void btnDelete(object sender, RoutedEventArgs e)
        {
            if (ToDolist.SelectedItem as ToDo == null)
            {
                return;
            }
            else
            {
                todo.Remove((ToDo)ToDolist.SelectedItem);

                ToDolist.ItemsSource = null;
                ToDolist.ItemsSource = todo;
            }
        }


        private void CheckBox_Cheked(object sender, RoutedEventArgs e)
        {
            if (ToDolist.SelectedItem != null)
            {
                UpdateCounters();
            }
        }


        private void CheckBox_Uncheked(object sender, RoutedEventArgs e)
        {
            UpdateCounters();
        }



        private void UpdateCounters()
        {
            CounterText.Text = $"{todo.Count}/{todo.Count(t => t.Doing)}";
            Progress.Maximum = todo.Count;
            Progress.Value = todo.Count(t => t.Doing);
        }




        public class ToDo
        {
            private string name_;
            private DateTime date_;
            private string description_;
            private bool doing_;

            public string Name { get { return name_; } }
            public DateTime Date { get { return date_; } }
            public string Description { get { return description_; } }
            public bool Doing
            {
                get => doing_;
                set => doing_ = value;
            }

            public ToDo(string name, DateTime date, string description)
            {
                name_ = name;
                date_ = date;
                description_ = description;
                doing_ = false;
            }
        }

    }
}