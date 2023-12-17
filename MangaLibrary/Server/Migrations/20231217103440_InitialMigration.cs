using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaLibrary.Server.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_English = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Title_Japanese = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Title_Romaji = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Details_UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details_Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Details_ReleaseYear = table.Column<short>(type: "smallint", nullable: false),
                    Details_Volumes = table.Column<short>(type: "smallint", nullable: false),
                    Details_Chapters = table.Column<short>(type: "smallint", nullable: false),
                    Details_Bookmarks = table.Column<int>(type: "int", nullable: false),
                    Details_Favorites = table.Column<int>(type: "int", nullable: false),
                    Details_PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MangaArtist",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaArtist", x => new { x.ArtistID, x.MangaID });
                    table.ForeignKey(
                        name: "FK_MangaArtist_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaArtist_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthor",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthor", x => new { x.AuthorID, x.MangaID });
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaAuthor_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaGenre",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaGenre", x => new { x.GenreID, x.MangaID });
                    table.ForeignKey(
                        name: "FK_MangaGenre_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaGenre_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaPublishing",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    PublishingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaPublishing", x => new { x.MangaID, x.PublishingID });
                    table.ForeignKey(
                        name: "FK_MangaPublishing_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaPublishing_Publishings_PublishingID",
                        column: x => x.PublishingID,
                        principalTable: "Publishings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MangaTag",
                columns: table => new
                {
                    MangaID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTag", x => new { x.MangaID, x.TagID });
                    table.ForeignKey(
                        name: "FK_MangaTag_Mangas_MangaID",
                        column: x => x.MangaID,
                        principalTable: "Mangas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MangaTag_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[] { 1, "Japanese manga artist that usually works as the illustrator in collaboration with a writer. First gained international attention for Hikaru no Go with Yumi Hotta, but is better known for Death Note and Bakuman with Tsugumi Ohba.", "Takeshi Obata" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Was best known for his acclaimed dark fantasy series Berserk, which began serialization in 1989 and continued until his death in 2021.\n\nIn 2002, Miura received the Award for Excellence at the sixth Tezuka Osamu Cultural Prize.", "Kentaro Miura" },
                    { 2, null, "SASAKURA Kou" },
                    { 3, "'Tsugumi Ohba' is the pen name of a Japanese manga writer, best known for authoring the Death Note manga series with illustrator Takeshi Obata. The duo's second series, Bakuman was also successful with 15 million in circulation.", "Tsugumi Ohba" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Exciting action sequences take priority and significant conflicts between characters are usually resolved with one's physical power.", "Action" },
                    { 2, "Whether aiming for a specific goal or just struggling to survive, the main character is thrust into unfamiliar situations or lands and continuously faces unexpected dangers.", "Adventure" },
                    { 3, "Uplifting the audience with positive emotion takes priority, eliciting laughter, amusement, or general entertainment.", "Comedy" },
                    { 4, "Self-explanatory name, stories of this genre can be more relaxing and about trying rich and tasty food or be about dynamic, stressful work in the kitchen.", "Cooking" },
                    { 5, "A theme within the Mystery genre, these stories feature either a detective or amateur investigator working to solve a crime or puzzling event.", "Detective" },
                    { 6, "Plot-driven stories focused on realistic characters experiencing human struggle.", "Drama" },
                    { 7, "Magical powers, unnatural creatures, or other unreal elements which cannot be explained by science are prevalent and normal to the setting they exist in.", "Fantasy" },
                    { 8, "Creating—and maintaining—a sense of dread in the audience takes priority, eliciting shock, fear, or disgust through atmosphere and frightening scenarios.", "Horror" },
                    { 9, "Stories about life of Japanese idols.", "Idols" },
                    { 10, "Protagonist getting transferred into another, unknown world.", "Isekai" },
                    { 11, "Piloting giant humanoid robots.", "Mecha" },
                    { 12, "Whether its solving a crime or finding an explanation for a puzzling circumstance, the main cast willingly or reluctantly become investigators who must work to answer the who, what, why, and/or how of the current dilemma.", "Mystery" },
                    { 13, "Survival after end of the world.", "Post-apocalypse" },
                    { 14, "Falling in love and struggling to progress towards—or maintain—a romantic relationship take priority, while other subplots either take backseat or are designed to develop the main love story.", "Romance" },
                    { 15, "Imagined technological advancements or natural settings which are currently unreal in the present day but could be invented, caused, or explained by science in the future.", "Si-Fi" },
                    { 16, "Slice of Life stories are focused on a seemingly random and mundane period of the main characters' lives.", "Slice of Life" },
                    { 17, "Training for and participating in a sport take priority, with the goal of furthering one's athletic abilities—either to win a competition or achieve some social standing.", "Sports" },
                    { 18, "Tough life under constant threat of death.", "Survival" },
                    { 19, "Heroic fantasy. Subgenre of fantasy characterized by sword-wielding heroes engaged in exciting and violent adventures.", "Sword and Sorcery" },
                    { 20, "Characterized and defined by the elicit moods, giving their audiences heightened feelings of suspense, excitement, surprise, anticipation and anxiety.", "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Mangas",
                columns: new[] { "ID", "Poster", "Rating", "Details_Bookmarks", "Details_Chapters", "Details_Description", "Details_Favorites", "Details_PublishDate", "Details_ReleaseYear", "Details_UpdateDate", "Details_Volumes", "Title_English", "Title_Japanese", "Title_Romaji" },
                values: new object[,]
                {
                    { 1, "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/5971776-01.jpg", 5f, 0, (short)376, "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything important to Guts for the purpose of fulfilling his own desires. Now marked for death, Guts becomes condemned to a fate in which he is relentlessly pursued by demonic beings.\n\nSetting out on a dreadful quest riddled with misfortune, Guts, armed with a massive sword and monstrous strength, will let nothing stop him, not even death itself, until he is finally able to take the head of the one who stripped him—and his loved one—of their humanity.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3348), (short)1989, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3321), (short)41, "Berserk", "ベルセルク", "Beruseruku" },
                    { 2, "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/1843338-01.jpg", 3.3f, 0, (short)4, "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic Prelude of Revenge, whose story was conceived by Ayami Kojima; the series is, according to her, a true extension of the of both Prelude and therein the game's actual story. Adding to its authenticity is the knowledge that Koji Igarashi completely supervised its creation.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3365), (short)2002, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3357), (short)2, "Castlevania: Curse of Darkness", "悪魔城ドラキュラ 闇の呪印", "Akumajō Dracula: Yami no Juin" },
                    { 3, "https://comicvine.gamespot.com/a/uploads/scale_large/13/136525/5233385-1.jpg", 4.8f, 0, (short)117, "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die. Its nonsensical nature amuses Light; but when he tests its power by writing the name of a criminal in it, they suddenly meet their demise.\n\nRealizing the Death Note's vast potential, Light commences a series of nefarious murders under the pseudonym \"Kira\", vowing to cleanse the world of corrupt individuals and create a perfect society where crime ceases to exist. However, the police quickly catch on, and they enlist the help of L—a mastermind detective—to uncover the culprit.\n\nDeath Note tells the thrilling tale of Light and L as they clash in a great battle-of-minds, one that will determine the future of the world.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3383), (short)2003, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3374), (short)12, "Death Note", "デスノート", "Desu Nōto" },
                    { 4, "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/4695905-01.jpg", 4.9f, 0, (short)139, "Set in a fantasy world where humanity lives within territories surrounded by three enormous walls that protect them from gigantic man-eating humanoids referred to as Titans The anime follows a group of teenagers living inside cities surrounded by three enormous walls that protect the last vestiges of humanity from gigantic humanoid “Titans” that devour people seemingly for no reason.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3396), (short)2009, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3387), (short)34, "Attack on Titan", "進撃の巨人", "Shingeki no Kyojin" },
                    { 5, "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/4454598-01.jpg", 4.2f, 0, (short)143, "Shy Ken Kaneki is thrilled to go on a date with the beautiful Rize. But it turns out that she’s only interested in his body—eating it, that is. When a morally questionable rescue transforms him into the first half-human half-Ghoul hybrid, Ken is drawn into the dark and violent world of Ghouls, which exists alongside our own.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3409), (short)2011, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3405), (short)14, "Tokyo Ghoul", "Tōkyō Gūru", "Desu Nōto" },
                    { 6, "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/6818656-01.jpg", 4.7f, 0, (short)97, "Denji is desperate to tell the world that he’s Chainsaw Man, but is he competent enough to pull off a proper reveal? Meanwhile, Asa has made a friend! But this new friendship may be hiding a dark secret.", 0, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3427), (short)2018, new DateTime(2023, 12, 17, 14, 34, 39, 692, DateTimeKind.Local).AddTicks(3418), (short)11, "Chainsaw man", "Chensōman", "Desu Nōto" }
                });

            migrationBuilder.InsertData(
                table: "Publishings",
                columns: new[] { "ID", "Description", "Name", "URL" },
                values: new object[,]
                {
                    { 1, "Mainly publishes manga magazines and is involved in series' productions in their games, original video animation, music, and their animated TV series.\n\nThe company is a wholly owned subsidiary of the Hitotsubashi Group.", "Hakusensha", "https://www.hakusensha.co.jp/" },
                    { 2, "Comic book, graphic novel, and manga publisher founded in Milwaukie, Oregon by Mike Richardson in 1986.\n\nThe company was created using funds earned from Richardson's chain of Portland, Oregon, comic book shops known as Pegasus Books and founded in 1980.", "Dark Horse Comics", "http://www.darkhorse.com/" },
                    { 3, "Independent publishing house from St. Petersburg. It started its activity in 2005, releasing licensed anime, and since 2010 it became one of the first publishers to form the official manga market in Russia.", "XL Media", "https://xlm.ru/" },
                    { 4, "Media Factory, formerly known as 'Media Factory, Inc.', doing business as Media Factory, is a Japanese publisher and brand company of Kadokawa Future Publishing.", "Media Factory", null },
                    { 5, "Headquartered in San Francisco, California, focused on publishing manga, and distribution and licensing Japanese anime, films, and television series.\n\nFounded in 1986 and merged to ShoPro Entertaiment in 2005. Owned by Shogakukan-Shueisha Productions.", "VIZ Media", "https://www.viz.com/" },
                    { 6, "Largest publishing company in Japan, headquartered in Chiyoda. It was established in 1925 as the entertainment-related publishing division of Japanese publisher Shogakukan. The following year, Shueisha became a separate, independent company.", "Shueisha", "https://www.shueisha.co.jp/" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Attempt to purify, mature, and perfect certain materials, like the transmutation of \"base metals\" (e.g., lead) into \"noble metals\" (particularly gold).", "Alchemy" },
                    { 2, "Whole or partial loss of memory.", "Amnesia" },
                    { 3, "Usually shaped like humans of extraordinary beauty, often identified with bird wings, halos, and divine light.", "Angels" },
                    { 4, "Anthropomorphs: non-human creatures attributed with human traits and emotions.", "Anthropomorphic" },
                    { 5, "Half-humans & half-animals.", "Demi Human" },
                    { 6, "Coercion using the threat of revealing compromising information about a person to the public.", "Blackmail" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 7, "Cold and unforgiving.", "Cruel World" },
                    { 8, "Dystopian si-fi future that tends to focus on a combination of lowlife and high tech.", "Cyberpunk" },
                    { 9, "Evil beings, minions of the devil, often humanoid, often depicted with horns, bat-like wings, and pointy spear-like tail.", "Demons" },
                    { 10, "Large magical legendary creatures.", "Dragons" },
                    { 11, "Not the smartest.", "Dumb Protagonist" },
                    { 12, "Monster filled caves/underground places.", "Dungeon" },
                    { 13, "Distinctive sign of elves are their pointy ears. Commonly shown as creatures with great beauty.", "Elves" },
                    { 14, "Political unit made up of several territories and peoples, usually created by conquest and controlled by the center, the metropole of the empire.", "Empires" },
                    { 15, "Female main character.", "Female Protagonist" },
                    { 16, "World in the far future.", "Future" },
                    { 17, "Wagering of money with intent of winning more money, where instances of strategy are discounted.", "Gambling" },
                    { 18, "Soul or spirit of a dead person or another creature that is able to appear to the living.", "Ghosts" },
                    { 19, "All-mighty supernatural creature.", "Gods" },
                    { 20, "Blood and violence.", "Gore" },
                    { 21, "Japanese subculture, nonconformist or rebelling against Japanese social and aesthetic standards.", "Gyaru" },
                    { 22, "Bunch of women constantly surrounding the protagonist.", "Harem" },
                    { 23, "Total withdrawal from society and seeking extreme degrees of social isolation and confinement.", "Hikikomori" },
                    { 24, "Honorable, noble warrior fully clad in plate armor. Usually armed with sword and shield.", "Knights" },
                    { 25, "Stands for \"lesbian, gay, bisexual, transgender and queer\"", "LGBTQ" },
                    { 26, "Italian criminal organization.", "Mafia" },
                    { 27, "People with ability to use magic.", "Mages" },
                    { 28, "Place where students learn, perfect, or extend their magical powers and knowledge.", "Magic Academy" },
                    { 29, "Female domestic worker. In manga depicted in style of Victorian era French maids.", "Maids" },
                    { 30, "Male main character.", "Male Protagonist" },
                    { 31, "Stories in style of European mediæval period.", "Medieval" },
                    { 32, "Life as a soldier.", "Military" },
                    { 33, "Half-girl & half-monster.", "Monstergirls" },
                    { 34, "Often about life in musical band.", "Music" },
                    { 35, "Mythical creatures, monsters.", "Mythology" },
                    { 36, "Japanese assassin.", "Ninja" },
                    { 37, "Parody of common storytelling tropes.", "Parody" },
                    { 38, "Sea bandits.", "Pirates" },
                    { 39, "Power relations among individuals, such as the distribution of resources or status. Sometimes just depiction of political figures.", "Politics" },
                    { 40, "Mind games, mental anguish, etc.", "Psychological" },
                    { 41, "Journey toward a specific mission or a goal.", "Quests" },
                    { 42, "Rebirth in another world after death.", "Reincarnation" },
                    { 43, "Machine programmable by a computer—capable of carrying out a complex series of actions automatically.", "Robots" },
                    { 44, "Military nobility, officer caste of medieval Japan, wearing traditional clothes and wielding katanas.", "Samurais" },
                    { 45, "People being owned and treated like property.", "Slaves" },
                    { 46, "Rare case.", "Smart Protagonist" },
                    { 47, "Retrofuturistic aesthetics inspired by 19th-century industrial steam-powered machinery.", "Steampunk" },
                    { 48, "Primarily taking place on Earth, supernatural stories incorporate elements or attributes that are unnatural and unexplainable by science.", "Supernatural" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 49, "Living dead, like zombies or skeletons.", "Undead" },
                    { 50, "Blood-suckers.", "Vampires" },
                    { 51, "Story driven around protagonist's desire for retribution.", "Vengeance" },
                    { 52, "Electronic games.", "Videogames" },
                    { 53, "Reality but virtual.", "Virtual Reality" },
                    { 54, "Practitioner of witchcraft: magic used to inflict harm or misfortune on others.", "Witch" },
                    { 55, "Japanese mafioso.", "Yakuza" },
                    { 56, "Initially loving and caring until their romantic love, admiration and devotion becomes feisty and mentally destructive in nature through either overprotectiveness, violence, brutality or all three combined.", "Yandere" },
                    { 57, "Green, undead brain-lover.", "Zombies" }
                });

            migrationBuilder.InsertData(
                table: "MangaArtist",
                columns: new[] { "ArtistID", "MangaID" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "MangaAuthor",
                columns: new[] { "AuthorID", "MangaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MangaGenre",
                columns: new[] { "GenreID", "MangaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 1 },
                    { 3, 6 },
                    { 5, 3 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 5 },
                    { 7, 6 },
                    { 8, 1 },
                    { 8, 4 },
                    { 8, 5 },
                    { 13, 4 },
                    { 14, 5 },
                    { 14, 6 },
                    { 19, 1 },
                    { 20, 3 }
                });

            migrationBuilder.InsertData(
                table: "MangaPublishing",
                columns: new[] { "MangaID", "PublishingID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "MangaTag",
                columns: new[] { "MangaID", "TagID" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 1, 9 },
                    { 1, 20 },
                    { 1, 30 },
                    { 1, 31 },
                    { 1, 40 },
                    { 1, 48 }
                });

            migrationBuilder.InsertData(
                table: "MangaTag",
                columns: new[] { "MangaID", "TagID" },
                values: new object[,]
                {
                    { 1, 51 },
                    { 2, 35 },
                    { 2, 50 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 19 },
                    { 3, 30 },
                    { 3, 35 },
                    { 3, 40 },
                    { 3, 48 },
                    { 4, 7 },
                    { 4, 20 },
                    { 4, 30 },
                    { 4, 39 },
                    { 4, 40 },
                    { 4, 47 },
                    { 4, 51 },
                    { 5, 7 },
                    { 5, 20 },
                    { 5, 30 },
                    { 5, 40 },
                    { 6, 7 },
                    { 6, 20 },
                    { 6, 30 },
                    { 6, 48 },
                    { 6, 57 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MangaArtist_MangaID",
                table: "MangaArtist",
                column: "MangaID");

            migrationBuilder.CreateIndex(
                name: "IX_MangaAuthor_MangaID",
                table: "MangaAuthor",
                column: "MangaID");

            migrationBuilder.CreateIndex(
                name: "IX_MangaGenre_MangaID",
                table: "MangaGenre",
                column: "MangaID");

            migrationBuilder.CreateIndex(
                name: "IX_MangaPublishing_PublishingID",
                table: "MangaPublishing",
                column: "PublishingID");

            migrationBuilder.CreateIndex(
                name: "IX_MangaTag_TagID",
                table: "MangaTag",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaArtist");

            migrationBuilder.DropTable(
                name: "MangaAuthor");

            migrationBuilder.DropTable(
                name: "MangaGenre");

            migrationBuilder.DropTable(
                name: "MangaPublishing");

            migrationBuilder.DropTable(
                name: "MangaTag");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishings");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
