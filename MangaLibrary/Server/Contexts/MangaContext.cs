using MangaLibrary.Shared.Enums;
using MangaLibrary.Shared.Models.Manga;
using Microsoft.EntityFrameworkCore;
using static MangaLibrary.Shared.Enums.Tags;
using static MangaLibrary.Shared.Enums.Genres;
using MangaLibrary.Shared.Models.Manga.JoinTables;

namespace MangaLibrary.Shared.Contexts;

public sealed class MangaContext : DbContext
{
    public DbSet<Manga> Mangas { get; set; } = null!;

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Publishing> Publishings { get; set; } = null!;

    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region AUTHOR
        modelBuilder.Entity<Author>().HasData(
            new Author("Kentaro Miura")
            {
                ID = 1,
                Description = "Was best known for his acclaimed dark fantasy series Berserk, which began serialization in 1989 and continued until his death in 2021.\n\nIn 2002, Miura received the Award for Excellence at the sixth Tezuka Osamu Cultural Prize."
            },
            new Author
            {
                ID = 2,
                Name = "SASAKURA Kou"
            },
            new Author("Tsugumi Ohba")
            {
                ID = 3,
                Description = "'Tsugumi Ohba' is the pen name of a Japanese manga writer, best known for authoring the Death Note manga series with illustrator Takeshi Obata. The duo's second series, Bakuman was also successful with 15 million in circulation."
            });
        #endregion

        #region ARTIST
        modelBuilder.Entity<Artist>().HasData(
            new Artist("Takeshi Obata")
            {
                ID = 1,
                Description = "Japanese manga artist that usually works as the illustrator in collaboration with a writer. First gained international attention for Hikaru no Go with Yumi Hotta, but is better known for Death Note and Bakuman with Tsugumi Ohba."
            });
        #endregion

        #region PUBLISHING
        modelBuilder.Entity<Publishing>().HasData(
            new Publishing("Hakusensha")
            {
                ID = 1,
                URL = "https://www.hakusensha.co.jp/",
                Description = "Mainly publishes manga magazines and is involved in series' productions in their games, original video animation, music, and their animated TV series.\n\nThe company is a wholly owned subsidiary of the Hitotsubashi Group."
            },
            new Publishing("Dark Horse Comics")
            {
                ID = 2,
                URL = "http://www.darkhorse.com/",
                Description = "Comic book, graphic novel, and manga publisher founded in Milwaukie, Oregon by Mike Richardson in 1986.\n\nThe company was created using funds earned from Richardson's chain of Portland, Oregon, comic book shops known as Pegasus Books and founded in 1980."
            },
            new Publishing("XL Media")
            {
                ID = 3,
                URL = "https://xlm.ru/",
                Description = "Independent publishing house from St. Petersburg. It started its activity in 2005, releasing licensed anime, and since 2010 it became one of the first publishers to form the official manga market in Russia."
            },
            new Publishing("Media Factory")
            {
                ID = 4,
                Description = "Media Factory, formerly known as 'Media Factory, Inc.', doing business as Media Factory, is a Japanese publisher and brand company of Kadokawa Future Publishing."
            },
            new Publishing("VIZ Media")
            {
                ID = 5,
                URL = "https://www.viz.com/",
                Description = "Headquartered in San Francisco, California, focused on publishing manga, and distribution and licensing Japanese anime, films, and television series.\n\nFounded in 1986 and merged to ShoPro Entertaiment in 2005. Owned by Shogakukan-Shueisha Productions."
            },
            new Publishing("Shueisha")
            {
                ID = 6,
                URL = "https://www.shueisha.co.jp/",
                Description = "Largest publishing company in Japan, headquartered in Chiyoda. It was established in 1925 as the entertainment-related publishing division of Japanese publisher Shogakukan. The following year, Shueisha became a separate, independent company."
            });
        #endregion

        #region TAGS
        modelBuilder.Entity<Tag>().HasData(
            new Tag(Alchemy),
            new Tag(Amnesia),
            new Tag(Angels),
            new Tag(Anthropomorphic),
            new Tag(DemiHuman),
            new Tag(Blackmail),
            new Tag(CruelWorld),
            new Tag(Cyberpunk),
            new Tag(Demons),
            new Tag(Dragons),
            new Tag(DumbProtagonist),
            new Tag(Dungeon),
            new Tag(Elves),
            new Tag(Empires),
            new Tag(FemaleProtagonist),
            new Tag(Future),
            new Tag(Gambling),
            new Tag(Ghosts),
            new Tag(Gods),
            new Tag(Gore),
            new Tag(Gyaru),
            new Tag(Harem),
            new Tag(Hikikomori),
            new Tag(Knights),
            new Tag(LGBTQ),
            new Tag(Mafia),
            new Tag(Mages),
            new Tag(MagicAcademy),
            new Tag(Maids),
            new Tag(MaleProtagonist),
            new Tag(Medieval),
            new Tag(Military),
            new Tag(Monstergirls),
            new Tag(Music),
            new Tag(Mythology),
            new Tag(Ninja),
            new Tag(Parody),
            new Tag(Pirates),
            new Tag(Politics),
            new Tag(Psychological),
            new Tag(Quests),
            new Tag(Reincarnation),
            new Tag(Robots),
            new Tag(Samurais),
            new Tag(Slaves),
            new Tag(SmartProtagonist),
            new Tag(Steampunk),
            new Tag(Supernatural),
            new Tag(Undead),
            new Tag(Vampires),
            new Tag(Vengeance),
            new Tag(Videogames),
            new Tag(VirtualReality),
            new Tag(Witch),
            new Tag(Yakuza),
            new Tag(Yandere),
            new Tag(Zombies));
        #endregion

        #region GENRES
        modelBuilder.Entity<Genre>().HasData(
            new Genre(Enums.Genres.Action),
            new Genre(Adventure),
            new Genre(Comedy),
            new Genre(Cooking),
            new Genre(Detective),
            new Genre(Drama),
            new Genre(Fantasy),
            new Genre(Horror),
            new Genre(Idols),
            new Genre(Isekai),
            new Genre(Mecha),
            new Genre(Mystery),
            new Genre(PostApocalypse),
            new Genre(Romance),
            new Genre(SiFi),
            new Genre(SliceOfLife),
            new Genre(Sports),
            new Genre(Survival),
            new Genre(SwordAndSorcery),
            new Genre(Thriller));
        #endregion

        #region MANGA
        modelBuilder.Entity<Manga>(x =>
        {
            #region AUTHORS-MANGAS
            x.HasMany(y => y.Authors)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaAuthor>(
                author => author
                    .HasOne(x => x.Author)
                    .WithMany(y => y.MangaAuthors)
                    .HasForeignKey(z => z.AuthorID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaAuthors)
                    .HasForeignKey(z => z.MangaID));
            #endregion

            #region ARTISTS-MANGAS
            x.HasMany(y => y.Artists)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaArtist>(
                artist => artist
                    .HasOne(x => x.Artist)
                    .WithMany(y => y.MangaArtists)
                    .HasForeignKey(z => z.ArtistID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaArtists)
                    .HasForeignKey(z => z.MangaID));
            #endregion

            #region TAG-MANGAS
            x.HasMany(y => y.Tags)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaTag>(
                tag => tag
                    .HasOne(x => x.Tag)
                    .WithMany(y => y.MangaTags)
                    .HasForeignKey(z => z.TagID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaTags)
                    .HasForeignKey(z => z.MangaID));
            #endregion

            #region GENRE-MANGAS
            x.HasMany(y => y.Genres)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaGenre>(
                genre => genre
                    .HasOne(x => x.Genre)
                    .WithMany(y => y.MangaGenres)
                    .HasForeignKey(z => z.GenreID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaGenres)
                    .HasForeignKey(z => z.MangaID));
            #endregion

            #region PUBLISHINGS-MANGAS
            x.HasMany(y => y.Publishings)
            .WithMany(z => z.Mangas)
            .UsingEntity<MangaPublishing>(
                publishing => publishing
                    .HasOne(x => x.Publishing)
                    .WithMany(y => y.MangaPublishings)
                    .HasForeignKey(z => z.PublishingID),

                manga => manga
                    .HasOne(x => x.Manga)
                    .WithMany(y => y.MangaPublishings)
                    .HasForeignKey(z => z.MangaID));
            #endregion

            #region DATA
            x.HasData(
                new Manga
                {
                    //Berserk
                    ID = 1,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/5971776-01.jpg",
                    Rating = 5f
                },
                new Manga
                {
                    //Castlevania
                    ID = 2,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/1843338-01.jpg",
                    Rating = 3.3f
                },
                new Manga
                {
                    //Death Note
                    ID = 3,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/13/136525/5233385-1.jpg",
                    Rating = 4.8f
                },
                new Manga
                {
                    ID = 4,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/4695905-01.jpg",
                    Rating = 4.9f
                },
                new Manga
                {
                    ID = 5,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/4454598-01.jpg",
                    Rating = 4.2f
                },
                new Manga
                {
                    ID = 6,
                    Poster = "https://comicvine.gamespot.com/a/uploads/scale_large/6/67663/6818656-01.jpg",
                    Rating = 4.7f
                });

            #region TITLES
            x.OwnsOne(y => y.Title).HasKey(z => z.MangaID);
            x.OwnsOne(y => y.Title).HasData(
                new Title
                {
                    MangaID = 1,
                    English = "Berserk",
                    Japanese = "ベルセルク",
                    Romaji = "Beruseruku"
                },
                new Title
                {
                    MangaID = 2,
                    English = "Castlevania: Curse of Darkness",
                    Japanese = "悪魔城ドラキュラ 闇の呪印",
                    Romaji = "Akumajō Dracula: Yami no Juin"
                },
                new Title
                {
                    MangaID = 3,
                    English = "Death Note",
                    Japanese = "デスノート",
                    Romaji = "Desu Nōto"
                },
                new Title
                {
                    MangaID = 4,
                    English = "Attack on Titan",
                    Japanese = "進撃の巨人",
                    Romaji = "Shingeki no Kyojin"
                },
                new Title
                {
                    MangaID = 5,
                    English = "Tokyo Ghoul",
                    Japanese = "Tōkyō Gūru",
                    Romaji = "Desu Nōto"
                },
                new Title
                {
                    MangaID = 6,
                    English = "Chainsaw man",
                    Japanese = "Chensōman",
                    Romaji = "Desu Nōto"
                });

            #region DETAILS

            x.OwnsOne(y => y.Details).HasKey(z => z.MangaID);
            x.OwnsOne(y => y.Details).HasData(
                new MangaDetails
                {
                    MangaID = 1,
                    Description = "Guts, a former mercenary now known as the \"Black Swordsman\", is out for revenge. After a tumultuous childhood, he finally finds someone he respects and believes he can trust, only to have everything fall apart when this person takes away everything important to Guts for the purpose of fulfilling his own desires. Now marked for death, Guts becomes condemned to a fate in which he is relentlessly pursued by demonic beings.\n\nSetting out on a dreadful quest riddled with misfortune, Guts, armed with a massive sword and monstrous strength, will let nothing stop him, not even death itself, until he is finally able to take the head of the one who stripped him—and his loved one—of their humanity.",
                    Volumes = 41,
                    Chapters = 376,
                    ReleaseYear = 1989,

                    PublishDate = DateTime.Now
                },
                new MangaDetails
                {
                    MangaID = 2,
                    Description = "\"Akumajō Dracula: Yami no Juin\" had in Japan its own comic series that lasted all of two volumes. The comic series of the same name was created in 2005 by company Mediafactory, and it follows events that overlap with bonus-material comic Prelude of Revenge, whose story was conceived by Ayami Kojima; the series is, according to her, a true extension of the of both Prelude and therein the game's actual story. Adding to its authenticity is the knowledge that Koji Igarashi completely supervised its creation.",
                    Volumes = 2,
                    Chapters = 4,
                    ReleaseYear = 2002,

                    PublishDate = DateTime.Now
                },
                new MangaDetails
                {
                    MangaID = 3,
                    Description = "Ryuk, a god of death, drops his Death Note into the human world for personal pleasure. In Japan, prodigious high school student Light Yagami stumbles upon it. Inside the notebook, he finds a chilling message: those whose names are written in it shall die. Its nonsensical nature amuses Light; but when he tests its power by writing the name of a criminal in it, they suddenly meet their demise.\n\nRealizing the Death Note's vast potential, Light commences a series of nefarious murders under the pseudonym \"Kira\", vowing to cleanse the world of corrupt individuals and create a perfect society where crime ceases to exist. However, the police quickly catch on, and they enlist the help of L—a mastermind detective—to uncover the culprit.\n\nDeath Note tells the thrilling tale of Light and L as they clash in a great battle-of-minds, one that will determine the future of the world.",
                    Volumes = 12,
                    Chapters = 117,
                    ReleaseYear = 2003,

                    PublishDate = DateTime.Now
                },
                new MangaDetails
                {
                    MangaID = 4,
                    Description = "Set in a fantasy world where humanity lives within territories surrounded by three enormous walls that protect them from gigantic man-eating humanoids referred to as Titans The anime follows a group of teenagers living inside cities surrounded by three enormous walls that protect the last vestiges of humanity from gigantic humanoid “Titans” that devour people seemingly for no reason.",
                    Volumes = 34,
                    Chapters = 139,
                    ReleaseYear = 2009,

                    PublishDate = DateTime.Now
                },
                new MangaDetails
                {
                    MangaID = 5,
                    Description = "Shy Ken Kaneki is thrilled to go on a date with the beautiful Rize. But it turns out that she’s only interested in his body—eating it, that is. When a morally questionable rescue transforms him into the first half-human half-Ghoul hybrid, Ken is drawn into the dark and violent world of Ghouls, which exists alongside our own.",
                    Volumes = 14,
                    Chapters = 143,
                    ReleaseYear = 2011,

                    PublishDate = DateTime.Now
                },
                new MangaDetails
                {
                    MangaID = 6,
                    Description = "Denji is desperate to tell the world that he’s Chainsaw Man, but is he competent enough to pull off a proper reveal? Meanwhile, Asa has made a friend! But this new friendship may be hiding a dark secret.",
                    Volumes = 11,
                    Chapters = 97,
                    ReleaseYear = 2018,

                    PublishDate = DateTime.Now
                });
            #endregion
        });
        #endregion
        #endregion
        #endregion

        #region MANGA-AUTHOR
        modelBuilder.Entity<MangaAuthor>().HasData(
                //Berserk
                new MangaAuthor { MangaID = 1, AuthorID = 1 },

                //Castlevania
                new MangaAuthor { MangaID = 2, AuthorID = 2 },

                //Death Note
                new MangaAuthor { MangaID = 3, AuthorID = 3 }
                );
        #endregion

        #region MANGA-ARTIST
        modelBuilder.Entity<MangaArtist>().HasData(
                //Death Note
                new MangaArtist { MangaID = 3, ArtistID = 1 }
                );
        #endregion

        #region MANGA-PUBLISHING
        modelBuilder.Entity<MangaPublishing>().HasData(
                //Berserk
                new MangaPublishing { MangaID = 1, PublishingID = 1 },
                new MangaPublishing { MangaID = 1, PublishingID = 2 },
                new MangaPublishing { MangaID = 1, PublishingID = 3 },

                //Castlevania
                new MangaPublishing { MangaID = 2, PublishingID = 4 },

                //Death Note
                new MangaPublishing { MangaID = 3, PublishingID = 5 },
                new MangaPublishing { MangaID = 3, PublishingID = 6 }
                );
        #endregion

        #region MANGA-TAG
        modelBuilder.Entity<MangaTag>().HasData(
                //Berserk
                new { MangaID = 1, TagID = (int)Demons },
                new { MangaID = 1, TagID = (int)Gore },
                new { MangaID = 1, TagID = (int)CruelWorld },
                new { MangaID = 1, TagID = (int)Vengeance },
                new { MangaID = 1, TagID = (int)Medieval },
                new { MangaID = 1, TagID = (int)Psychological },
                new { MangaID = 1, TagID = (int)MaleProtagonist },
                new { MangaID = 1, TagID = (int)Supernatural },

                //Castlevania
                new { MangaID = 2, TagID = (int)Mythology },
                new { MangaID = 2, TagID = (int)Vampires },

                //Death Note
                new { MangaID = 3, TagID = (int)Psychological },
                new { MangaID = 3, TagID = (int)Mythology },
                new { MangaID = 3, TagID = (int)Supernatural },
                new { MangaID = 3, TagID = (int)Gods },
                new { MangaID = 3, TagID = (int)CruelWorld },
                new { MangaID = 3, TagID = (int)MaleProtagonist },
                new { MangaID = 3, TagID = (int)Blackmail },

                new { MangaID = 4, TagID = (int)Psychological },
                new { MangaID = 4, TagID = (int)Politics },
                new { MangaID = 4, TagID = (int)CruelWorld },
                new { MangaID = 4, TagID = (int)Steampunk },
                new { MangaID = 4, TagID = (int)Vengeance },
                new { MangaID = 4, TagID = (int)MaleProtagonist },
                new { MangaID = 4, TagID = (int)Gore },

                new { MangaID = 5, TagID = (int)Psychological },
                new { MangaID = 5, TagID = (int)CruelWorld },
                new { MangaID = 5, TagID = (int)MaleProtagonist },
                new { MangaID = 5, TagID = (int)Gore },

                new { MangaID = 6, TagID = (int)Supernatural },
                new { MangaID = 6, TagID = (int)CruelWorld },
                new { MangaID = 6, TagID = (int)MaleProtagonist },
                new { MangaID = 6, TagID = (int)Gore },
                new { MangaID = 6, TagID = (int)Zombies }
                );
        #endregion

        #region MANGA-GENRE
        modelBuilder.Entity<MangaGenre>().HasData(
                new() { MangaID = 1, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 1, GenreID = (int)Horror },
                new() { MangaID = 1, GenreID = (int)Adventure },
                new() { MangaID = 1, GenreID = (int)Fantasy },
                new() { MangaID = 1, GenreID = (int)SwordAndSorcery },

                //Castlevania
                new() { MangaID = 2, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 2, GenreID = (int)Drama },
                new() { MangaID = 2, GenreID = (int)Fantasy },

                //Death Note
                new() { MangaID = 3, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 3, GenreID = (int)Drama },
                new() { MangaID = 3, GenreID = (int)Detective },
                new() { MangaID = 3, GenreID = (int)Thriller },

                new() { MangaID = 4, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 4, GenreID = (int)Drama },
                new() { MangaID = 4, GenreID = (int)PostApocalypse },
                new() { MangaID = 4, GenreID = (int)Horror },

                new() { MangaID = 5, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 5, GenreID = (int)Drama },
                new() { MangaID = 5, GenreID = (int)Romance },
                new() { MangaID = 5, GenreID = (int)Horror },
                new() { MangaID = 5, GenreID = (int)Fantasy },

                new() { MangaID = 6, GenreID = (int)Enums.Genres.Action },
                new() { MangaID = 6, GenreID = (int)Comedy },
                new() { MangaID = 6, GenreID = (int)Romance },
                new() { MangaID = 6, GenreID = (int)Fantasy }
                );
        #endregion

        base.OnModelCreating(modelBuilder);
    }

    public MangaContext(DbContextOptions options) : base(options) { }
}

//x.OwnsMany(y => y.Authors, z =>
//{
//    z.WithOwner().HasForeignKey("OwnerID");

//    z.Property<int>("ID");
//    z.HasKey("ID");

//    z.HasData(
//        new
//        {
//            OwnerID = 1,
//            ID = 1,
//            Name = "Kentaro Miura",
//            Description = "Was best known for his acclaimed dark fantasy series Berserk, which began serialization in 1989 and continued until his death in 2021.\n\nIn 2002, Miura received the Award for Excellence at the sixth Tezuka Osamu Cultural Prize."
//        });
//});
