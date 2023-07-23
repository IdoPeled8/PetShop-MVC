
namespace PetShopModels;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Animal>? Animals { get; set; }
}