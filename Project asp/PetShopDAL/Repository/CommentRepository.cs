
namespace PetShopDAL.Repository
{

    public class CommentRepository : ICommentRepository

    {
        PetShopContext _petShopContext;

        public CommentRepository(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }

    
        public async Task DeleteAsync(int id)
        {
            var comment = await _petShopContext.Comments!.FirstOrDefaultAsync(c => c.CommentId == id)!;
            if (comment != null)
            {
                _petShopContext.Comments!.Remove(comment);
                await _petShopContext.SaveChangesAsync();
            }
        }
    }
}
