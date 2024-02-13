using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.Board.NameMaxLenght)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}