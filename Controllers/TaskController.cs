using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IDO_Backend.Data;
using Task = IDO_Backend.Data.Task;
using System.Security.Claims;

namespace IDO_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/items/user/tasks
        [HttpGet("user/tasks")]
        public IActionResult GetTasksByUserId()
        {
            // Retrieve user ID from the token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
         

            // Retrieve tasks belonging to the specified user ID
            var tasks = _context.Tasks.Where(task => task.userId == int.Parse(userIdClaim)).ToList();
            return Ok(tasks);
        }

        [HttpPost("tasks")]
        public IActionResult AddTask([FromBody] Task task)
        {
            // Retrieve user ID from the token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return BadRequest("User ID not found in token.");
            }

            // Set the task's user ID to the authenticated user's ID
            task.userId = int.Parse(userIdClaim);

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtAction("GetTasksByUserId", task);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.email == model.Email && u.password == model.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // If login is successful, generate a token
            var token = JwtTokenGenerator.GenerateToken(new CustomTokenRequestModel { UserId = user.userId });

            return Ok(new { token });
        }

        [HttpPut("updateTask/{taskId}")]
        public IActionResult UpdateTask(int taskId, [FromBody] Task updatedTask)
        {
            // Retrieve the task from the database
            var task = _context.Tasks.FirstOrDefault(t => t.id == taskId);

            // Check if the task exists
            if (task == null)
            {
                return NotFound("Task not found.");
            }

            // Update only the fields that are allowed to change
            task.name = updatedTask.name ?? task.name;
            task.category = updatedTask.category ?? task.category;
            task.dueDate = updatedTask.dueDate != default ? updatedTask.dueDate : task.dueDate;
            task.estimate = updatedTask.estimate ?? task.estimate;
            task.importance = updatedTask.importance ?? task.importance;
            task.status = updatedTask.status ?? task.status;
            // Update other properties as needed

            // Save changes to the database
            _context.SaveChanges();

            return Ok("Task updated successfully.");
        }
    }
}
