using PCInfo.Models;
using System.Net;
using System.Net.NetworkInformation;

namespace PCInfo.Services;

public class NetworkInfoService
{
    public NetworkInfo GetNetworkInfo()
    {
        var info = new NetworkInfo
        {
            Hostname = Dns.GetHostName(),
            Domain = IPGlobalProperties.GetIPGlobalProperties().DomainName
        };

        var host = Dns.GetHostEntry(info.Hostname);
        info.IPAddresses = host.AddressList
            .Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            .Select(ip => ip.ToString())
            .ToList();

        return info;
    }
}
