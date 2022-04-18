using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestXyzTransform;
public class Csv02Tester
{
    [Fact]
    public void Csv02TestSync()
    {
        // arrange
        string[] ss = new string[]
        {
            "A|B|C|D|E|F|G|H|I|J|K|L",
            "a|b|c|d|e|f|g|h|i|j|k|l",
            "1|2|3|4|5|6|7|8|9|10|11|12",
            "aa|bb|cc|dd|ee|ff|gg|hh|ii|jj|kk|ll"
        };
        string filename = "testCsv02.txt";
        File.WriteAllLines(filename, ss, Encoding.UTF8);
        XyzTransform.Csv02 transformer = new XyzTransform.Csv02();

        // act
        transformer.TransformFile(filename);

        // assert
        string[] actual = File.ReadAllLines(filename);
        Assert.Equal(ss.Length, actual.Length);
        Assert.Equal("C|H|E", actual[0]);
        Assert.Equal("c|h|e", actual[1]);
        Assert.Equal("3|8|5", actual[2]);
    }

    [Fact]
    public async Task Csv02TestAsync()
    {
        // arrange
        string[] ss = new string[]
        {
            "A|B|C|D|E|F|G|H|I|J|K|L",
            "a|b|c|d|e|f|g|h|i|j|k|l",
            "1|2|3|4|5|6|7|8|9|10|11|12",
            "aa|bb|cc|dd|ee|ff|gg|hh|ii|jj|kk|ll"
        };
        string filename = "testCsv02.txt";
        File.WriteAllLines(filename, ss, Encoding.UTF8);
        XyzTransform.Csv02 transformer = new XyzTransform.Csv02();

        // act
        await transformer.TransformFileAsync(filename);

        // assert
        string[] actual = File.ReadAllLines(filename);
        Assert.Equal(ss.Length, actual.Length);
        Assert.Equal("C|H|E", actual[0]);
        Assert.Equal("c|h|e", actual[1]);
        Assert.Equal("3|8|5", actual[2]);
    }
}
