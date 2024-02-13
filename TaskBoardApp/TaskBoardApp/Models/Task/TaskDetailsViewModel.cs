namespace TaskBoardApp.Models.Task
{
    public class TaskDetailsViewModel : TaskViewModel
    {
        public string CreatedOn { get; init; } = string.Empty;
        public string Board { get; set; } = string.Empty;
    }
}
