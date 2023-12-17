using Microsoft.AspNetCore.Components;

namespace MangaLibrary.Client.Services;

public static class Tools
{
    public static MarkupString GetStars(float rating, byte fontSize = 16)
    {
        const byte min = 0;
        const byte max = 5;

        int stars = max - (int)Math.Round(rating);
        int offset = 7 * stars;

        ReadOnlySpan<char> full = "★★★★★".AsSpan(min, max - stars);
        ReadOnlySpan<char> hollow = "☆☆☆☆☆".AsSpan(min, stars);
        ReadOnlySpan<char> color = "#F42536#DF2130#D23D20#E4E418#2569F4#C0C0C0".AsSpan(offset, 7);

        return new MarkupString($"<p style='color: {color}; margin: 0; text-shadow: 0 1px 1px #1C1C1C; font-size: {fontSize}px'>{full}{hollow}</p>");
    }
}
