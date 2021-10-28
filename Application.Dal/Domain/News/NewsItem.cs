using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Dal.Domain.Files;
using Application.Dal.Infrastructure;

namespace Application.Dal.Domain.News
{
    public class NewsItem : BaseEntity
    {
        [FullTextIndex]
        public string Header { get; set; }
        [FullTextIndex]
        public string Description { get; set; }
        public bool IsAdvancedEditor { get; set; }
        public string Category { get; set; }
        public string AuthorFio { get; set; }
        public string AuthorId { get; set; }
       
        [Column("LastChangeAuthor")]
        public string LastChangeAuthorFio { get; set; }
        public string LastChangeAuthorId { get; set; }
        public DateTime LastChangeDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}