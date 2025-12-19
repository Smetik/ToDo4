namespace TaskManager1._3.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class TodoTask : ObservableObject
{
    [ObservableProperty]
    private string title = "";

    [ObservableProperty]
    private string description = "";

    [ObservableProperty]
    private bool isDone;
}