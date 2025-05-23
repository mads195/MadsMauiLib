using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Helpers
{
    public static class ResourceColorHelper
    {
        public static string GetColorHex(string resourceKey)
        {
            if (Application.Current.Resources.TryGetValue(resourceKey, out var colorObj) && colorObj is Color color)
            {
                return color.ToArgbHex(); // .NET MAUI extension for hex (e.g., #FF4081)
            }
            return "#000000"; // fallback or raise exception depending on needs
        }
    }
}
