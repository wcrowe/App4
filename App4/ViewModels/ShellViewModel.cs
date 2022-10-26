﻿using System.Windows.Input;

using App4.Contracts.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace App4.ViewModels;

public class ShellViewModel : ObservableObject
{
    private readonly IRightPaneService _rightPaneService;
    private ICommand _loadedCommand;
    private ICommand _unloadedCommand;

    public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

    public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

    public ShellViewModel(IRightPaneService rightPaneService)
    {
        _rightPaneService = rightPaneService;
    }

    private void OnLoaded()
    {
    }

    private void OnUnloaded()
    {
        _rightPaneService.CleanUp();
    }
}
