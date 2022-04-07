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
<<<<<<< HEAD
            //// skip two lines
            //csv.Read();
            //csv.Read();

=======
            // skip two lines
            csv.Read();
            csv.Read();
>>>>>>> ccc77da2daa29732d28b9e811672429afd13b0df
            // read header
            csv.Read();
            csv.ReadHeader();
            var hdr = csv.HeaderRecord;
            
<<<<<<< HEAD
            WriteLine("{1,20}{0,10}",
                hdr[0],
                hdr[5]);
=======
            WriteLine("{0,10}{1,20}",
                hdr[0],
                hdr[8]);
>>>>>>> ccc77da2daa29732d28b9e811672429afd13b0df
            //int count = 0;
            while (csv.Read())
            {
                string line = string.Format("{1,20}{0,10}",
                    csv.GetField(0),
<<<<<<< HEAD
                    csv.GetField(5));
=======
                    csv.GetField(8));
>>>>>>> ccc77da2daa29732d28b9e811672429afd13b0df
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
