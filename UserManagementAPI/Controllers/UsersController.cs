using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.DTOs;
using UserManagementAPI.Services;
namespace UserManagementAPI.Controllers;
[ApiController, Authorize, Route("api/users")]
public class UsersController(UserStore store) : ControllerBase {
    [HttpGet] public IActionResult GetAll() => Ok(store.All());
    [HttpGet("{id:guid}")] public IActionResult Get(Guid id) => store.Find(id) is { } user ? Ok(user) : NotFound(new { error = "User not found." });
    [HttpPost] public IActionResult Create([FromBody] UserInput input) {
        var user = store.Add(input.Name.Trim(), input.Email.Trim());
        return user is null ? Conflict(new { error = "Email already exists." }) : CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    [HttpPut("{id:guid}")] public IActionResult Update(Guid id, [FromBody] UserInput input) {
        var result = store.Update(id, input.Name.Trim(), input.Email.Trim());
        return !result.Found ? NotFound(new { error = "User not found." }) : result.Conflict ? Conflict(new { error = "Email already exists." }) : NoContent();
    }
    [HttpDelete("{id:guid}")] public IActionResult Delete(Guid id) => store.Delete(id) ? NoContent() : NotFound(new { error = "User not found." });
}
