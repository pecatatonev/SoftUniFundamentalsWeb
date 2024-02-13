using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;

namespace TaskBoardApp.Models.Task
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Task.TitleMaxLenght, MinimumLength = DataConstants.Task.TitleMinLenght,
            ErrorMessage = DataConstants.ErrorMessages.ErrorMessage)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(DataConstants.Task.DescriptionMaxLenght, MinimumLength = DataConstants.Task.DescriptionMinLenght,
           ErrorMessage = DataConstants.ErrorMessages.ErrorMessage)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Owner { get; set; } = string.Empty;
    }
}