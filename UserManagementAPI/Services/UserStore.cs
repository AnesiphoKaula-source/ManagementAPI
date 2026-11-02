using System.Collections.Concurrent;
using UserManagementAPI.Models;
namespace UserManagementAPI.Services;
public class UserStore {
    private readonly ConcurrentDictionary<Guid, UserRecord> _users = new();
    private readonly object _gate = new();
    public IEnumerable<UserRecord> All() => _users.Values.OrderBy(x => x.Name).ToArray();
    public UserRecord? Find(Guid id) => _users.TryGetValue(id, out var user) ? user : null;
    public UserRecord? Add(string name, string email) { lock (_gate) {
        if (_users.Values.Any(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase))) return null;
        var user = new UserRecord(Guid.NewGuid(), name, email, DateTimeOffset.UtcNow);
        _users[user.Id] = user; return user;
    }}
    public (bool Found, bool Conflict) Update(Guid id, string name, string email) { lock (_gate) {
        if (!_users.TryGetValue(id, out var existing)) return (false, false);
        if (_users.Values.Any(x => x.Id != id && x.Email.Equals(email, StringComparison.OrdinalIgnoreCase))) return (true, true);
        _users[id] = existing with { Name = name, Email = email }; return (true, false);
    }}
    public bool Delete(Guid id) => _users.TryRemove(id, out _);
}
