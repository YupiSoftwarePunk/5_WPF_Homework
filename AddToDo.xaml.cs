using System.Windows;

namespace fifth_practice;

/// <summary>
/// Логика взаимодействия для AddToDo.xaml
/// </summary>
public partial class AddToDo : Window
{
    public AddToDo()
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
