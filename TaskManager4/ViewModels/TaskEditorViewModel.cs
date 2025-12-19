using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager4.Models;

namespace TaskManager4.ViewModels;
public partial class TaskEditorViewModel : ViewModelBase
{
    [ObservableProperty]
    private TodoTask task;

    private readonly Action<bool> _closeCallback;

    public TaskEditorViewModel(TodoTask task, Action<bool> closeCallback)
    {
        Task = task;
        _closeCallback = closeCallback;
    }

    [RelayCommand]
    private void Save()
    {
        _closeCallback(true);
    }

    [RelayCommand]
    private void Cancel()
    {
        _closeCallback(false);
    }
}