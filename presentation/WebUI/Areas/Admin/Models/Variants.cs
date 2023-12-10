using ECommerse.Core.Enums;

namespace ECommerse.WebUI.Areas.Admin.Models;

public class Variants
{
    public Variants()
    {
        colors = new List<string>
        {
            Color.Red.ToString(),
            Color.Green.ToString(),
            Color.Blue.ToString()
        };

        sizes = new List<string>
        {
            Size.S.ToString(),
            Size.M.ToString(),
            Size.L.ToString()
        };

        materials = new List<string>
        {
            Material.Wool.ToString(),
            Material.Polyester.ToString(),
            Material.Leather.ToString()
        };
    }
    public IEnumerable<string> colors { get; set; }

    public IEnumerable<string> sizes { get; set; } 

    public IEnumerable<string> materials { get; set; }
}
