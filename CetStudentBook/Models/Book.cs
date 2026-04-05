using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CetStudentBook.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 200 characters.")]
        [DisplayName("Book Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Author must be between 2 and 200 characters.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publish date is required.")]
        [DataType(DataType.Date)]
        [DisplayName("Publish Date")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "Page count is required.")]
        [Range(1, 10000, ErrorMessage = "Page count must be between 1 and 10000.")]
        [DisplayName("Page Count")]
        public int PageCount { get; set; }

        [Required]
        [DisplayName("Second Hand?")]
        public bool IsSecondHand { get; set; }

        // Bunları ekle:
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}