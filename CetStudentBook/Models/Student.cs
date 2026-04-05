using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CetStudentBook.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Length(3, 200)]
        [DisplayName("Full Name")]
        // "= string.Empty;" ekleyerek başlangıçta boş olmadığını garanti ediyoruz.
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        [Length(5, 200)]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}