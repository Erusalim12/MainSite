using System;
using System.Collections.Generic;

namespace Application.Dal.Domain.FeedBack
{
    public class Question : BaseEntity
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        public string Title { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public string CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
