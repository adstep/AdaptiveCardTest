// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExampleOldLibrary;

using AdaptiveCards.ObjectModel.WinUI3;
using System;

public partial class Parser
{
    public static void Parse()
    {
        AdaptiveCardParseResult result = AdaptiveCard.FromJsonString(string.Empty);

        if (result.Errors.Count != 1)
        {
            throw new InvalidOperationException("Unexpected number of errors.");
        }

        if (result.Errors[0].StatusCode != ErrorStatusCode.InvalidJson)
        {
            throw new InvalidOperationException("Unexpected error code.");
        }

        Console.WriteLine("AdaptiveCard parsing produced expected error.");
    }
}
