using MangaLibrary.Shared.Attributes;
//using MangaLibrary.Server.Services;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Enums;

//[JsonConverter(typeof(GenresJsonConverter))]
public enum Genres : byte
{
    [Description("Exciting action sequences take priority and significant conflicts between characters are usually resolved with one's physical power.")]
    Action = 1,
    [Description("Whether aiming for a specific goal or just struggling to survive, the main character is thrust into unfamiliar situations or lands and continuously faces unexpected dangers.")]
    Adventure,
    [Description("Uplifting the audience with positive emotion takes priority, eliciting laughter, amusement, or general entertainment.")]
    Comedy,
    [Description("Self-explanatory name, stories of this genre can be more relaxing and about trying rich and tasty food or be about dynamic, stressful work in the kitchen.")]
    Cooking,
    [Description("A theme within the Mystery genre, these stories feature either a detective or amateur investigator working to solve a crime or puzzling event.")]
    Detective,
    [Description("Plot-driven stories focused on realistic characters experiencing human struggle.")]
    Drama,
    [Description("Magical powers, unnatural creatures, or other unreal elements which cannot be explained by science are prevalent and normal to the setting they exist in.")]
    Fantasy,
    [Description("Creating—and maintaining—a sense of dread in the audience takes priority, eliciting shock, fear, or disgust through atmosphere and frightening scenarios.")]
    Horror,
    [Description("Stories about life of Japanese idols.")]
    Idols,
    [Description("Protagonist getting transferred into another, unknown world.")]
    Isekai  ,
    [Description("Piloting giant humanoid robots.")]
    Mecha,
    [Description("Whether its solving a crime or finding an explanation for a puzzling circumstance, the main cast willingly or reluctantly become investigators who must work to answer the who, what, why, and/or how of the current dilemma.")]
    Mystery,
    [Description("Survival after end of the world.", Name = "Post-apocalypse")]
    PostApocalypse,
    [Description("Falling in love and struggling to progress towards—or maintain—a romantic relationship take priority, while other subplots either take backseat or are designed to develop the main love story.")]
    Romance,
    [Description("Imagined technological advancements or natural settings which are currently unreal in the present day but could be invented, caused, or explained by science in the future.", Name = "Si-Fi")]
    SiFi,
    [Description("Slice of Life stories are focused on a seemingly random and mundane period of the main characters' lives.", Name = "Slice of Life")]
    SliceOfLife,
    [Description("Training for and participating in a sport take priority, with the goal of furthering one's athletic abilities—either to win a competition or achieve some social standing.")]
    Sports,
    [Description("Tough life under constant threat of death.")]
    Survival,
    [Description("Heroic fantasy. Subgenre of fantasy characterized by sword-wielding heroes engaged in exciting and violent adventures.", Name = "Sword and Sorcery")]
    SwordAndSorcery,
    [Description("Characterized and defined by the elicit moods, giving their audiences heightened feelings of suspense, excitement, surprise, anticipation and anxiety.")]
    Thriller
}
