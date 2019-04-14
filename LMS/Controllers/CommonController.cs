using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    public class CommonController : Controller
    {

        /*******Begin code to modify********/

        // TODO: Uncomment and change 'X' after you have scaffoled


        protected Team77LMSContext db;

        public CommonController()
        {
            db = new Team77LMSContext();
        }


        /*
         * WARNING: This is the quick and easy way to make the controller
         *          use a different LibraryContext - good enough for our purposes.
         *          The "right" way is through Dependency Injection via the constructor 
         *          (look this up if interested).
        */

        // TODO: Uncomment and change 'X' after you have scaffoled

        public void UseLMSContext(Team77LMSContext ctx)
        {
            db = ctx;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        /// <summary>
        /// Retreive a JSON array of all departments from the database.
        /// Each object in the array should have a field called "name" and "subject",
        /// where "name" is the department name and "subject" is the subject abbreviation.
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetDepartments()
        {
            // TODO: Do not return this hard-coded array.
            using (db)
            {
                var query =
                    from p in db.Departments
                    select new
                    {
                        subject = p.Subject,
                        name = p.Name
                    };
                return Json(query.ToArray());
            }


        }



        /// <summary>
        /// Returns a JSON array representing the course catalog.
        /// Each object in the array should have the following fields:
        /// "subject": The subject abbreviation, (e.g. "CS")
        /// "dname": The department name, as in "Computer Science"
        /// "courses": An array of JSON objects representing the courses in the department.
        ///            Each field in this inner-array should have the following fields:
        ///            "number": The course number (e.g. 5530)
        ///            "cname": The course name (e.g. "Database Systems")
        /// </summary>
        /// <returns>The JSON array</returns>
        public IActionResult GetCatalog()
        {
            using (db)
            {
                var query =
                    from p in db.Departments
                    select new
                    {
                        subject = p.Subject,
                        dname = p.Name,
                        courses = from i in p.Courses
                                  select new { number = i.Number, cname = i.Name }
                    };
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all class offerings of a specific course.
        /// Each object in the array should have the following fields:
        /// "season": the season part of the semester, such as "Fall"
        /// "year": the year part of the semester
        /// "location": the location of the class
        /// "start": the start time in format "hh:mm:ss"
        /// "end": the end time in format "hh:mm:ss"
        /// "fname": the first name of the professor
        /// "lname": the last name of the professor
        /// </summary>
        /// <param name="subject">The subject abbreviation, as in "CS"</param>
        /// <param name="number">The course number, as in 5530</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetClassOfferings(string subject, int number)
        {
            using (db)
            {
                var query =
                    from p in db.Courses
                    where p.Subject == subject && p.Number == number.ToString()
                    join c in db.Classes on p.CatalogId equals c.CatalogId
                    join pf in db.Users on c.UId equals pf.UId
                    select new
                    {
                        season = c.Semester.Remove(c.Semester.Count() - 4),
                        year = c.Semester.Substring(c.Semester.Count() - 4),
                        location = c.Loc,
                        start = c.Start,
                        end = c.End,
                        fname = pf.FName,
                        lname = pf.LName
                    };
                return Json(query.ToArray());
            }
        }


        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <returns>The assignment contents</returns>
        public IActionResult GetAssignmentContents(string subject, int num, string season, int year, string category, string asgname)
        {

            using (db)
            {
                var query =
                        from p in db.Courses
                        where p.Subject == subject && p.Number == num.ToString()
                        join c in db.Classes on p.CatalogId equals c.CatalogId
                        where c.Semester == (season + year.ToString())
                        join e in db.AssignmentCategories on c.CId equals e.CId
                        where e.Name == category
                        join a in db.Assignments on e.AcId equals a.AcId
                        where a.Name == asgname
                        select a.Contents;
                return Content(query.ToArray()[0]);
            }
        }


        /// <summary>
        /// This method does NOT return JSON. It returns plain text (containing html).
        /// Use "return Content(...)" to return plain text.
        /// Returns the contents of an assignment submission.
        /// Returns the empty string ("") if there is no submission.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment in the category</param>
        /// <param name="uid">The uid of the student who submitted it</param>
        /// <returns>The submission text</returns>
        public IActionResult GetSubmissionText(string subject, int num, string season, int year, string category, string asgname, string uid)
        {

            using (db)
            {

                var getCid = from course in db.Courses
                             where course.Subject == subject && Int32.Parse(course.Number) == num
                             join cla in db.Classes
                             on course.CatalogId equals cla.CatalogId
                             into courJoincla

                             from c in courJoincla
                             where season == c.Semester.Remove(c.Semester.Count() - 4) && year == Int32.Parse(c.Semester.Substring(c.Semester.Count() - 4))
                             select new
                             {
                                 Cid = c.CId

                             };

                var getStudentCid = from enroll in db.EnrollmentGrade
                                    where enroll.UId == uid && enroll.CId == getCid.ToArray()[0].Cid
                                    select new
                                    {
                                        Cid = enroll.CId
                                    };

                var getAid = from cate in db.AssignmentCategories
                             where cate.CId == getStudentCid.ToArray()[0].Cid
                             join assign in db.Assignments
                             on cate.AcId equals assign.AcId
                             where assign.Name == asgname

                             select new
                             {
                                 Aid = assign.AId
                             };

                var getSubmissionContents = from sub in db.Submission
                                            where sub.AId == getAid.ToArray()[0].Aid && sub.UId == uid
                                            select sub.Contents;


                if (getSubmissionContents.Count() == 0)
                {
                    return Content("");
                }

                return Content(getSubmissionContents.ToArray()[0]);
            }
        }


        /// <summary>
        /// Gets information about a user as a single JSON object.
        /// The object should have the following fields:
        /// "fname": the user's first name
        /// "lname": the user's last name
        /// "uid": the user's uid
        /// "department": (professors and students only) the name (such as "Computer Science") of the department for the user. 
        ///               If the user is a Professor, this is the department they work in.
        ///               If the user is a Student, this is the department they major in.    
        ///               If the user is an Administrator, this field is not present in the returned JSON
        /// </summary>
        /// <param name="uid">The ID of the user</param>
        /// <returns>
        /// The user JSON object 
        /// or an object containing {success: false} if the user doesn't exist
        /// </returns>
        public IActionResult GetUser(string uid)
        {
            using (db)
            {
                var query1 = from s in db.Students
                             where s.UId == uid
                             join u in db.Users
                             on s.UId equals u.UId
                             select new
                             {
                                 fname = u.FName,
                                 lname = u.LName,
                                 uid = s.UId,
                                 department = s.Subject

                             };
                var query2 = from s in db.Professor
                             where s.UId == uid
                             join u in db.Users
                             on s.UId equals u.UId
                             select new
                             {
                                 fname = u.FName,
                                 lname = u.LName,
                                 uid = s.UId,
                                 department = s.Subject
                             };

                var query3 = from s in db.Administrators
                             where s.UId == uid
                             join u in db.Users
                             on s.UId equals u.UId
                             select new
                             {
                                 fname = u.FName,
                                 lname = u.LName,
                                 uid = s.UId,

                             };
                if (query1.ToArray().Count() != 0)
                {
                    users u = new users();
                    //u.Students = s;
                    u.uid = uid;
                    u.fname = query1.ToArray()[0].fname;
                    u.lname = query1.ToArray()[0].lname;
                    u.department = query1.ToArray()[0].department;
                    return Json(u);
                }
                else if (query2.ToArray().Count() != 0)
                {
                    users u = new users();
                    //u.Students = s;
                    u.uid = uid;
                    u.fname = query2.ToArray()[0].fname;
                    u.lname = query2.ToArray()[0].lname;
                    u.department = query2.ToArray()[0].department;
                    return Json(u);
                }
                else if (query3.ToArray().Count() != 0)
                {
                    users u = new users();
                    //u.Students = s;
                    u.uid = uid;
                    u.fname = query3.ToArray()[0].fname;
                    u.lname = query3.ToArray()[0].lname;
                    //u.department = query1.ToArray()[0].department;
                    return Json(u);
                }
            }
            return Json(new { success = false });
        }

        public class users
        {
            public string fname;
            public string lname;
            public string uid;
            public string department;
        }

        /*******End code to modify********/

    }

}