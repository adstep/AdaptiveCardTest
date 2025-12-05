namespace ExampleLibrary;

using AdaptiveCards.ObjectModel.WinUI3;
using AdaptiveCards.Rendering.WinUI3;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.CompilerServices;

public class Renderer
{
    public static FrameworkElement Render()
    {
        bool isDynamicCodeSupported = RuntimeFeature.IsDynamicCodeSupported;
        bool isReflectionPossible = IsReflectionPossible();

        string exampleCardJson = $$"""
{
    "type": "AdaptiveCard",
    "version": "1.0",
    "body": [
        {
            "type": "TextBlock",
            "text": "Here is not a ninja cat!"
        },
        {
            "type": "TextBlock",
            "text": "IsDynamicCodeSupported: {{isDynamicCodeSupported}}"
        },
        {
            "type": "TextBlock",
            "text": "IsReflectionPossible: {{isReflectionPossible}}"
        },
        {
            "type": "Image",
            "url": "http://adaptivecards.io/content/cats/1.png"
        }
    ]
}
""";

        var renderer = new AdaptiveCardRenderer();

        var adaptiveCardParseResult = AdaptiveCard.FromJsonString(exampleCardJson);

        RenderedAdaptiveCard renderedAdaptiveCard =  renderer.RenderAdaptiveCard(adaptiveCardParseResult.AdaptiveCard);

        if (renderedAdaptiveCard == null)
        {
            throw new InvalidOperationException("Rendering failed.");
        }

        Console.WriteLine("Adaptive Card rendered successfully.");

        return renderedAdaptiveCard.FrameworkElement;
    }

    // Simple test method that does nothing - used only for reflection testing
    private static int ReflectionTestHelper() => 42;

    static bool IsReflectionPossible()
    {
        try
        {
            // Try to dynamically invoke a method - this is what really tests reflection capability
            var assembly = typeof(Renderer).Assembly;
            var type = assembly.GetType("ExampleLibrary.Renderer");
            var method = type?.GetMethod("ReflectionTestHelper", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            
            if (method == null)
            {
                return false;
            }
            
            // Actually invoke it - this will fail with Native AOT
            var result = method.Invoke(null, null);
            return result is int && (int)result == 42;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
