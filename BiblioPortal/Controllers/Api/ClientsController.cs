using BiblioPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BiblioPortal.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private BiblioDbContext _context;
        public ClientsController(BiblioDbContext context)
        {
            _context = context;
        }


        // GET: api/clients
        [HttpGet]
        public IActionResult GetClient()
        {
            var clients = _context.Clients
                .Include(c => c.MembershipType).ToList(); 
            return Ok(clients);
        }

        // GET api/clients/5
        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound();
            return Ok(client);

        }

        // POST api/clients
        [HttpPost]
        public IActionResult CreateClient(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Clients.Add(client);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);

        }

        // PUT api/clients/5
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid client data.");
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (client == null)
                return NotFound($"Client with ID {id} not found.");
            clientInDb.Name = client.Name;
            clientInDb.DateOfBirth = client.DateOfBirth;
            clientInDb.Phone = client.Phone;
            clientInDb.Email = client.Email;
            clientInDb.IsSubscribeToNewsletter
                = client.IsSubscribeToNewsletter;
            clientInDb.MembershipTypeId = client.MembershipTypeId;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/clients/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (clientInDb == null)
                return NotFound($"Client with ID {id} not found.");
            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
