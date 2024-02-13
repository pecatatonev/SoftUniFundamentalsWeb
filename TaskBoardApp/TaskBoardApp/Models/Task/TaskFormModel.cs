using static TaskBoardApp.Data.DataConstants;
using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;
using System.Net;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(DataConstants.Task.TitleMaxLenght, MinimumLength = DataConstants.Task.TitleMinLenght,
            ErrorMessage = ErrorMessages.ErrorMessage)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(DataConstants.Task.DescriptionMaxLenght, MinimumLength = DataConstants.Task.DescriptionMinLenght,
           ErrorMessage = ErrorMessages.ErrorMessage)]
        public string Description { get; set; } = string.Empty;
        [Display(Name = DataConstants.Board.DisplayNameBoard)]
        public int BoardId { get; set; }
        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
