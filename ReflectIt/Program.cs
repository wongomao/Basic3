using static System.Console;
using ReflectIt;
using System.Reflection;
using XyzTransform;

//await MyTransform();
await Csv01Transform();

// =======================================================================

#pragma warning disable CS8321 // Local function is declared but never used
static async Task MyTransform()
{
    string filename = Path.Combine(Environment.CurrentDirectory, "test.txt");
    DumbTransform dumbTransform = new();
    WriteLine($"doing transform {dumbTransform.Id}");
    await dumbTransform.TransformFileAsync(filename);
}
#pragma warning restore CS8321 // Local function is declared but never used

static async Task Csv01Transform()
{
    string filename = Path.Combine(Directory.GetCurrentDirectory(), "csv01Example.csv");
    TransformCsv01 transform = new();
    await transform.TransformFileAsync(filename);
}


// =======================================================================

#pragma warning disable CS8321 // Local function is declared but never used
static void DoTypeStuff()
{
    ShowSimpleTypes();
    ShowPropertiesOf(typeof(Account));
    ShowPropertiesOf(typeof(Payer));
    ShowPropertiesOf(typeof(System.Environment));
    ShowPropertiesOf(typeof(System.Environment.SpecialFolder));
}
#pragma warning restore CS8321 // Local function is declared but never used

// =======================================================================
static void ShowSimpleTypes()
{
    Type t1 = DateTime.Now.GetType(); // runtime
    Type t2 = typeof(DateTime); // compile time
    WriteLine(t1);
    WriteLine(t2);
    WriteLine(typeof(Account));
    WriteLine();

    Type t3 = typeof(DateTime[]);          // 1-d Array type
    Type t4 = typeof(DateTime[,]);         // 2-d Array type
    Type t5 = typeof(Dictionary<int, int>); // Closed generic type
    Type t6 = typeof(Dictionary<,>);       // Unbound generic type
    WriteLine($"t3 is type {t3}");
    WriteLine($"t4 is type {t4}");
    WriteLine($"t5 is type {t5}");
    WriteLine($"t6 is type {t6}");
    //WriteLine($"xxxx is type {yyyyy}");
    WriteLine();

    Type t7 = Assembly.GetExecutingAssembly().GetType();
    WriteLine($"t7 is type {t7}");
    Type? t8 = Type.GetType("System.Int32, System.Private.CoreLib");
    WriteLine($"t8 is type {t8}");
    WriteLine();
}

// =======================================================================
static void ShowPropertiesOf(Type t)
{
    WriteLine($"Showing properties for {t}:");
    WriteLine($"\tNamespace = {t.Namespace}");
    WriteLine($"\tName = {t.Name}");
    WriteLine($"\tFullName = {t.FullName}");
    WriteLine($"\tBaseType = {t.BaseType}");
    WriteLine($"\tAssembly = {t.Assembly}");
    WriteLine($"\tIsPublic = {t.IsPublic}");
    if (t.GetNestedTypes().Any())
    {
        foreach (Type aType in t.GetNestedTypes())
        {
            WriteLine($"\t\tnested type {aType}");
        }
    }
    else
    {
        WriteLine("\tno nested types");
    }
    
    WriteLine();
}

