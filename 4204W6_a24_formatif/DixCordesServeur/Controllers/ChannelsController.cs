
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DixCordesServeur.Data;
using Microsoft.AspNetCore.Authorization;
using DixCordesServeur.Models;

namespace DixCordesServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly DixCordesServeurContext _context;

        public ChannelsController(DixCordesServeurContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetChannel()
        {
            if (_context.Channels == null)
            {
                return NotFound();
            }
            return await _context.Channels.ToListAsync();
        }
        [HttpPost("{channelName}")]
        public async Task<ActionResult> CreateChannel(string channelName) {
            Channel channel = new Channel {
                Name = channelName,
                Messages = new List<Message>()


            };
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Channel créer" });
        }
    }
}
