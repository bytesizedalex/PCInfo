namespace PCInfo.Models;

public class NetworkInfo
{
    public string Hostname { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public List<string> IPAddresses { get; set; } = new();
}
