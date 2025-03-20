using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadsMauiLib
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseMadsMauiLib(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(static h =>
            {
            });

            return builder;
        }
    }
}
