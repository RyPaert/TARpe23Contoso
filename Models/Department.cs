using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [StringLength(100, MinimumLength = 30)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        // Kaks oma andmetüüpi
        [Required]
        [StringLength(500)]
        public string? DepartmentDescription { get; set; }
        [Required]
        [StringLength(500)]
        public string? FrenchDepartmentDescription { get; set; }

        // Kaks oma andmetüüpi
        public int? InstructorID { get; set; }
        public byte? RowVersion { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
