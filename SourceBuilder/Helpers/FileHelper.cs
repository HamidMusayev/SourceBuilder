﻿using System.Text;
using System.Text.Json;
using SourceBuilder.Models;

namespace SourceBuilder.Helpers;

public class FileHelper
{
    public static async Task<List<Entity>> ReadJsonAsync()
    {
        var projectPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
        var filePath = Path.Combine(projectPath, Constants.DataFileName);

        using var r = new StreamReader(filePath);

        var json = await r.ReadToEndAsync();
        var data = JsonSerializer.Deserialize<List<Entity>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

        return data;
    }

    public static async Task<bool> CreateFileAsync(SourceFile sourceFile)
    {
        var projectPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!.FullName;
        var filePath = Path.Combine(projectPath, sourceFile.Path);

        await using var fs = File.Create(filePath);

        var title = new UTF8Encoding(true).GetBytes(sourceFile.Text);
        await fs.WriteAsync(title);

        return true;
    }

    // public async void WriteJson(string destination)
    // {
    //     var jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions { WriteIndented = true });
    //     using (var outputFile = new StreamWriter("dataReady.json"))
    //     {
    //         await outputFile.WriteLineAsync(jsonString);
    //     }
    // }
}