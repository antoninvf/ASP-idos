using System.Web;
using ASP_idos.ViewModels;
using Newtonsoft.Json;
using Unidecode.NET;

namespace ASP_idos.Repository;

public class StopRepository
{
    private List<StopGroup> _stopGroups = new List<StopGroup>();

    public StopRepository()
    {
        loadStopGroups();
    }

    // Loads from JSON file
    private void loadStopGroups()
    {
        var json = File.ReadAllText("stops.json");
        dynamic stops = JsonConvert.DeserializeObject(json) ?? throw new InvalidOperationException();
        _stopGroups = stops.stopGroups.ToObject<List<StopGroup>>();
        Console.WriteLine($"Loaded {_stopGroups.Count} stop groups");
    }

    public List<StopGroup> GetStopGroupsBy(object? searchInput)
    {
        if (searchInput is null) searchInput = "";

        // Pagination
        if (searchInput.ToString()?.Trim() == "") return _stopGroups.Take(10).ToList();

        var search = _stopGroups.Where(sg => sg.Name.Unidecode().Trim().ToLower().StartsWith(searchInput.ToString()?.Unidecode().Trim().ToLower() ?? string.Empty)).ToList();

        // If no results, try to find by line numbers
        if (search.Count == 0)
        {
            search = _stopGroups.Where(sg => sg.Stops.Any(s => s.Lines.Any(l => l.Id == searchInput.ToString()?.Trim()))).ToList();
        }

        return search;
    }

    public List<StopGroup> GetStopGroupsByLine(Line? line)
    {
        return _stopGroups.Where(sg => sg.Stops.Any(s => s.Lines.Any(l => l.Id == line.Id))).ToList();
    }

    public List<Line> GetAllLines()
    {
        return _stopGroups.SelectMany(sg => sg.Stops).SelectMany(s => s.Lines).ToList().DistinctBy(l => l.Id).ToList().Take(10).ToList();
    }

    public Line? GetLineBy(object? searchInput)
    {
        if (searchInput is null) searchInput = "";
        if (searchInput.ToString()?.Trim() == "") return new Line();

        return _stopGroups.SelectMany(sg => sg.Stops).SelectMany(s => s.Lines).FirstOrDefault(l => l.Id == searchInput.ToString()?.Trim());
    }
}