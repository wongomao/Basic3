using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace TestXyzTransform;
public class Csv01Tester
{
    [Fact]
    public void Csv01TestSync()
    {
        // arrange
        string[] payments = new[]
        {
            "Mr. George,171,455.98,2022-02-14,utilities",
            "Katie Couric,172,13.55,2022-03-22,mental health"
        };
        string filename = "testcsv01.txt";
        File.WriteAllLines(filename, payments);
        XyzTransform.TransformCsv01 transformer = new();

        // act
        transformer.TransformFile(filename);

        // assert
        string[] actual = File.ReadAllLines(filename);
        Assert.Equal(payments.Length, actual.Length);
        Assert.Equal("2022-02-14,455.98", actual[0]);
        Assert.Equal("2022-03-22,13.55", actual[1]);
    }

    [Fact]
    public async Task Csv01TestAsync()
    {
        // arrange
        string[] payments = new[]
        {
            "Mr. George,171,455.98,2022-02-14,utilities",
            "Katie Couric,172,13.55,2022-03-22,mental health"
        };
        string filename = "testcsv01.txt";
        File.WriteAllLines(filename, payments);
        XyzTransform.TransformCsv01 transformer = new();

        // act
        await transformer.TransformFileAsync(filename);

        // assert
        string[] actual = File.ReadAllLines(filename);
        Assert.Equal(payments.Length, actual.Length);
        Assert.Equal("2022-02-14,455.98", actual[0]);
        Assert.Equal("2022-03-22,13.55", actual[1]);
    }
}
