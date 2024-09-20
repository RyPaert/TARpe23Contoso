using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;

public class DbInitializer
{
	public static void Initialize(SchoolContext context)
	{
		//Teeb kindlaks, et andmebaas tehakse või oleks olemas.
		context.Database.EnsureCreated();
		

		// Kui õpilaste tabelis juba on õpilasi väljub funktisoonist.
		if (context.Students.Any())
		{
			return;
		}

		// Objekt õpilastega, mis lisatakse siis, kui õpilasi sisestatud ei ole.
		var students = new Student[]
		{
			// new Student{firstMidName="", LastName="", EnrollmentDate=DateTime.Parse("")}
			new Student{FirstMidName="Artjom", LastName="Skatškov", EnrollmentDate=DateTime.Parse("2069-04-20")},
			new Student{FirstMidName="Meredith", LastName="Alonso", EnrollmentDate=DateTime.Parse("2002-09-01")},
			new Student{FirstMidName="Thomas-Henry", LastName="Pärt", EnrollmentDate=DateTime.Parse("2005-02-19")},
			new Student{FirstMidName="Arturo", LastName="Anand", EnrollmentDate=DateTime.Parse("2005-02-19")},
			new Student{FirstMidName="Gytis", LastName="Barzdukas", EnrollmentDate=DateTime.Parse("2003-09-01")},
			new Student{FirstMidName="Yan", LastName="Li", EnrollmentDate=DateTime.Parse("2004-09-01")},
			new Student{FirstMidName="Peggy", LastName="Justice", EnrollmentDate=DateTime.Parse("2005-09-01")},
			new Student{FirstMidName="Laura", LastName="Norman", EnrollmentDate=DateTime.Parse("2006-09-01")},
			new Student{FirstMidName="Nino", LastName="Olivetto", EnrollmentDate=DateTime.Parse("2007-09-01")},
			new Student{FirstMidName="Carson", LastName="Alexander", EnrollmentDate=DateTime.Parse("2008-09-01")},
		};

		// Iga õpilane lisatakse ükshaaval läbi foreach tsükli
		foreach (Student student in students)
		{
			context.Students.Add(student);
		}
		// Ja andmebaasi muudatused salvestatakse.
		context.SaveChanges();
		// Sama struktuur mis enne aga kursustega 
		var Courses = new Course[]
		{
			//new Course{CourseID=, Title="", Credits=},
			new Course{CourseID=1050, Title="Keemia", Credits=3},
            new Course{CourseID=4022, Title="Mikroökonoomika", Credits=3},
            new Course{CourseID=4041, Title="Mikroökonoomika", Credits=3},
            new Course{CourseID=1045, Title="Calculus", Credits=4},
            new Course{CourseID=3141, Title="Trigonomeetria", Credits=4},
            new Course{CourseID=3141, Title="Kompositsioon", Credits=4},
            new Course{CourseID=2021, Title="Kirjandus", Credits=3},
            new Course{CourseID=9000, Title="faze clan hate club", Credits=1},
        };
		context.Courses.AddRange(Courses);
		context.SaveChanges();

		if (context.Enrollments.Any()) { return; }
		var enrollments = new Enrollment[]
		{
			new Enrollment{StudentID=1, CourseID=1050, Grade=Grade.A},
            new Enrollment{StudentID=1, CourseID=4022, Grade=Grade.C},
            new Enrollment{StudentID=1, CourseID=4041, Grade=Grade.B},

            new Enrollment{StudentID=2, CourseID=1045, Grade=Grade.B},
            new Enrollment{StudentID=2, CourseID=3141, Grade=Grade.F},
            new Enrollment{StudentID=2, CourseID=2021, Grade=Grade.F},

            new Enrollment{StudentID=3, CourseID=9000},

            new Enrollment{StudentID=4, CourseID=1050},
            new Enrollment{StudentID=4, CourseID=4022, Grade=Grade.F},

            new Enrollment{StudentID=5, CourseID=4041, Grade=Grade.C},

            new Enrollment{StudentID=6, CourseID=1045},

            new Enrollment{StudentID=7, CourseID=3141, Grade=Grade.A},

            new Enrollment{StudentID=10, CourseID=1050, Grade=Grade.A},
        };
		context.Enrollments.AddRange(enrollments);
		context.SaveChanges();


        if (context.Instructors.Any()) { return; }

        // Objekt õpilastega, mis lisatakse siis, kui õpilasi sisestatud ei ole.
        var instructors = new Instructor[]
        {
			// new Student{firstMidName="", LastName="", EnrollmentDate=DateTime.Parse("")}
			new Instructor{FirstMidName="Beth", 
							LastName="Schunk", 
							HireDate=DateTime.Parse("2069-04-20"),
							ParkingSpotNumber="",
							Gender="F")},
            new Instructor{FirstMidName="Miz", LastName="Kif", HireDate=DateTime.Parse("2002-09-01")},
            new Instructor{FirstMidName="Yung", LastName="Jeff", HireDate=DateTime.Parse("2005-02-19")},
            new Instructor{FirstMidName="Mynama", LastName="Jeff", HireDate=DateTime.Parse("2005-02-19")},
            new Instructor{FirstMidName="John", LastName="Venelane", HireDate=DateTime.Parse("2003-09-01")},
            new Instructor{FirstMidName="John", LastName="Ubisoft", HireDate=DateTime.Parse("2004-09-01")},
            new Instructor{FirstMidName="Student", LastName="Teacher", HireDate=DateTime.Parse("2005-09-01")},
            new Instructor{FirstMidName="Franz", LastName="Ferdinand", HireDate=DateTime.Parse("2006-09-01")},
            new Instructor{FirstMidName="Sigma", LastName="Toilet", HireDate=DateTime.Parse("2007-09-01")},
            new Instructor{FirstMidName="Skibidi", LastName="Gyatt", HireDate=DateTime.Parse("2008-09-01")},
        };
        foreach (Instructor instructor in instructors)
        {
            context.Instructors.Add(instructor);
        }

        context.Instructors.AddRange(instructors);
        context.SaveChanges();
    }
}
