namespace Application.Dal.Domain.ExternalLinks
{
    public class ExternalLink : BaseEntity
    {
        public string Name { get; set; }
        public string PathIcon { get; set; }
        public string Url { get; set; }

        public int Order { get; set; }
    }
}
