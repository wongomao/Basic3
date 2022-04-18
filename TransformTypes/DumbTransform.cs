namespace XyzTransform;
public class DumbTransform : IXyzTransform
{
    public string Id => "dumb";

    public void TransformFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<string> newLines = new();
        foreach (string line in lines)
        {
            newLines.Add(line + " dumb");
        }
        File.WriteAllLines(filename, newLines);
    }

    public async Task TransformFileAsync(string filename)
    {
        string[] lines = await File.ReadAllLinesAsync(filename);
        List<string> newLines = new();
        foreach (string line in lines)
        {
            newLines.Add(line + " dumb");
        }
        await File.WriteAllLinesAsync(filename, newLines);
    }

}
