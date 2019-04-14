using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : CommonController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Class(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult Assignment(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }


        public IActionResult ClassListings(string subject, string num)
        {
            System.Diagnostics.Debug.WriteLine(subject + num);
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            return View();
        }


        /*******Begin code to modify********/

        /// <summary>
        /// Returns a JSON array of the classes the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester
        /// "year" - The year part of the semester
        /// "grade" - The grade earned in the class, or "--" if one hasn't been assigned
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            using (db)
            {
                var query =
                    from e in db.EnrollmentGrade
                    where e.UId == uid
                    join p in db.Classes on e.CId equals p.CId into join1
                    from j1 in join1.DefaultIfEmpty()
                    join c in db.Courses on j1.CatalogId equals c.CatalogId into join2
                    from j2 in join2.DefaultIfEmpty()
                    select new
                    {
                        subject = j2.Subject,
                        number = j2.Number,
                        name = j2.Name,
                        season = j1.Semester.Remove(j1.Semester.Count() - 4),
                        year = j1.Semester.Substring(j1.Semester.Count() - 4),
                        grade = e.Grade == null ? "--" : e.Grade
                    };
                //System.Diagnostics.Debug.WriteLine("-------------");
                //System.Diagnostics.Debug.WriteLine(Json(query.ToArray()));
                //System.Diagnostics.Debug.WriteLine("-------------");
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Returns a JSON array of all the assignments in the given class that the given student is enrolled in.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The category name that the assignment belongs to
        /// "due" - The due Date/Time
        /// "score" - The score earned by the student, or null if the student has not submitted to this assignment.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="uid"></param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInClass(string subject, int num, string season, int year, string uid)
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
                                    where uid == enroll.UId && enroll.CId == getCid.ToArray()[0].Cid
                                    select new
                                    {
                                        Cid = enroll.CId
                                    };


                var query = from cate in db.AssignmentCategories
                            where cate.CId == getStudentCid.ToArray()[0].Cid
                            join assign in db.Assignments
                            on cate.AcId equals assign.AcId

                            select new
                            {
                                aname = assign.Name,
                                cname = cate.Name,
                                due = assign.Due,

                                score = assign.Points
                            };

                return Json(query.ToArray());
            }
        }


        /// <summary>
        /// Adds a submission to the given assignment for the given student
        /// The submission should use the current time as its DateTime
        /// You can get the current time with DateTime.Now
        /// The score of the submission should start as 0 until a Professor grades it
        /// If a Student submits to an assignment again, it should replace the submission contents
        /// and the submission time (the score should remain the same).
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="uid">The student submitting the assignment</param>
        /// <param name="contents">The text contents of the student's submission</param>
        /// <returns>A JSON object containing {success = true/false}</returns>
        public IActionResult SubmitAssignmentText(string subject, int num, string season, int year,
          string category, string asgname, string uid, string contents)
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


                var studentsQuery = from stud in db.Students
                                    where stud.UId == uid
                                    select stud;

                var getSubmission = from submi in db.Submission
                                    where submi.UId == uid && submi.AId == getAid.ToArray()[0].Aid
                                    select submi;

                Submission sub = new Submission();
                sub.Time = DateTime.Now;

                sub.Contents = contents;
                sub.AId = getAid.ToArray()[0].Aid;
                sub.UId = uid;
                sub.Score = 0;

                //Submission the_as = getSubmission.SingleOrDefault();
                getSubmission.ToArray()[0].Contents = contents;
                getSubmission.ToArray()[0].Time = DateTime.Now;

                /*
                if(the_as != null)
                {
                    the_as = sub;
                }
                */

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return Json(new { success = false });
                }

                return Json(new { success = true });
            }

        }


            /// <summary>
            /// Enrolls a student in a class.
            /// </summary>
            /// <param name="subject">The department subject abbreviation</param>
            /// <param name="num">The course number</param>
            /// <param name="season">The season part of the semester</param>
            /// <param name="year">The year part of the semester</param>
            /// <param name="uid">The uid of the student</param>
            /// <returns>A JSON object containing {success = {true/false}. 
            /// false if the student is already enrolled in the class, true otherwise.</returns>
            public IActionResult Enroll(string subject, int num, string season, int year, string uid)
        {
            using (db)
            {
                EnrollmentGrade en = new EnrollmentGrade();
                en.UId = uid;
                en.Grade = null;

                var query =
                    from p in db.Courses
                    where p.Subject == subject && p.Number == num.ToString()
                    join c in db.Classes on p.CatalogId equals c.CatalogId
                    where c.Semester == (season + year.ToString())
                    select c.CId;

                System.Diagnostics.Debug.WriteLine("-------------");
                System.Diagnostics.Debug.WriteLine(query.ToArray().Count());
                System.Diagnostics.Debug.WriteLine("-------------");
                if (query.ToArray().Count() != 0)
                {

                    en.CId = query.ToArray()[0];
                    System.Diagnostics.Debug.WriteLine("-------------");
                    System.Diagnostics.Debug.WriteLine(en.CId);
                    System.Diagnostics.Debug.WriteLine("-------------");
                    db.Add(en);
                    try
                    {
                        db.SaveChanges();
                        return Json(new { success = true });
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        return Json(new { success = false });
                    }
                }

            }
            return Json(new { success = false });
        }



        /// <summary>
        /// Calculates a student's GPA
        /// A student's GPA is determined by the grade-point representation of the average grade in all their classes.
        /// Assume all classes are 4 credit hours.
        /// If a student does not have a grade in a class ("--"), that class is not counted in the average.
        /// If a student is not enrolled in any classes, they have a GPA of 0.0.
        /// Otherwise, the point-value of a letter grade is determined by the table on this page:
        /// https://advising.utah.edu/academic-standards/gpa-calculator-new.php
        /// </summary>
        /// <param name="uid">The uid of the student</param>
        /// <returns>A JSON object containing a single field called "gpa" with the number value</returns>
        public IActionResult GetGPA(string uid)
        {
            using (db)
            {
                var query =
                    from p in db.EnrollmentGrade.DefaultIfEmpty()
                    where p.UId == uid
                    select p.Grade == null ? "--" : p.Grade;

                double gpa = 0;
                int enrolled = query.ToArray().Count();
                foreach (String letter in query.ToArray())
                {
                    switch (letter)
                    {
                        case "A": gpa += 4; break;
                        case "A-": gpa += 3.7; break;
                        case "B+": gpa += 3.3; break;
                        case "B": gpa += 3; break;
                        case "B-": gpa += 2.7; break;
                        case "C+": gpa += 2.3; break;
                        case "C": gpa += 2; break;
                        case "C-": gpa += 1.7; break;
                        case "D+": gpa += 1.3; break;
                        case "D": gpa += 1; break;
                        case "D-": gpa += 0.7; break;
                        case "--": enrolled--; break;
                    }
                }
                if (enrolled != 0)
                {
                    gpa /= enrolled;
                }

                return Json(new { gpa = gpa });
            }


        }

        /*******End code to modify********/

    }
}