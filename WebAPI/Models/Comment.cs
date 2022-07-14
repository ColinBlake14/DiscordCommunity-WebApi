using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public byte CommentLike { get; set; }

        public string CommentDate { get; set; }

        public string CommentUserName { get; set; }

        public int CommentServerId { get; set; }

        public string CommentStatus { get; set; }
    }
}
