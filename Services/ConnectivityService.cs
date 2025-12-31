using System.Net.Http;

namespace PCInfo.Services;

public class ConnectivityService
{
    private readonly HttpClient _client = new();

    public async Task<bool> TestUrlAsync(string url)
    {
        try
        {
            using var response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}
