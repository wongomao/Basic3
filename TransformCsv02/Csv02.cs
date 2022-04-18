using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Dynamic;

namespace XyzTransform;
public class Csv02 : IXyzTransform
{
    public string Id => "Csv02";

    private readonly CsvConfiguration _config;
    public Csv02()
    {
        _config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|",
            HasHeaderRecord = false,
            Encoding = Encoding.UTF8
        };
    }

    public void TransformFile(string filename)
    {
        List<string[]> recordsIn = new();
        using (StreamReader sr = new StreamReader(filename))
        using (CsvReader csv = new(sr, _config))
        {
            while (csv.Read())
            {
                if (csv.Parser.Count <= 0)
                {
                    continue;
                }
                string[] recordIn = new string[csv.Parser.Count];
                for (int i = 0; i < csv.Parser.Count; i++)
                {
                    recordIn[i] = csv.Parser[i].ToString();
                }
                recordsIn.Add(recordIn);
            }
        }

        List<string[]> recordsOut = new();
        foreach (string[] recordIn in recordsIn)
        {
            string[] recordOut = new string[3]
            {
                recordIn[2], recordIn[7], recordIn[4]
            };
            recordsOut.Add(recordOut);
        }

        using (StreamWriter sw = new(filename))
        using (CsvWriter csv = new(sw, _config))
        {
            foreach (var recordOut in recordsOut)
            {
                foreach (var field in recordOut)
                {
                    csv.WriteField(field);
                }
                csv.NextRecord();
            }
        }
    }

    public async Task TransformFileAsync(string filename)
    {
        List<string[]> recordsIn = new();
        using (StreamReader sr = new StreamReader(filename))
        using (CsvReader csv = new(sr, _config))
        {
            while (await csv.ReadAsync())
            {
                if (csv.Parser.Count <= 0)
                {
                    continue;
                }
                string[] recordIn = new string[csv.Parser.Count];
                for (int i = 0; i < csv.Parser.Count; i++)
                {
                    recordIn[i] = csv.Parser[i].ToString();
                }
                recordsIn.Add(recordIn);
            }
        }

        List<string[]> recordsOut = new();
        foreach (string[] recordIn in recordsIn)
        {
            string[] recordOut = new string[3]
            {
                recordIn[2], recordIn[7], recordIn[4]
            };
            recordsOut.Add(recordOut);
        }

        using (StreamWriter sw = new(filename))
        using (CsvWriter csv = new(sw, _config))
        {
            foreach (var recordOut in recordsOut)
            {
                foreach (var field in recordOut)
                {
                    csv.WriteField(field);
                }
                await csv.NextRecordAsync();
            }
        }
    }
}
