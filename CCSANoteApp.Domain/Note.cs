namespace CCSANoteApp.Domain
{
    public class Note
    {
        public Note()
        { 
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
        public virtual User NoteCreator { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual GroupName GroupName { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}