using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Clarity.WPF.Services;
using Clarity.WPF.Services.Repositories;
using Clarity.WPF.ViewModels;


namespace Clarity.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public App()
    {
        var services = new ServiceCollection();

        services.AddSingleton<ITaskRepo, FileTaskRepo>();
        services.AddSingleton<ITaskService, TaskService>();

        services.AddTransient<MainWindowViewModel>();

        ServiceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = new MainWindow();
        var viewModel = ServiceProvider.GetService<MainWindowViewModel>();

        mainWindow.DataContext = viewModel;
        mainWindow.Show();
    }
}

