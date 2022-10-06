using CommunityToolkit.Maui.Converters;
using QRCS.Core.Models;
using System.Globalization;
using ZXing.Net.Maui;

namespace QRCS.Converters;

public class BarcodeDetectionEventArgsConverter : BaseConverterOneWay<BarcodeDetectionEventArgs, object>
{
    public override object DefaultConvertReturnValue { get; set; } = null;

    public override object ConvertFrom(BarcodeDetectionEventArgs value, CultureInfo culture)
    {
        return new Scan(DateTime.Now, value.Results.First().Value);
    }
}


