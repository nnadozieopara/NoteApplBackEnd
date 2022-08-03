using CCSANoteApp.Domain;
using CCSANoteApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public INoteService DatabaseService { get; }
        public NoteController(INoteService databaseService)
        {
            DatabaseService = databaseService;
        }
        [HttpPost("byNote")]
        public IActionResult CreateNote([FromBody] Note note)
        {
            DatabaseService.CreateNote(note);
            return Ok("Created Successfully");
        }

        [HttpPost]
        public IActionResult CreateNote(User userId, string title, string content, GroupName groupName)
        {
            DatabaseService.CreateNote(userId, title, content, groupName);
            return Ok("Created Successfully");
        }
        [HttpDelete]
        public IActionResult DeleteNote(Guid id)
        {
            DatabaseService.DeleteNote(id);
            return Ok("Deleted Successfully");
        }

        [HttpDelete("multiple")]
        public IActionResult DeleteNote([FromBody]List<Note> notes)
        {
            DatabaseService.DeleteNote(notes);
            return Ok("Deleted Successfully");
        }
        [HttpGet("note")]
        public IActionResult FetchNote()
        {
            return Ok(DatabaseService.FetchNote());
        }
        [HttpGet("notegroup")]
        public IActionResult FetchNoteByGroup(User userId, GroupName groupName)
        {
            return Ok(DatabaseService.FetchNoteByGroup(userId,groupName));
        }

        [HttpGet("byId/{id}")]
        public IActionResult FetchNoteById(Guid id)
        {
            return Ok(DatabaseService.FetchNoteById(id));
        }

        [HttpGet("byUser/{id}")]
        public IActionResult FetchNoteByUser(User id)
        {
            return Ok(DatabaseService.FetchNoteByUser(id));
        }
        [HttpPut]
        public IActionResult UpdateNote(Guid id, [FromBody] Note note)
        {
            DatabaseService.UpdateNote(id, note);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatecontent")]
        public IActionResult UpdateNote(Guid id, string content)
        {
            DatabaseService.UpdateNote(id, content);
            return Ok("Updated Successfully");
        }

        [HttpPut("updatetitle")]
        public IActionResult UpdateNoteTitle(Guid id, string title)
        {
            DatabaseService.UpdateNoteTitle(id, title);
            return Ok("Updated Successfully");
        }
    }
}
