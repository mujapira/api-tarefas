namespace tarefas.Corp.Entities
{
    public partial class ChoreEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid SessionId { get; set; }
        public virtual SessionEntity Session { get; set; }
    }
}
