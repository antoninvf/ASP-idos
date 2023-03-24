namespace ASP_idos.ViewModels;

public class Stop
{
    public string Id { get; set; }
    public string AltIdosName { get; set; }
    public string Platform { get; set; }
    public List<Line> Lines { get; set; }
}