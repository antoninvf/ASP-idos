using System;

namespace ASP_idos.ViewModels;

public class Line
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Direction { get; set; }
    public string Direction2 { get; set; }
    public string Type { private get; set; }

    public string GetLineType()
    {
        try
        {
            return string.Concat(Type[0].ToString().ToUpper(), Type.AsSpan(1));
        }
        catch
        {
            return "";
        }
    }

    public string GetLineEmoji()
    {
        return Type switch
        {
            "metro" => "🚇",
            "tram" => "🚋",
            "train" => "🚆",
            "bus" => "🚌",
            "funicular" => "🚠",
            "ferry" => "⛴️",
            "trolleybus" => "🚎",
            _ => Type
        };
    }

    public List<string> Directions
    {
        get
        {
            var directions = new List<string>();
            if (Direction != null)
            {
                directions.Add(Direction);
            }

            if (Direction2 != null)
            {
                directions.Add(Direction2);
            }

            return directions;
        }
    }
}