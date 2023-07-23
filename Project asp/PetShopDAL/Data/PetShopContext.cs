namespace PetShopDAL.Data;

public class PetShopContext: DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Animal>? Animals { get; set; }
    public DbSet<Comment>? Comments { get; set; }

    public PetShopContext(DbContextOptions<PetShopContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Dogs" },
            new Category { CategoryId = 2, Name = "Cats" },
            new Category { CategoryId = 3, Name = "Birds" },
            new Category { CategoryId = 4, Name = "Fish" },
            new Category { CategoryId = 5, Name = "Reptiles" }
        );

        // Seed Animals
        modelBuilder.Entity<Animal>().HasData(
            new Animal { AnimalId = 1, Name = "Labrador Retriever", Age = 3, ImageName = "lavrador.jpeg", Description = "Friendly and outgoing", CategoryId = 1 },
            new Animal { AnimalId = 2, Name = "Persian Cat", Age = 5, ImageName = "PersianCat.jpeg", Description = "Calm and gentle", CategoryId = 2 },
            new Animal { AnimalId = 3, Name = "Parakeet", Age = 1, ImageName = "Paraket.jpeg", Description = "Colorful and social", CategoryId = 3 },
            new Animal { AnimalId = 4, Name = "Goldfish", Age = 2, ImageName = "Goldfish.jpeg", Description = "Easy to care for", CategoryId = 4 },
            new Animal { AnimalId = 5, Name = "Bearded Dragon", Age = 4, ImageName = "BeardedDragon.jpeg", Description = "Active and curious", CategoryId = 5 },
            new Animal { AnimalId = 6, Name = "German Shepherd", Age = 2, ImageName = "GermanShepherd.jpeg", Description = "Intelligent and loyal", CategoryId = 1 },
            new Animal { AnimalId = 7, Name = "Siamese Cat", Age = 3, ImageName = "SiameseCat.jpeg", Description = "Talkative and affectionate", CategoryId = 2 },
            new Animal { AnimalId = 8, Name = "Cockatiel", Age = 1, ImageName = "Cockatiel.jpeg", Description = "Playful and melodious", CategoryId = 3 },
            new Animal { AnimalId = 9, Name = "Betta Fish", Age = 1, ImageName = "BettaFish.jpeg", Description = "Colorful and elegant", CategoryId = 4 },
            new Animal { AnimalId = 10, Name = "Leopard Gecko", Age = 2, ImageName = "LeopardGecko.jpeg", Description = "Nocturnal and low-maintenance", CategoryId = 5 },
            new Animal { AnimalId = 11, Name = "Trip", Age = 11, ImageName = "trip.jpeg", Description = "i am ido Dog", CategoryId = 1 }
        );

        // Seed Comments
        modelBuilder.Entity<Comment>().HasData(
            new Comment { CommentId = 1, AnimalId = 10, CommentText = "This Labrador is so adorable!"},
            new Comment { CommentId = 2, AnimalId = 10, CommentText = "I love playing fetch with this dog." },
            new Comment { CommentId = 3, AnimalId = 2, CommentText = "The Persian cat is so fluffy!" },
            new Comment { CommentId = 4, AnimalId = 2, CommentText = "This cat loves to be petted." },
            new Comment { CommentId = 5, AnimalId = 3, CommentText = "The parakeet's colors are amazing!" },
            new Comment { CommentId = 6, AnimalId = 3, CommentText = "This bird can mimic human speech." },
            new Comment { CommentId = 7, AnimalId = 4, CommentText = "The goldfish is beautiful and relaxing to watch." },
            new Comment { CommentId = 8, AnimalId = 5, CommentText = "I enjoy observing the bearded dragon's behavior." },
            new Comment { CommentId = 9, AnimalId = 6, CommentText = "German Shepherds are great companions for outdoor activities." },
            new Comment { CommentId = 10, AnimalId = 7, CommentText = "The Siamese cat has striking blue eyes." },
            new Comment { CommentId = 11, AnimalId = 8, CommentText = "Cockatiels are known for their whistling abilities." },
            new Comment { CommentId = 12, AnimalId = 10, CommentText = "Leopard Geckos have fascinating patterns on their skin." }
        );
    }

}
