using System.Collections.Generic;

namespace NullableRefsSample
{
    public class BlogPost
    {
        public string? Title { get; set; }
        public List<Comment>? Comments { get; set; }
    }

    public class Comment
    {
        public string? Body { get; set; }
        public Author? PostedBy { get; set; }
    }

    public class Author
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
    }

}
