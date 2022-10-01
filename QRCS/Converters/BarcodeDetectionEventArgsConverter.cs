using CommunityToolkit.Maui.Converters;
using System.Globalization;
using ZXing.Net.Maui;

namespace QRCS.Converters;

public class BarcodeDetectionEventArgsConverter : BaseConverterOneWay<BarcodeDetectionEventArgs, object>
{
    public override object DefaultConvertReturnValue { get; set; } = null;

    public override object ConvertFrom(BarcodeDetectionEventArgs value, CultureInfo culture)
    {
        return value.Results.First().Value;
    }
}


