using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models;

public class Memo
{
    public int Id { get; set; }

    [Display(Name = "タイトル")]
    [Required(ErrorMessage = "タイトルは必須です")]
    public string Title { get; set; } = "";

    [Display(Name = "メモ")]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsCompleted { get; set; } = false;

    [Display(Name = "締切日時")]
    public DateTime? DueDate { get; set; }
}