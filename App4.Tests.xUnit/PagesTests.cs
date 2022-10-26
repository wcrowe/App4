using System.IO;
using System.Reflection;

using App4.Contracts.Services;
using App4.Core.Contracts.Services;
using App4.Core.Services;
using App4.Models;
using App4.Services;
using App4.ViewModels;
using App4.Views;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Xunit;

namespace App4.Tests.XUnit;

public class PagesTests
{
    private readonly IHost _host;

    public PagesTests()
    {
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        _host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => c.SetBasePath(appLocation))
            .ConfigureServices(ConfigureServices)
            .Build();
    }

    private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        // Core Services
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<IIdentityService, IdentityService>();
        services.AddSingleton<IMicrosoftGraphService, MicrosoftGraphService>();

        // Services
        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        services.AddSingleton<ISystemService, SystemService>();
        services.AddSingleton<ISampleDataService, SampleDataService>();
        services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
        services.AddSingleton<IUserDataService, UserDataService>();
        services.AddSingleton<IIdentityCacheService, IdentityCacheService>();
        services.AddHttpClient("msgraph", client =>
        {
            client.BaseAddress = new System.Uri("https://graph.microsoft.com/v1.0/");
        });
        services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
        services.AddSingleton<IPageService, PageService>();
        services.AddSingleton<INavigationService, NavigationService>();

        // ViewModels
        services.AddTransient<WebViewViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<ListDetailsViewModel>();
        services.AddTransient<DataGridViewModel>();
        services.AddTransient<ContentGridViewModel>();
        services.AddTransient<BlankViewModel>();

        // Configuration
        services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
    }

    // TODO: Add tests for functionality you add to WebViewViewModel.
    [Fact]
    public void TestWebViewViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(WebViewViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetWebViewPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(WebViewViewModel).FullName);
            Assert.Equal(typeof(WebViewPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to SettingsViewModel.
    [Fact]
    public void TestSettingsViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(SettingsViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetSettingsPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(SettingsViewModel).FullName);
            Assert.Equal(typeof(SettingsPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to MainViewModel.
    [Fact]
    public void TestMainViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(MainViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetMainPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(MainViewModel).FullName);
            Assert.Equal(typeof(MainPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to ListDetailsViewModel.
    [Fact]
    public void TestListDetailsViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(ListDetailsViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetListDetailsPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(ListDetailsViewModel).FullName);
            Assert.Equal(typeof(ListDetailsPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to DataGridViewModel.
    [Fact]
    public void TestDataGridViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(DataGridViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetDataGridPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(DataGridViewModel).FullName);
            Assert.Equal(typeof(DataGridPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to ContentGridViewModel.
    [Fact]
    public void TestContentGridViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(ContentGridViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetContentGridPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(ContentGridViewModel).FullName);
            Assert.Equal(typeof(ContentGridPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }

    // TODO: Add tests for functionality you add to BlankViewModel.
    [Fact]
    public void TestBlankViewModelCreation()
    {
        var vm = _host.Services.GetService(typeof(BlankViewModel));
        Assert.NotNull(vm);
    }

    [Fact]
    public void TestGetBlankPageType()
    {
        if (_host.Services.GetService(typeof(IPageService)) is IPageService pageService)
        {
            var pageType = pageService.GetPageType(typeof(BlankViewModel).FullName);
            Assert.Equal(typeof(BlankPage), pageType);
        }
        else
        {
            Assert.True(false, $"Can't resolve {nameof(IPageService)}");
        }
    }
}
