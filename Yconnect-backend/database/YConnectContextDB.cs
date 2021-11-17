using Microsoft.EntityFrameworkCore;
using Yconnect_backend.database.models;

namespace Yconnect_backend.database
{
    public class YConnectContextDB : DbContext
    {
        public YConnectContextDB() : base()
        {

        }

        public DbSet<Campus> Campus { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FriendsList> FriendsLists { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Icon> Icon { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Reactions> Reactions { get; set; }
        public DbSet<ReactionsComment> ReactionsComments { get; set; }
        public DbSet<ReactionsMessage> ReactionsMessages { get; set; }
        public DbSet<ReactionsPost> ReactionsPost { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
