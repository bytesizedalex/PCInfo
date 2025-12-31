using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PCInfo.Models;
using PCInfo.Services;
using System.Windows;

namespace PCInfo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly NetworkInfoService _networkService = new();
    private readonly ConnectivityService _connectivityService = new();

    [ObservableProperty]
    private NetworkInfo _networkInfo = new();

    [ObservableProperty]
    private string _testUrl = "https://ipv4.icanhazip.com";

    [ObservableProperty]
    private string _connectivityStatus = string.Empty;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    public MainViewModel()
    {
        LoadNetworkInfo();
    }

    private void LoadNetworkInfo()
    {
        NetworkInfo = _networkService.GetNetworkInfo();
    }

    [RelayCommand]
    private void CopyHostname() =>
        Clipboard.SetText(NetworkInfo.Hostname);

    [RelayCommand]
    private void CopyDomain() =>
        Clipboard.SetText(NetworkInfo.Domain);

    [RelayCommand]
    private void CopyIp(string ip) =>
        Clipboard.SetText(ip);

    [RelayCommand]
    private async Task TestConnectivity()
    {
        StatusMessage = "Testing connectivity...";

        bool ok = await _connectivityService.TestUrlAsync(TestUrl);

        ConnectivityStatus = ok ? "Connection successful" : "Connection failed";
        StatusMessage = "Ready";
    }
}
