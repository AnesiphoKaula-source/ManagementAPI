using System.ComponentModel.DataAnnotations;
namespace UserManagementAPI.DTOs;
public class UserInput {
    [Required, StringLength(100, MinimumLength = 2)] public string Name { get; set; } = "";
    [Required, EmailAddress, StringLength(254)] public string Email { get; set; } = "";
}
