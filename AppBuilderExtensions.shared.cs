using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui;
using Mads195.MadsMauiLib.Controls;
using Mads195.MadsMauiLib.Database.SQLite;
using Mads195.MadsMauiLib.ViewModels.Controls;
using Microsoft.Maui.Handlers;

namespace Mads195.MadsMauiLib
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseMadsMauiLib(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(static h =>
            {
                h.AddHandler(typeof(SectionTitle), typeof(ContentViewHandler));
            });
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("FontAwesome6Free-Solid-900.otf", "FontAwesome6FreeSolid");
                fonts.AddFont("FontAwesome6Free-Regular-400.otf", "FontAwesome6FreeRegular");
                fonts.AddFont("FontAwesome6Brands-Regular-400.otf", "FontAwesome6BrandsRegular");
            });

            builder.Services.AddSingleton<ISQLiteDb>(new SQLiteDb("MyAppData", FileSystem.AppDataDirectory));

            builder.Services.AddTransientPopup<FlexiDialog, FlexiDialogViewModel>();

            return builder;
        }
    }
}
