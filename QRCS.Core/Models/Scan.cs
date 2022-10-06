namespace QRCS.Core.Models;

public class Scan
{
    public DateTime Date { get; set; }
    public string Result { get; set; }

    public Scan(DateTime date, string result)
    {
        Date = date;
        Result = result;
    }
}


