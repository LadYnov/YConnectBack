using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.IRepository;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database.SqlRepository
{
    public class SqlPostRepository : IPostRepository
    {
        private readonly YConnectContextDB _contextDb;

        public SqlPostRepository(YConnectContextDB contextDb)
        {
            this._contextDb = contextDb;
        }
        
        public async Task<Post> GetById(int iPostId)
        {
            return await this._contextDb.Post.FindAsync(iPostId);
        }

        public async Task AddPost(Post iPost)
        {
            await this._contextDb.Post.AddAsync(iPost);
            await this._contextDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetComments(int iPostId)
        {
            return await this._contextDb.Comments.Where(x => x.PostId == iPostId).ToListAsync();
        }

        public Task<IEnumerable<ReactionsPost>> GetReactionsPosts()
        {
            throw new System.NotImplementedException();
        }

        public async Task DeletePost(int iPostId)
        {
            Post aPost = await this._contextDb.Post.FindAsync(iPostId);
        }

        public Task UpdatePost(Post iPost)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<IEnumerable<Post>> GetPosts()
        {
            throw new System.NotImplementedException();
        }
    }
}
