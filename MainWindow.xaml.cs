using System.Collections.ObjectModel;
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
        public ObservableCollection<ToDo> ToDoList = new ObservableCollection<ToDo>();
        public int TodoListCount
        {
            get => ToDoList.Count;
        }

        public int ToDoListCountComplited
        {
            get => ToDoList.Where(p => p.Doing == true).Count();
        }

        public MainWindow()
        {
            InitializeComponent();

            listToDo.ItemsSource = ToDoList;

            ToDoList.CollectionChanged += (s, e) => UpdateCounters();
            UpdateCounters();
        }

        private void UpdateCounters()
        {
            CounterText.Text = $"{ToDoList.Count}/{ToDoList.Count(t => t.Doing)}";
            Progress.Maximum = ToDoList.Count;
            Progress.Value = ToDoList.Count(t => t.Doing);
        }

        private void CreateToDo(object sender, RoutedEventArgs e)
        {
            var AddToDo = new NewTodo();
            AddToDo.Show();
            AddToDo.Owner = this;
        }

        private void DeleteToDo(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem as ToDo == null) { return; }
            else
            {
                ToDoList.Remove(listToDo.SelectedItem as ToDo);
            }
        }

        private void CheckBox_Cheked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                UpdateCounters();
            }
        }

        private void CheckBox_Uncheked(object sender, RoutedEventArgs e)
        {
            UpdateCounters();
        }
    }
}
