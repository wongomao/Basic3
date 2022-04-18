using Xunit;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestXyzTransform;
public class TransformTypesTester
{
    private string[] NewDaysList()
    {
        return new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
    }

    [Fact]
    public void TestDumbTransformSync()
    {
        // arrange
        string filename = "testDumb.txt";
        string[] daysList = NewDaysList();
        File.WriteAllLines(filename, daysList, Encoding.UTF8);
        XyzTransform.DumbTransform dumbTransform = new();

        // act
        dumbTransform.TransformFile(filename);

        // assert
        // to compare expected with actual, we need to read in the transformed file
        string[] actual = File.ReadAllLines(filename);
        string[] expected = NewDaysList();
        for (int i = 0; i < expected.Length; i++)
        {
            expected[i] = expected[i] + " dumb";
        }
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public async Task TestDumbTransformAsync()
    {
        // arrange
        string filename = "testDumb.txt";
        string[] daysList = NewDaysList();
        File.WriteAllLines(filename, daysList, Encoding.UTF8);
        XyzTransform.DumbTransform dumbTransform = new();

        // act
        await dumbTransform.TransformFileAsync(filename);

        // assert
        // to compare expected with actual, we need to read in the transformed file
        string[] actual = File.ReadAllLines(filename);
        string[] expected = NewDaysList();
        for (int i = 0; i < expected.Length; i++)
        {
            expected[i] = expected[i] + " dumb";
        }
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }
}
