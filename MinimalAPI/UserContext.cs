using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI;

public class UserContext : DbContext
{    
    public UserContext() { }
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    //public DbSet<UserModel> Users { get; set; }

}