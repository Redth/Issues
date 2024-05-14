﻿using System;
using System.IO;
using System.Text;
using Microsoft.Maui.Storage;

namespace MauiAppLlvmReadAsync
{
    public partial class MainPage
    {
        private readonly string _path;
        private readonly string _fileSrc;

        public MainPage()
        {
            InitializeComponent();

            _path = FileSystem.Current.CacheDirectory;
            _fileSrc = Path.Combine(_path, $"test_src_{Guid.NewGuid()}.txt");

            // create big file
            var sb = new StringBuilder();
            for (var i = 0; i < 10000; ++i)
            {
                sb.AppendLine("Hello world");
            }
            File.WriteAllText(_fileSrc, sb.ToString());
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            try
            {
                await using var sourceStream = File.Open(_fileSrc, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var result = new byte[sourceStream.Length];
                await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
                var content = Encoding.ASCII.GetString(result);

                await DisplayAlert("Success", $"{content}{Environment.NewLine}File read successfully", "OK");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                await DisplayAlert("Error", exception.ToString(), "OK");
            }
        }
    }
}
