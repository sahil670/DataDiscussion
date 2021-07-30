using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataDiscussion.Data;
using DataDiscussion.Model;

namespace DataDiscussion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DataDiscussionContext _context;


        public MessagesController(DataDiscussionContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        //Gets all the mesages using a linq query
        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessage()
        {
            return (from messages in _context.Message select messages).ToList();
        }



        // GET: api/Messages/5
        //Gets a single message 
        [HttpGet("{id}")]
        public ActionResult<Message> GetMessage(int id)
        {
            var message = (from messages in _context.Message
                           where messages.Id == id
                           select messages).FirstOrDefault();

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the message 
        [HttpPut("{id}")]
        public IActionResult PutMessage(int id, Message message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Messages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds  a message to the database.
        [HttpPost]
        public ActionResult<Message> PostMessage(Message message)
        {
            _context.Message.Add(message);
            _context.SaveChanges();

            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        //Deletes a message from database.
        [HttpDelete("{id}")]
        public ActionResult<Message> DeleteMessage(int id)
        {
            var message = _context.Message.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Message.Remove(message);
            _context.SaveChanges();

            return message;
        }

        //Checks message exists using a lamda.
        private bool MessageExists(int id)
        {
            return _context.Message.Any(e => e.Id == id);
        }


    }
}
