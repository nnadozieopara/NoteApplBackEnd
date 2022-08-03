using CCSANoteApp.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.DB.Mappings
{
    public class NoteMap : ClassMap<Note>
    {
        public NoteMap()
        {
            Table("Notes");
            Id(note => note.Id);
            References(note => note.NoteCreator);
            Map(note => note.Title);
            Map(note => note.Content);
            Map(note => note.GroupName);
            Map(note => note.CreatedDate);
            Map(note => note.UpdatedDate);
        }
    }

}
