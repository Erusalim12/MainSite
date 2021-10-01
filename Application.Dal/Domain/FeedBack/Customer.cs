using System.Collections.Generic;

namespace Application.Dal.Domain.FeedBack
{
    public class Customer:  BaseEntity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
