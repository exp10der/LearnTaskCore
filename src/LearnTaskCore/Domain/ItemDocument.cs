namespace LearnTaskCore.Domain
{
    public class ItemDocument
    {
        public virtual int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public virtual int DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}