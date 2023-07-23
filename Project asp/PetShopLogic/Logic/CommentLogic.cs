

namespace PetShopLogic
{
    public class CommentLogic
    {
        private readonly ICommentRepository _commentRepository;

        public CommentLogic(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task DeleteCommentAsync(int id) => await _commentRepository.DeleteAsync(id);

    }
}