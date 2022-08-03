using CCSANoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.Infrastructure.Services
{
    public class NoteService : INoteService
    {
        List<Note> notes = new List<Note>();
        public void CreateNote(Note note)
        {
            notes.Add(note);
        }

        public void CreateNote(User userId, string title, string content, GroupName groupName)
        {
            notes.Add(new Note
            {
                Title = title,
                Content = content,
                NoteCreator = userId,
                GroupName = groupName
            });
        }
        public void DeleteNote(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            if (note != null)
            {
                notes.Remove(note);
            }
        }
        public void DeleteNote(List<Note> notes)
        {
            foreach (Note note in notes)
            {
                DeleteNote(note.Id);
            }
        }
        public List<Note> FetchNote()
        {
            return notes;
        }
        public List<Note> FetchNoteByGroup(User userId, GroupName groupName)
        {
            var _notes = notes.Where(x => x.NoteCreator == userId && x.GroupName == groupName);
            return notes.ToList();
        }
        public Note FetchNoteById(Guid id)
        {
            var note = notes.FirstOrDefault(x => x.Id == id);
            return note;
        }
        public List<Note> FetchNoteByUser(User id)
        {
            var _notes = notes.Where(x => x.NoteCreator == id);
            return notes.ToList();
        }
        public void UpdateNote(Guid id, Note note)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = note.Title;
                _note.Content = note.Content;
                _note.GroupName = note.GroupName;
            }
        }

        public void UpdateNote(Guid id, string content)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Content = content;
            }
        }

        public void UpdateNoteTitle(Guid id, string title)
        {
            var _note = notes.FirstOrDefault(x => x.Id == id);
            if (_note != null)
            {
                _note.Title = title;
            }
        }
    }
}
