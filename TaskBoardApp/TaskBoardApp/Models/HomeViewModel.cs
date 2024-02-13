namespace TaskBoardApp.Models
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; init; }
        public List<HomeBoardModel> BoardsWithTaskCount { get; init; } = new List<HomeBoardModel>();
        public int UserTasksCount { get; init; }
    }
}
