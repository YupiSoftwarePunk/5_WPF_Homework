using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace fifth_practice;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<ToDo> ToDoList = new ObservableCollection<ToDo>();
    public int TodoListCount { 
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
        int totalTasks = ToDoList.Count;
        int completedTasks = ToDoList.Count(t => t.Doing);

        CounterText.Text = $"{completedTasks}/{totalTasks}";

        Progress.Maximum = totalTasks;
        Progress.Value = completedTasks;
    }

    private void CreateToDo(object sender, RoutedEventArgs e)
    {
        var AddToDo = new AddToDo();
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