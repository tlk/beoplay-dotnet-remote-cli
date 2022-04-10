using Zeroconf;
using System.Text.Json.Nodes;

string? deviceName = Environment.GetEnvironmentVariable("DEVICE_NAME");

var remote = new BeoRemote(deviceName);
await remote.Setup();


if (args.Contains("GetVolume"))
{
    var volume = await remote.GetVolume();
    Console.WriteLine($"Current volume: {volume}");
}

foreach (var arg in args)
{
    await remote.SendSimpleCommand(arg);
}


class BeoRemote
{
    List<string> SimpleCommands = new List<string> { "Play", "Pause", "Stop", "Forward", "Backward", };
    HttpClient Client = new HttpClient();
    string? DisplayName;

    public BeoRemote(string? displayName)
    {
        DisplayName = displayName;
    }

    public async Task Setup()
    {
        IReadOnlyList<IZeroconfHost> results = await ZeroconfResolver.ResolveAsync("_beoremote._tcp.local.");
        
        var device = (DisplayName == null)
            ? results.FirstOrDefault()
            : results.Where(result => result.DisplayName == DisplayName).FirstOrDefault();

        if (device == null)
        {
            throw new Exception("No device(s) found on the network");
        }

        DisplayName = device.DisplayName;

        var ip = device.IPAddress.ToString();
        var port = device.Services.First().Value.Port;
        Uri endPoint = new Uri($"http://{ip}:{port}");
        Client.BaseAddress = endPoint;
    }

    public async Task<string> GetVolume()
    {
        string json = await Client.GetStringAsync("/BeoZone/Zone/Sound/Volume/Speaker/");
        return JsonNode.Parse(json)["speaker"]["level"].ToString();
    }

    public async Task SendSimpleCommand(string command)
    {
        if (SimpleCommands.Contains(command))
        {
            await Client.PostAsync($"/BeoZone/Zone/Stream/{command}", null);
        }
    }
}
