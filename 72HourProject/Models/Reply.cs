﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HourProject.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }


        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}