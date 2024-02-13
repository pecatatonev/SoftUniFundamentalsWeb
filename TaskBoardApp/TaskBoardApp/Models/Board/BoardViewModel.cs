using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Models.Board
{
    public class BoardViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstants.Board.NameMaxLenght, MinimumLength = DataConstants.Board.NameMinLenght,
            ErrorMessage = DataConstants.ErrorMessages.ErrorMessage)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
