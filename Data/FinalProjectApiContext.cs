using FinalProjectApi.Models;
using Microsoft.EntityFrameworkCore;

public class FinalProjectApiContext(DbContextOptions<FinalProjectApiContext> options) : DbContext(options)
{
    public DbSet<FinalProjectApi.Models.TeamMember> TeamMember { get; set; } = default!;
    public DbSet<FinalProjectApi.Models.FavoriteGame> FavoriteGame { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember { Id = 1, FullName = "Anton Chepelev", BirthDate = new DateTime(2005, 11 , 14), CollegeProgram = "Information Technology", YearInProgram = "Junior" },
            new TeamMember { Id = 2, FullName = "Ashton Cashier", BirthDate = new DateTime(2004, 5, 25), CollegeProgram = "Information Technology", YearInProgram = "Senior" },
            new TeamMember { Id = 3, FullName = "Opey Obute", BirthDate = new DateTime(2005, 9, 20), CollegeProgram = "Information Technology", YearInProgram = "Junior" },
            new TeamMember { Id = 4, FullName = "Gavin Mcqueen", BirthDate = new DateTime(2005, 10, 16), CollegeProgram = "Information Technology", YearInProgram = "Junior" }
        );

        modelBuilder.Entity<FavoriteGame>().HasData(
            new FavoriteGame { Id = 1, Rank = 1, Title = "Team Fortress 2", Genre = "FPS", HoursPlayed = 500, FavoriteCharacter = "Scout", WhyILikeIt = "Very goofy and casual fun" },
            new FavoriteGame { Id = 2, Rank = 2, Title = "Red Dead Redemption", Genre = "Action Adventure", HoursPlayed = 300, FavoriteCharacter = "John Marston", WhyILikeIt = "Great story and open world" },
            new FavoriteGame { Id = 3, Rank = 3, Title = "Minecraft", Genre = "Sandbox", HoursPlayed = 200, FavoriteCharacter = "Steve", WhyILikeIt = "Love modding it" },
            new FavoriteGame { Id = 4, Rank = 4, Title = "Overwatch", Genre = "Hero Shooter", HoursPlayed = 150, FavoriteCharacter = "Tracer", WhyILikeIt = "Fun precision characters" },
            new FavoriteGame { Id = 5, Rank = 5, Title = "Dead by Daylight", Genre = "Horror", HoursPlayed = 100, FavoriteCharacter = "Bill Overbeck", WhyILikeIt = "Love hate relationship" },
            new FavoriteGame { Id = 6, Rank = 6, Title = "Left 4 Dead", Genre = "Co-op Shooter", HoursPlayed = 80, FavoriteCharacter = "Bill Overbeck", WhyILikeIt = "Fun Horde Shooter" }
        );
    }
}
