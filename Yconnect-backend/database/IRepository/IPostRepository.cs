using System.Collections.Generic;
using System.Threading.Tasks;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.IRepository
{
    public interface IPostRepository
    {
        public Task<IEnumerable<Post>> GetPosts();
        public Task<Post> GetById(int iPostId);
        public Task AddPost(Post iPost);
        public Task<IEnumerable<Comment>> GetComments(int iPostId);
        public Task<IEnumerable<ReactionsPost>> GetReactionsPosts();
        public Task DeletePost(int iPostId);
        public Task UpdatePost(Post iPost);

    }
}
