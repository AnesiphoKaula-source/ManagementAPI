namespace UserManagementAPI.Models;
public record UserRecord(Guid Id, string Name, string Email, DateTimeOffset CreatedAt);
