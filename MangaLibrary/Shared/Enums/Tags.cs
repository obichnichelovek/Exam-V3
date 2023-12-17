using MangaLibrary.Shared.Attributes;
//using MangaLibrary.Shared.Services;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Enums;

//[JsonConverter(typeof(TagsJsonConverter))]
public enum Tags : byte
{
    [Description("Attempt to purify, mature, and perfect certain materials, like the transmutation of \"base metals\" (e.g., lead) into \"noble metals\" (particularly gold).")]
    Alchemy = 1,
    [Description("Whole or partial loss of memory.")]
    Amnesia,
    [Description("Usually shaped like humans of extraordinary beauty, often identified with bird wings, halos, and divine light.")]
    Angels,
    [Description("Anthropomorphs: non-human creatures attributed with human traits and emotions.")]
    Anthropomorphic,
    [Description("Half-humans & half-animals.")]
    DemiHuman,
    [Description("Coercion using the threat of revealing compromising information about a person to the public.")]
    Blackmail,
    [Description("Cold and unforgiving.")]
    CruelWorld,
    [Description("Dystopian si-fi future that tends to focus on a combination of lowlife and high tech.")]
    Cyberpunk,
    [Description("Evil beings, minions of the devil, often humanoid, often depicted with horns, bat-like wings, and pointy spear-like tail.")]
    Demons,
    [Description("Large magical legendary creatures.")]
    Dragons,
    [Description("Not the smartest.")]
    DumbProtagonist,
    [Description("Monster filled caves/underground places.")]
    Dungeon,
    [Description("Distinctive sign of elves are their pointy ears. Commonly shown as creatures with great beauty.")]
    Elves,
    [Description("Political unit made up of several territories and peoples, usually created by conquest and controlled by the center, the metropole of the empire.")]
    Empires,
    [Description("Female main character.")]
    FemaleProtagonist,
    [Description("World in the far future.")]
    Future,
    [Description("Wagering of money with intent of winning more money, where instances of strategy are discounted.")]
    Gambling,
    [Description("Soul or spirit of a dead person or another creature that is able to appear to the living.")]
    Ghosts,
    [Description("All-mighty supernatural creature.")]
    Gods,
    [Description("Blood and violence.")]
    Gore,
    [Description("Japanese subculture, nonconformist or rebelling against Japanese social and aesthetic standards.")]
    Gyaru,
    [Description("Bunch of women constantly surrounding the protagonist.")]
    Harem,
    [Description("Total withdrawal from society and seeking extreme degrees of social isolation and confinement.")]
    Hikikomori,
    [Description("Honorable, noble warrior fully clad in plate armor. Usually armed with sword and shield.")]
    Knights,
    [Description("Stands for \"lesbian, gay, bisexual, transgender and queer\"")]
    LGBTQ,
    [Description("Italian criminal organization.")]
    Mafia,
    [Description("People with ability to use magic.")]
    Mages,
    [Description("Place where students learn, perfect, or extend their magical powers and knowledge.")]
    MagicAcademy,
    [Description("Female domestic worker. In manga depicted in style of Victorian era French maids.")]
    Maids,
    [Description("Male main character.")]
    MaleProtagonist,
    [Description("Stories in style of European mediæval period.")]
    Medieval,
    [Description("Life as a soldier.")]
    Military,
    [Description("Half-girl & half-monster.")]
    Monstergirls,
    [Description("Often about life in musical band.")]
    Music,
    [Description("Mythical creatures, monsters.")]
    Mythology,
    [Description("Japanese assassin.")]
    Ninja,
    [Description("Parody of common storytelling tropes.")]
    Parody,
    [Description("Sea bandits.")]
    Pirates,
    [Description("Power relations among individuals, such as the distribution of resources or status. Sometimes just depiction of political figures.")]
    Politics,
    [Description("Mind games, mental anguish, etc.")]
    Psychological,
    [Description("Journey toward a specific mission or a goal.")]
    Quests,
    [Description("Rebirth in another world after death.")]
    Reincarnation,
    [Description("Machine programmable by a computer—capable of carrying out a complex series of actions automatically.")]
    Robots,
    [Description("Military nobility, officer caste of medieval Japan, wearing traditional clothes and wielding katanas.")]
    Samurais,
    [Description("People being owned and treated like property.")]
    Slaves,
    [Description("Rare case.")]
    SmartProtagonist,
    [Description("Retrofuturistic aesthetics inspired by 19th-century industrial steam-powered machinery.")]
    Steampunk,
    [Description("Primarily taking place on Earth, supernatural stories incorporate elements or attributes that are unnatural and unexplainable by science.")]
    Supernatural,
    [Description("Living dead, like zombies or skeletons.")]
    Undead,
    [Description("Blood-suckers.")]
    Vampires,
    [Description("Story driven around protagonist's desire for retribution.")]
    Vengeance,
    [Description("Electronic games.")]
    Videogames,
    [Description("Reality but virtual.")]
    VirtualReality,
    [Description("Practitioner of witchcraft: magic used to inflict harm or misfortune on others.")]
    Witch,
    [Description("Japanese mafioso.")]
    Yakuza,
    [Description("Initially loving and caring until their romantic love, admiration and devotion becomes feisty and mentally destructive in nature through either overprotectiveness, violence, brutality or all three combined.")]
    Yandere,
    [Description("Green, undead brain-lover.")]
    Zombies
}
