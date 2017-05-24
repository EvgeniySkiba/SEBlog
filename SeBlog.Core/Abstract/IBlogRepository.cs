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
        Tag Tag(int id);
        Category Category(int id);

        IList<Post> PostsForSearch(string search, int pageNo, int pageSize);
        int TotalPostsForSearch(string search);
        Post Post(int year, int month, string titleSlug);
        IList<Category> Categories();

        IList<Post> Posts(int pageNo, int pageSize, string sortColumn,bool sortByAscending);
        int TotalPosts(bool checkIsPublished = true);

        // TODO: must be changed 
        int AddPost(Post post);

        int AddTag(Tag tag);

        int AddCategory(Category category);
        void EditCategory(Category category);

        void DeleteCategory(int id);

        void DeleteTag(int id);

        void EditTag(Tag tag);
    }
}
