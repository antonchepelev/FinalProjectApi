using FinalProjectApi.Models;
using Microsoft.EntityFrameworkCore;

public class FinalProjectApiContext(DbContextOptions<FinalProjectApiContext> options) : DbContext(options)
{
    public DbSet<FinalProjectApi.Models.TeamMember> TeamMember { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, FullName = "Anton Chepelev", BirthDate = new DateTime(2005, 11 , 14), CollegeProgram = "Information Technology", YearInProgram = "Junior" },
            new TeamMember { Id = 2, FullName = "Ashton Cashier", BirthDate = new DateTime(2004, 5, 25), CollegeProgram = "Information Technology", YearInProgram = "Senior" },
            new TeamMember { Id = 3, FullName = "Opey Obute", BirthDate = new DateTime(2005, 9, 20), CollegeProgram = "Information Technology", YearInProgram = "Junior" },
            new TeamMember { Id = 4, FullName = "Gavin Mcqueen", BirthDate = new DateTime(2005, 10, 16), CollegeProgram = "Information Technology", YearInProgram = "Junior" }
        );
    }
}
