namespace LearnTaskCore.Domain
{
    using System.Collections.Generic;

    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public virtual ICollection<ItemDocument> ItemDocuments { get; set; }
    }
}