using CCSANoteApp.Domain;

namespace CCSANoteApp.Infrastructure.Services
{
    public interface INoteService
    {
        void CreateNote(User userId, string title, string content, GroupName groupName);
        void CreateNote(Note note);
        void DeleteNote(Guid id);
        void DeleteNote(List<Note> notes);
        List<Note> FetchNote();
        List<Note> FetchNoteByGroup(User userId, GroupName groupName);
        Note FetchNoteById(Guid id);
        List<Note> FetchNoteByUser(User id);
        void UpdateNote(Guid id, Note note);
        void UpdateNote(Guid id, string content);
        void UpdateNoteTitle(Guid id, string title);
    }
}