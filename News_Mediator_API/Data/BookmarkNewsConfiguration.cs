using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News_Mediator_API.Models;

namespace News_Mediator_API.Data
{
    public class BookmarkNewsConfiguration : IEntityTypeConfiguration<BookMark>
    {
        public void Configure(EntityTypeBuilder<BookMark> builder)
        {
            builder.HasIndex(bookmarkNews => new { bookmarkNews.UserId, bookmarkNews.NewsId }).IsUnique();
            builder.HasOne(bookmarkNews => bookmarkNews.User).WithMany(user => user.BookMarks).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(bookmarkNews => bookmarkNews.News).WithMany(news => news.BookMarks).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
