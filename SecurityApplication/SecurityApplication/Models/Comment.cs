using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityApplication.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [AllowHtml]
        public string CommentText { get; set; }
    }
}