
namespace PetShopModels
{
    public class LoginUserModel
    {
        [Key]
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }



    }
    
}
