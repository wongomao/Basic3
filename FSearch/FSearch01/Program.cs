using static System.Console;
using CsvHelper;
using System.Globalization;

string pathToFiles = GetSearchPath(args);
var files = Directory.GetFiles(pathToFiles);
if (files.Length <= 0)
{
    WriteLine("Found no files.");
    return;
}

foreach (var file in files)
{
    string? ext = System.IO.Path.GetExtension(file);
    if (ext.ToLower() == ".csv")
    {
        WriteLine($"----------{file}------------");
        ProcessFile(file);
    }
}

// ============================================================================

static void ProcessFile(string file)
{
    using (var reader = new StreamReader(file))
    {
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            // skip two lines
            csv.Read();
            csv.Read();
            // read header
            csv.Read();
            csv.ReadHeader();
            var hdr = csv.HeaderRecord;
            
            WriteLine("{0,10}{1,20}",
                hdr[0],
                hdr[8]);
            //int count = 0;
            while (csv.Read())
            {
                string line = string.Format("{1,20}{0,10}",
                    csv.GetField(0),
                    csv.GetField(8));
                WriteLine(line);
            }

        }
    }
}

// ============================================================================

static string GetSearchPath(string[] args)
{
    string? pathToFiles;
    if (args.Length > 0)
    {
        pathToFiles = Path.GetFullPath(args[0]);
    }
    else
    {
        pathToFiles = Directory.GetCurrentDirectory();
    }
    if (pathToFiles is null || !Directory.Exists(pathToFiles))
    {
        throw new ArgumentException("Bad path");
    }
    return pathToFiles;
}
