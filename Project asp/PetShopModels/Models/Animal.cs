
namespace PetShopModels;

public class Animal
{
    [Key]
    public int AnimalId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Age is required.")]
    [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Image File is required.")]
    public string? ImageName { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 letters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Please Choose one of the categories below.")]
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }

    [Required(ErrorMessage = "Comment cant be Empty.")]
    public virtual ICollection<Comment>? Comments { get; set; }

}


