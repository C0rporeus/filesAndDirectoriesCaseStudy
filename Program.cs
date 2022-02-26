using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json; 

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);
var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

Console.WriteLine(salesData?.Total);

var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);

File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data?.Total}{Environment.NewLine}");
File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data?.Total.ToString());



foreach (var file in salesFiles)
{
  Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
  List<string> salesFiles = new List<string>();
  var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

  foreach (var file in foundFiles)
  {
    if (file.EndsWith("sales.json"))
    {
      salesFiles.Add(file);
    }
  }
  return salesFiles;
}

string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

FileInfo info = new FileInfo(fileName);

Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");

class SalesTotal
{
  public double Total { get; set; }
}