using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-04FKJQB\\SQLEXPRESS;Database=CoreBlogDb;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasOne(x=>x.HomeTeam).WithMany(y=>y.HomeMatches).HasForeignKey(z=>z.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Match>().HasOne(x=>x.GuestTeam).WithMany(y=>y.AwayMatches).HasForeignKey(z=>z.GuestTeamId).OnDelete(DeleteBehavior.Restrict);
            //HomeTeam-->SenderUser
            //AwayTeam-->ReceiverUser

            //HomeMatches-->WriterSender
            //GuestMatches-->WriterReceiver


            modelBuilder.Entity<MessageWriter>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<MessageWriter>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRayting { get; set;}
        public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        public DbSet<MessageWriter> MessageWriters { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}
