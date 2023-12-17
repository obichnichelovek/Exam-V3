using MangaLibrary.Shared.Attributes;
using MangaLibrary.Shared.Enums;
using MangaLibrary.Shared.Models;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace MangaLibrary.Shared.Services;

internal static class Tools
{
    public static string GetEnumDescription(Tags tag)
    {
        var fieldInfo = tag.GetType().GetField(GetEnumName(tag));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Description;
    }

    public static string GetEnumDescription(Genres genre)
    {
        var fieldInfo = genre.GetType().GetField(GetEnumName(genre));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Description;
    }

    public static string? GetCustomName(Genres genre)
    {
        var fieldInfo = genre.GetType().GetField(GetEnumName(genre));
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        return attributes![0].Name;
    }

    public static string FixCase(string name)
    {
        var sb = new StringBuilder(name.Length * 2);
        sb.Append(name[0]);

        for (byte i = 1; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]))
                if ((name[i - 1] != ' ' && !char.IsUpper(name[i - 1])) ||
                    (char.IsUpper(name[i - 1]) &&
                     i < name.Length - 1 && !char.IsUpper(name[i + 1])))
                    sb.Append(' ');
            sb.Append(name[i]);
        }
        return sb.ToString();
    }

    public static TagSearchOptions GetEnumFromString(string value)
    {
        return value switch
        {
            "And" => TagSearchOptions.And,
            "Or" =>TagSearchOptions.Or,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
    }

    public static string GetEnumName(TagSearchOptions options)
    {
        return options switch
        {
            TagSearchOptions.And => nameof(TagSearchOptions.And),
            TagSearchOptions.Or => nameof(TagSearchOptions.Or),
            _ => throw new ArgumentOutOfRangeException(nameof(options), options, null)
        };
    }

    #region Tags
    public static string GetEnumName(Tags tag)
    {
        return tag switch
        {
            Tags.Alchemy => nameof(Tags.Alchemy),
            Tags.Amnesia => nameof(Tags.Amnesia),
            Tags.Angels => nameof(Tags.Angels),
            Tags.Anthropomorphic => nameof(Tags.Anthropomorphic),
            Tags.DemiHuman => nameof(Tags.DemiHuman),
            Tags.Blackmail => nameof(Tags.Blackmail),
            Tags.CruelWorld => nameof(Tags.CruelWorld),
            Tags.Cyberpunk => nameof(Tags.Cyberpunk),
            Tags.Demons => nameof(Tags.Demons),
            Tags.Dragons => nameof(Tags.Dragons),
            Tags.DumbProtagonist => nameof(Tags.DumbProtagonist),
            Tags.Dungeon => nameof(Tags.Dungeon),
            Tags.Elves => nameof(Tags.Elves),
            Tags.Empires => nameof(Tags.Empires),
            Tags.FemaleProtagonist => nameof(Tags.FemaleProtagonist),
            Tags.Future => nameof(Tags.Future),
            Tags.Gambling => nameof(Tags.Gambling),
            Tags.Ghosts => nameof(Tags.Ghosts),
            Tags.Gods => nameof(Tags.Gods),
            Tags.Gore => nameof(Tags.Gore),
            Tags.Gyaru => nameof(Tags.Gyaru),
            Tags.Harem => nameof(Tags.Harem),
            Tags.Hikikomori => nameof(Tags.Hikikomori),
            Tags.Knights => nameof(Tags.Knights),
            Tags.LGBTQ => nameof(Tags.LGBTQ),
            Tags.Mafia => nameof(Tags.Mafia),
            Tags.Mages => nameof(Tags.Mages),
            Tags.MagicAcademy => nameof(Tags.MagicAcademy),
            Tags.Maids => nameof(Tags.Maids),
            Tags.MaleProtagonist => nameof(Tags.MaleProtagonist),
            Tags.Medieval => nameof(Tags.Medieval),
            Tags.Military => nameof(Tags.Military),
            Tags.Monstergirls => nameof(Tags.Monstergirls),
            Tags.Music => nameof(Tags.Music),
            Tags.Mythology => nameof(Tags.Mythology),
            Tags.Ninja => nameof(Tags.Ninja),
            Tags.Parody => nameof(Tags.Parody),
            Tags.Pirates => nameof(Tags.Pirates),
            Tags.Politics => nameof(Tags.Politics),
            Tags.Psychological => nameof(Tags.Psychological),
            Tags.Quests => nameof(Tags.Quests),
            Tags.Reincarnation => nameof(Tags.Reincarnation),
            Tags.Robots => nameof(Tags.Robots),
            Tags.Samurais => nameof(Tags.Samurais),
            Tags.Slaves => nameof(Tags.Slaves),
            Tags.SmartProtagonist => nameof(Tags.SmartProtagonist),
            Tags.Steampunk => nameof(Tags.Steampunk),
            Tags.Supernatural => nameof(Tags.Supernatural),
            Tags.Undead => nameof(Tags.Undead),
            Tags.Vampires => nameof(Tags.Vampires),
            Tags.Vengeance => nameof(Tags.Vengeance),
            Tags.Videogames => nameof(Tags.Videogames),
            Tags.VirtualReality => nameof(Tags.VirtualReality),
            Tags.Witch => nameof(Tags.Witch),
            Tags.Yakuza => nameof(Tags.Yakuza),
            Tags.Yandere => nameof(Tags.Yandere),
            Tags.Zombies => nameof(Tags.Zombies),
            _ => throw new ArgumentOutOfRangeException(nameof(tag), tag, null)
        };
    }
    #endregion

    #region Genres
    public static string GetEnumName(Genres genre)
    {
        return genre switch
        {
            Genres.Action => nameof(Genres.Action),
            Genres.Adventure => nameof(Genres.Adventure),
            Genres.Comedy => nameof(Genres.Comedy),
            Genres.Cooking => nameof(Genres.Cooking),
            Genres.Detective => nameof(Genres.Detective),
            Genres.Drama => nameof(Genres.Drama),
            Genres.Fantasy => nameof(Genres.Fantasy),
            Genres.Horror => nameof(Genres.Horror),
            Genres.Idols => nameof(Genres.Idols),
            Genres.Isekai => nameof(Genres.Isekai),
            Genres.Mecha => nameof(Genres.Mecha),
            Genres.Mystery => nameof(Genres.Mystery),
            Genres.PostApocalypse => nameof(Genres.PostApocalypse),
            Genres.Romance => nameof(Genres.Romance),
            Genres.SiFi => nameof(Genres.SiFi),
            Genres.SliceOfLife => nameof(Genres.SliceOfLife),
            Genres.Sports => nameof(Genres.Sports),
            Genres.Survival => nameof(Genres.Survival),
            Genres.SwordAndSorcery => nameof(Genres.SwordAndSorcery),
            Genres.Thriller => nameof(Genres.Thriller),
            _ => throw new ArgumentOutOfRangeException(nameof(genre), genre, null)
        };
    }
    #endregion
}
