using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskBoardApp.Data.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Models.Task>
    {

        public void Configure(EntityTypeBuilder<Models.Task> builder)
        {
            builder.HasData(SeedTasks());
        }

        private IEnumerable<Models.Task> SeedTasks() 
        {
            Models.Task[] tasks = new Models.Task[]
            {
                new Models.Task()
                {
                    Id= 1,
                    Title= "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.OpenBoard.Id
                },
                new Models.Task()
                {
                    Id= 2,
                    Title= "Android Client App",
                    Description = "Create Android client app for the TaskBoard RestFul API",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.OpenBoard.Id
                },
                new Models.Task()
                {
                    Id= 3,
                    Title= "Desktop Client App",
                    Description = "Create Windows Forms desktop app client for the TaskBoard RestFul API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.InProggressBoard.Id
                },
                new Models.Task()
                {
                    Id= 4,
                    Title= "Create Task",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = ConfigurationHelper.TestUser.Id,
                    BoardId = ConfigurationHelper.DoneBoard.Id
                }
            };

            return tasks;
        }

      
    }
}
