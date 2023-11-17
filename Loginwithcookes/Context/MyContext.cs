using Loginwithcookes.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace Loginwithcookes.Context;

public class MyContext:DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<User> user { get; set; }
}