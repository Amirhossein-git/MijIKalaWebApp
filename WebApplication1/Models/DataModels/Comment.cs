using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MijiKalaWebApp.Models.DataModels
{
    public class Comment
    {
        public Comment()
        {
            CommentId = Guid.NewGuid();
        }
        public Guid CommentId { get; set; }

        public Guid ProductId { get; set; }

        public string CommentText { get; set; }

        public DateTime SubmitDate { get; set; }

        public string CommentTitle { get; set; }
    }
}
