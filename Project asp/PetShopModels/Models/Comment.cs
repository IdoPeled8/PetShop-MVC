
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopModels
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        public string? CommentText { get; set; }
    }
}