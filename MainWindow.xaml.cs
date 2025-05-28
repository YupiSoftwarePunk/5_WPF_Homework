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


        public class ToDo
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Description { get; set; }

            public ToDo(string name, DateTime date, string description)
            {
                Name = name;
                Date = date;
                Description = description;
            }
        }
    }
}