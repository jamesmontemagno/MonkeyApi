﻿using Microsoft.EntityFrameworkCore;

namespace MonkeyApp1.Data;

public class MonkeyApp1Context : DbContext
{
    public MonkeyApp1Context (DbContextOptions<MonkeyApp1Context> options)
        : base(options)
    {
    }

    public DbSet<MonkeyApp1.Models.Monkey> Monkey { get; set; } = default!;

    public DbSet<MonkeyApp1.Models.Continent> Continent { get; set; } = default!;
}
