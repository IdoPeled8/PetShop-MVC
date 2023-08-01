namespace PetShopDAL.Data;

public class PetShopContext : DbContext
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
            new Category { CategoryId = 5, Name = "Reptiles" },
            new Category { CategoryId = 6, Name = "Rodents" }
        );

        // Seed Animals
        modelBuilder.Entity<Animal>().HasData(
            new Animal { AnimalId = 1, Name = "Labrador Retriever", Age = 3, ImageName = "lavrador.jpeg", Description = "Friendly and outgoing. Labrador Retrievers are known for their friendly and outgoing personalities. They are great family pets and are often used as service dogs due to their intelligence and trainability.", CategoryId = 1 },
            new Animal { AnimalId = 2, Name = "Persian Cat", Age = 5, ImageName = "PersianCat.jpeg", Description = "Calm and gentle. Persian cats are known for their calm and gentle personalities. They have long, luxurious fur and are often considered one of the most beautiful cat breeds.", CategoryId = 2 },
            new Animal { AnimalId = 3, Name = "Parakeet", Age = 1, ImageName = "Paraket.jpeg", Description = "Colorful and social. Parakeets are small, colorful birds that are known for their social personalities. They enjoy being around other birds and humans and can even learn to mimic human speech.", CategoryId = 3 },
            new Animal { AnimalId = 4, Name = "Goldfish", Age = 2, ImageName = "Goldfish.jpeg", Description = "Easy to care for. Goldfish are a popular pet fish due to their bright colors and ease of care. They can live in a variety of environments and are a great choice for beginners.", CategoryId = 4 },
            new Animal { AnimalId = 5, Name = "Bearded Dragon", Age = 4, ImageName = "BeardedDragon.jpeg", Description = "Active and curious. Bearded dragons are a type of lizard that is known for their active and curious personalities. They enjoy exploring their surroundings and can even be trained to do simple tricks.", CategoryId = 5 },
            new Animal { AnimalId = 6, Name = "German Shepherd", Age = 2, ImageName = "GermanShepherd.jpeg", Description = "Intelligent and loyal. German Shepherds are a popular breed of dog known for their intelligence and loyalty. They make great working dogs and are often used in law enforcement and military roles.", CategoryId = 1 },
            new Animal { AnimalId = 7, Name = "Siamese Cat", Age = 3, ImageName = "SiameseCat.jpeg", Description = "Talkative and affectionate. Siamese cats are known for their talkative personalities and affectionate nature. They have striking blue eyes and a distinctive coat pattern.", CategoryId = 2 },
            new Animal { AnimalId = 8, Name = "Cockatiel", Age = 1, ImageName = "Cockatiel.jpeg", Description = "Playful and melodious. Cockatiels are small parrots that are known for their playful personalities and melodious songs. They enjoy interacting with humans and can even learn to mimic words and phrases.", CategoryId = 3 },
            new Animal { AnimalId = 9, Name = "Betta Fish", Age = 1, ImageName = "BettaFish.jpeg", Description = "Colorful and elegant. Betta fish are small freshwater fish that are known for their colorful fins and elegant movements. They can be kept in small aquariums and make great pets for those with limited space.", CategoryId = 4 },
            new Animal { AnimalId = 10, Name = "Leopard Gecko", Age = 2, ImageName = "LeopardGecko.jpeg", Description = "Nocturnal and low-maintenance. Leopard geckos are small lizards that are known for their nocturnal habits and low-maintenance care requirements. They have fascinating patterns on their skin and make great pets for reptile enthusiasts.", CategoryId = 5 },
            new Animal { AnimalId = 11, Name = "Trip", Age = 11, ImageName = "trip.jpg", Description = "I am Ido's dog. Trip is a friendly dog who loves to play fetch with his owner Ido. He is loyal and always happy to see his family.", CategoryId = 1 },
            new Animal { AnimalId = 12, Name = "Hamster", Age = 1, ImageName = "Hamster.jpeg", Description = "Small and active. Hamsters are small rodents that are known for their active personalities. They enjoy running on their exercise wheels and exploring their surroundings.", CategoryId = 6 },
            new Animal { AnimalId = 13, Name = "Poodle", Age = 4, ImageName = "Poodle.jpeg", Description = "Intelligent and elegant. Poodles are a popular breed of dog known for their intelligence and elegant appearance. They come in a variety of sizes and colors and are often used in dog shows.", CategoryId = 1 },
            new Animal { AnimalId = 14, Name = "Bengal Cat", Age = 3, ImageName = "BengalCat.jpeg", Description = "Active and playful. Bengal cats are a breed of cat known for their active and playful personalities. They have distinctive markings that resemble those of a wild cat and are highly intelligent.", CategoryId = 2 },
            new Animal { AnimalId = 15, Name = "Canary", Age = 2, ImageName = "Canary.jpeg", Description = "Melodious and cheerful. Canaries are small birds that are known for their melodious songs and cheerful personalities. They come in a variety of colors and make great pets for bird enthusiasts.", CategoryId = 3 },
            new Animal { AnimalId = 16, Name = "Guppy", Age = 1, ImageName = "Guppy.jpeg", Description = "Colorful and active. Guppies are small freshwater fish that are known for their colorful appearance and active personalities. They are easy to care for and make great pets for those new to fishkeeping.", CategoryId = 4 },
            new Animal { AnimalId = 17, Name = "Corn Snake", Age = 5, ImageName = "CornSnake.jpeg", Description = "Docile and easy to care for. Corn snakes are a type of snake that is known for their docile nature and ease of care. They come in a variety of colors and patterns and make great pets for reptile enthusiasts.", CategoryId = 5 },
            new Animal { AnimalId = 18, Name = "Guinea Pig", Age = 3, ImageName = "GuineaPig.jpeg", Description = "Social and vocal. Guinea pigs are small rodents that are known for their social personalities and vocal nature. They enjoy the company of other guinea pigs and humans and make great pets for families.", CategoryId = 6 }

        );
        // Seed Comments
        modelBuilder.Entity<Comment>().HasData(
            new Comment { CommentId = 1, AnimalId = 10, CommentText = "This Labrador is so adorable!" },
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
            new Comment { CommentId = 12, AnimalId = 10, CommentText = "Leopard Geckos have fascinating patterns on their skin." },
            new Comment { CommentId = 13, AnimalId = 12, CommentText = "Hamsters are so cute when they run on their exercise wheel." },
            new Comment { CommentId = 14, AnimalId = 12, CommentText = "I love watching my hamster stuff his cheeks with food." }
        );
    }

}
