﻿using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiAppBenchmarkBindings
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureClassLibrary1()
                .UseMauiApp<App>();

            return builder.Build();
        }
    }
}
