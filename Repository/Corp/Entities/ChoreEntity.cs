namespace tarefas.Corp.Entities
{
    public partial class ChoreEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SessionId { get; set; }
        public virtual SessionEntity Session { get; set; }
    }
}
