using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManager4.Models;

namespace TaskManager4.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<TodoTask> tasks = new()
    {
        new TodoTask
        {
            Title = "Купить продукты",
            Description = "Хлеб, молоко, яйца",
            IsDone = false
        },
        new TodoTask
        {
            Title = "Сделать практику",
            Description = "Задание по C#",
            IsDone = true
        }
    };

    [ObservableProperty]
    private TodoTask? selectedTask;

    [ObservableProperty]
    private ViewModelBase currentViewModel;

    public MainWindowViewModel()
    {
        CurrentViewModel = this;
    }

    [RelayCommand]
    private void Create()
    {
        var task = new TodoTask();

        CurrentViewModel = new TaskEditorViewModel(task, saved =>
        {
            if (saved && !string.IsNullOrWhiteSpace(task.Title))
            {
                Tasks.Add(task);
            }
            CurrentViewModel = this;
        });
    }

    [RelayCommand]
    private void Edit()
    {
        var original = SelectedTask;

        var copy = new TodoTask
        {
            Title = original.Title,
            Description = original.Description,
            IsDone = original.IsDone
        };

        CurrentViewModel = new TaskEditorViewModel(copy, saved =>
        {
            if (saved)
            {
                original.Title = copy.Title;
                original.Description = copy.Description;
                original.IsDone = copy.IsDone;
            }

            CurrentViewModel = this;
        });
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedTask == null)
            return;

        Tasks.Remove(SelectedTask);
    }
}