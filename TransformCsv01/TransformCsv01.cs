using CsvHelper;
using CsvHelper.Configuration;
using System.Dynamic;
using System.Globalization;
namespace XyzTransform;

public class TransformCsv01 : IXyzTransform
{
    public string Id => "Csv01";

    private readonly CsvConfiguration _configuration;
    public TransformCsv01()
    {
        _configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ",",
            HasHeaderRecord = false
        };
    }
    public void TransformFile(string filename)
    {
        IEnumerable<PaymentInRec>? paymentsIn = null;
        List<PaymentOutRec>? paymentsOut = new();
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, _configuration))
        {
            paymentsIn = csv.GetRecords<PaymentInRec>();
            foreach (var pay in paymentsIn)
            {
                paymentsOut.Add(new PaymentOutRec(pay));
            }
        }

        if (paymentsOut.Count() > 0)
        {
            using (var writer = new StreamWriter(filename))
            using (var csvw = new CsvWriter(writer, _configuration))
            {
                csvw.WriteRecords(paymentsOut);
            }
        }
    }

    public async Task TransformFileAsync(string filename)
    {
        IEnumerable<PaymentInRec>? paymentsIn = null;
        List<PaymentOutRec>? paymentsOut = new();
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, _configuration))
        {
            paymentsIn = csv.GetRecords<PaymentInRec>();
            foreach (var pay in paymentsIn)
            {
                paymentsOut.Add(new PaymentOutRec(pay));
            }
        }

        if (paymentsOut.Count() > 0)
        {
            using (var writer = new StreamWriter(filename))
            using (var csvw = new CsvWriter(writer, _configuration))
            {
                await csvw.WriteRecordsAsync(paymentsOut);
            }
        }
    }

    public class PaymentInRec
    {
        public string? Payee { get; set; }
        public string? PaymentId { get; set; }
        public string? Amount { get; set; }
        public string? Date { get; set; }
        public string? Category { get; set; }
    }

    public class PaymentOutRec
    {
        public PaymentOutRec(PaymentInRec p)
        {
            this.Date = p.Date;
            this.Amount = p.Amount;
        }
        public string? Date { get; set; }
        public string? Amount { get; set; }
    }
}
