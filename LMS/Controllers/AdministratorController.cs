using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Department(string subject)
        {
            ViewData["subject"] = subject;
            return View();
        }

        public IActionResult Course(string subject, string num)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }

        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of all the courses in the given department.
        /// Each object in the array should have the following fields:
        /// "number" - The course number (as in 5530)
        /// "name" - The course name (as in "Database Systems")
        /// </summary>
        /// <param name="subject">The department subject abbreviation (as in "CS")</param>
        /// <returns>The JSON result</returns>
        public IActionResult GetCourses(string subject)
        {
            using (db)
            {
                var query =
                    from p in db.Courses
                    where p.Subject == subject
                    select new
                    {
                        number = p.Number,
                        name = p.Name
                    };
                return Json(query.ToArray());
            }

        }





        /// <summary>
        /// Returns a JSON array of all the professors working in a given department.
        /// Each object in the array should have the following fields:
        /// "lname" - The professor's last name
        /// "fname" - The professor's first name
        /// "uid" - The professor's uid
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <returns>The JSON result</returns>
        public IActionResult GetProfessors(string subject)
        {
            using (db)
            {
                var query =
                    from p in db.Professor
                    where p.Subject == subject
                    join u in db.Users
                    on p.UId equals u.UId

                    select new
                    {
                        lname = u.LName,
                        fname = u.FName,
                        uid = u.UId
                    };
                return Json(query.ToArray());
            }
        }



        /// <summary>
        /// Creates a course.
        /// A course is uniquely identified by its number + the subject to which it belongs
        /// </summary>
        /// <param name="subject">The subject abbreviation for the department in which the course will be added</param>
        /// <param name="number">The course number</param>
        /// <param name="name">The course name</param>
        /// <returns>A JSON object containing {success = true/false}.
        /// false if the course already exists, true otherwise.</returns>
        public IActionResult CreateCourse(string subject, int number, string name)
        {
            string cID = "";

            using (db)
            {
                var query =
                    (from p in db.Courses
                     orderby p.CatalogId descending
                     select p.CatalogId).Take(1);
                if (query.ToArray().Count() == 0)
                {
                    cID = "00000";
                }
                else
                {
                    cID = query.ToArray()[0];
                    int temp = Int32.Parse(cID);
                    cID = (temp + 1).ToString();
                    while (cID.Count() != 5)
                    {
                        cID = cID.Insert(0, "0");
                    }
                }

                Courses c = new Courses();
                c.CatalogId = cID;
                c.Subject = subject;
                c.Number = number.ToString();
                c.Name = name;
                db.Add(c);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return Json(new { success = false });
                }

                return Json(new { success = true });
            };

        }



        /// <summary>
        /// Creates a class offering of a given course.
        /// </summary>
        /// <param name="subject">The department subject abbreviation</param>
        /// <param name="number">The course number</param>
        /// <param name="season">The season part of the semester</param>
        /// <param name="year">The year part of the semester</param>
        /// <param name="start">The start time</param>
        /// <param name="end">The end time</param>
        /// <param name="location">The location</param>
        /// <param name="instructor">The uid of the professor</param>
        /// <returns>A JSON object containing {success = true/false}. 
        /// false if another class occupies the same location during any time 
        /// within the start-end range in the same semester, or if there is already
        /// a Class offering of the same Course in the same Semester,
        /// true otherwise.</returns>
        public IActionResult CreateClass(string subject, int number, string season, int year, DateTime start, DateTime end, string location, string instructor)
        {
            string CatalogID = "";
            int cID = 0;
            using (db)
            {
                var query = from p in db.Courses
                            where p.Subject == subject && p.Number == number.ToString()
                            select p.CatalogId;
                CatalogID = query.ToArray()[0];

                var query2 = (from p in db.Classes
                              orderby p.CId descending
                              select p.CId).Take(1);


                var getExsistingClass = from cla in db.Classes
                                        where cla.Loc == location && ((start.TimeOfDay <= cla.Start && cla.Start <= end.TimeOfDay) || (start.TimeOfDay <= cla.End && cla.End <= end.TimeOfDay)) && (cla.Semester == season + year)
                                        select cla;

                var ifProfessorNotFree = from cla in db.Classes
                                         where cla.UId == instructor && ((start.TimeOfDay <= cla.Start && cla.Start <= end.TimeOfDay) || (start.TimeOfDay <= cla.End && cla.End <= end.TimeOfDay)) && (cla.Semester == season + year)
                                         select cla;


                if (getExsistingClass.ToArray().Count() != 0 || ifProfessorNotFree.ToArray().Count() != 0)
                {
                    return Json(new { success = false });
                }

                if (query2.ToArray().Count() != 0)
                {
                    cID = query2.ToArray()[0];
                    cID++;
                }

                Classes c = new Classes();

                c.CId = cID;
                c.Semester = season + year.ToString();
                c.CatalogId = CatalogID;
                c.UId = instructor;
                c.Loc = location;
                c.Start = start.TimeOfDay;
                c.End = end.TimeOfDay;

                db.Add(c);
                try
                {
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception f)
                {
                    System.Diagnostics.Debug.WriteLine("-------------");
                    System.Diagnostics.Debug.WriteLine(f);
                    System.Diagnostics.Debug.WriteLine("-------------");
                    return Json(new { success = false });
                }

            }
        }

    }


    /*******End code to modify********/

}
