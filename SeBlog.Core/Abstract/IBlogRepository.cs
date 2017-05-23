using SeBlog.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeBlog.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
        Category Category(string categorySlug);

        IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize);
        IList<Tag> Tags();
        int TotalPostsForCategory(string categorySlug);

        IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize);
        int TotalPostsForTag(string tagSlug);
        Tag Tag(string tagSlug);

        IList<Post> PostsForSearch(string search, int pageNo, int pageSize);
        int TotalPostsForSearch(string search);

        Post Post(int year, int month, string titleSlug);

        IList<Category> Categories();
    }
}
