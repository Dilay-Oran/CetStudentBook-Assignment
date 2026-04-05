using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int Quantity { get; set; }
    }
}