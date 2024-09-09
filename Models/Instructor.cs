﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        // Uus andmeväli moodustatakse olemasolevaist, mitte ei küsita kasutajalt korduvalt sama asja
        [Display(Name = "Full Name")]
        public string FullName { get { return LastName + ", " + FirstMidName; } }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}")]
        [Display(Name = "Hired on:")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment> CourseAssignment { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }

        //Minu propertyd
        [Required]
        [Display(Name = "Monthly pay is:")]
        public int Wage{ get; set; }

        [Display(Name = "Parking Spot Number:")]
        public ParkingSpotNumber? ParkingSpotNumber { get; set; }

        [Required]
        [Display(Name = "Gender:")]
        [StringLength(1)]
        public string Gender { get; set; }
        public int FavoriteStudentID {  get; set; }
        public CriminalRecord? CriminalRecord { get; set; }
    }
}
