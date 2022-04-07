using static System.Console;

//string address = "https://raw.githubusercontent.com/microsoft/Windows-universal-samples/main/Samples/HttpClient/cs/Scenario02_GetStream.xaml.cs";
string address = "https://gist.githubusercontent.com/suellenstringer-hye/f2231b3383538bcb1a5b051c7908f5b7/raw/0f4e0733a434733cda8e749bbbf33a93c2b5bbde/test.csv";

try
{
    using (HttpClient client = new())
    {
        var downloadStream = client.GetStreamAsync(address).Result;
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), $"downloaded{DateTime.Now.ToString("yyMMddmm")}.csv");
        var file = new FileInfo(fileName);
        using (downloadStream)
        using (var fileStream = file.Create())
        {
            downloadStream.CopyTo(fileStream);
        }
        WriteLine($"-- downloaded to {fileName} --");
    }
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}
