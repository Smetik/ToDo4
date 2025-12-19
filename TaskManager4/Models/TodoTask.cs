namespace TaskManager4.Models;

using CommunityToolkit.Mvvm.ComponentModel;

public partial class TodoTask : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private bool isDone;
}
