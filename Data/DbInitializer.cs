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
		context.Students.AddRange(students);
		context.SaveChanges();

        if (context.Courses.Any()) 
		{ 
			return; 
		}

        var courses = new Course[]
		{
			//new Course{CourseID=, Title="", Credits=},
			new Course{ID=1050, Title="Keemia", Credits=3},
            new Course{ID=4022, Title="Mikroökonoomika", Credits=3},
            new Course{ID=4041, Title="Mikroökonoomika", Credits=3},
            new Course{ID=1045, Title="Calculus", Credits=4},
            new Course{ID=3141, Title="Trigonomeetria", Credits=4},
            new Course{ID=3141, Title="Kompositsioon", Credits=4},
            new Course{ID=2021, Title="Kirjandus", Credits=3},
            new Course{ID=9000, Title="faze clan hate club", Credits=1},
        };
		context.Courses.AddRange(courses);
		context.SaveChanges();

		/*
		if (context.Enrollments.Any()) 
		{ 
			return; 
		}
		
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
		*/

        if (context.Instructors.Any()) 
		{ 
			return; 
		}

		// Objekt õpilastega, mis lisatakse siis, kui õpilasi sisestatud ei ole.
		var instructors = new Instructor[]
		{
			// new Student{firstMidName="", LastName="", EnrollmentDate=DateTime.Parse("")}
			new Instructor{FirstMidName="Beth",
					LastName="Schunk",
							HireDate=DateTime.Parse("2069-04-20"),
							ParkingSpotNumber="A1",
							Gender="F"},
            new Instructor{FirstMidName="Miz",
							LastName="Kif",
							HireDate=DateTime.Parse("2002-09-01"),
							Gender="M"
							}
        };
        context.Instructors.AddRange(instructors);
        context.SaveChanges();

		if (context.Departments.Any())
		{
			return;
		}
		var departments = new Department[]
		{
			new Department
			{
				Name = "InfoTechnology",
				Budget = 0,
				StartDate = DateTime.Parse("2024/01/01"),
				DepartmentDescription = "Sigma sigma on the wall who is the skibidest of them all",
				FrenchDepartmentDescription = "Sigma Sigma sur le mur qui est le plus skiable de tous",
				InstructorID = 1,
            },
            new Department
            {
                Name = "SigmaTechnology",
                Budget = 0,
                StartDate = DateTime.Parse("2024/05/05"),
                DepartmentDescription = "Do you know what it's like to have a conversation sigma to sigma, rizz",
                FrenchDepartmentDescription = "Savez-vous ce que c'est que d'avoir une conversation sigma à sigma, Rizz ?",
                InstructorID = 2,
            },
            new Department
            {
                Name = "CS Smoke Lineups",
                Budget = 0,
                StartDate = DateTime.Parse("1842/05/05"),
                DepartmentDescription = "CS2 Smoke lineups",
                FrenchDepartmentDescription = "Composition des équipes de CS2 Smoke"
            }
        };
    }
}
