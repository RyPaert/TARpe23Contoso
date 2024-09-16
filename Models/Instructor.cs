using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string? FirstMidName { get; set; }

        // Uus andmeväli moodustatakse olemasolevaist, mitte ei küsita kasutajalt korduvalt sama asja
        [Display(Name = "Full Name")]
        public string? FullName { get { return LastName + ", " + FirstMidName; } }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}")]
        [Display(Name = "Hired on:")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        //Minu propertyd
        [Display(Name = "Monthly pay is:")]
        public int? Wage{ get; set; }

        [Display(Name = "Parking Spot Number:")]
        public string? ParkingSpotNumber { get; set; }

        [Display(Name = "Gender:")]
        [StringLength(1)]
        public string? Gender { get; set; }
        public int? FavoriteStudentID {  get; set; }
    }
}
