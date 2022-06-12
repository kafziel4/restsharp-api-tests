using RestSharpTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTests.Data
{
    static internal class Colors
    {
        static private readonly List<ColorData> _data = new()
        {
            new ColorData { Id = 1, Name = "cerulean", Year = 2000, Color = "#98B2D1", PantoneValue = "15-4020" },
            new ColorData { Id = 2, Name = "fuchsia rose", Year = 2001, Color = "#C74375", PantoneValue = "17-2031" },
            new ColorData { Id = 3, Name = "true red", Year = 2002, Color = "#BF1932", PantoneValue = "19-1664" },
            new ColorData { Id = 4, Name = "aqua sky", Year = 2003, Color = "#7BC4C4", PantoneValue = "14-4811" },
            new ColorData { Id = 5, Name = "tigerlily", Year = 2004, Color = "#E2583E", PantoneValue = "17-1456" },
            new ColorData { Id = 6, Name = "blue turquoise", Year = 2005, Color = "#53B0AE", PantoneValue = "15-5217" },
        };

        static public List<ColorData> GetColors()
        {
            return _data;
        }
    }
}
