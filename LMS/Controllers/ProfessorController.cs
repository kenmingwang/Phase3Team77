using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Models.LMSModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Professor")]
    public class ProfessorController : CommonController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
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

        public IActionResult Categories(string subject, string num, string season, string year)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            return View();
        }

        public IActionResult CatAssignments(string subject, string num, string season, string year, string cat)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
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

        public IActionResult Submissions(string subject, string num, string season, string year, string cat, string aname)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            return View();
        }

        public IActionResult Grade(string subject, string num, string season, string year, string cat, string aname, string uid)
        {
            ViewData["subject"] = subject;
            ViewData["num"] = num;
            ViewData["season"] = season;
            ViewData["year"] = year;
            ViewData["cat"] = cat;
            ViewData["aname"] = aname;
            ViewData["uid"] = uid;
            return View();
        }

        /*******Begin code to modify********/


        /// <summary>
        /// Returns a JSON array of all the students in a class.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "dob" - date of birth
        /// "grade" - the student's grade in this class
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetStudentsInClass(string subject, int num, string season, int year)
        {

            using (db)
            {
                var query = from course in db.Courses
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
                var query2 = from enroll in db.EnrollmentGrade.DefaultIfEmpty()
                             where enroll.CId == query.ToArray()[0].Cid
                             join s in db.Students
                             on enroll.UId equals s.UId
                             into enrollStudent

                             from es in enrollStudent
                             join u in db.Users
                             on es.UId equals u.UId
                             into Users

                             from us in Users
                             select new
                             {
                                 fname = us.FName,
                                 lname = us.LName,
                                 uid = us.UId,
                                 dob = us.Dob,
                                 grade = enroll.Grade == null ? "--" : enroll.Grade
                             };

                return Json(query2.ToArray());
            }
        }



        /// <summary>
        /// Returns a JSON array with all the assignments in an assignment category for a class.
        /// If the "category" parameter is null, return all assignments in the class.
        /// Each object in the array should have the following fields:
        /// "aname" - The assignment name
        /// "cname" - The assignment category name.
        /// "due" - The due DateTime
        /// "submissions" - The number of submissions to the assignment
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class, 
        /// or null to return assignments from all categories</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentsInCategory(string subject, int num, string season, int year, string category)
        {
            using (db)
            {
                if (category == null)
                {
                    var query =
                    from p in db.Courses
                    where p.Subject == subject && p.Number == num.ToString()
                    join c in db.Classes on p.CatalogId equals c.CatalogId
                    where c.Semester == (season + year.ToString())
                    join e in db.AssignmentCategories on c.CId equals e.CId
                    join a in db.Assignments on e.AcId equals a.AcId
                   select new
                   {
                       aname = a.Name,
                       cname = e.Name,
                       due = a.Due,
                       submissions = (from t in a.Submission select t.Score),
                   };


                    getAssgn[] arr = new getAssgn[query.ToArray().Count()];
                    if (query.ToArray().Count() != 0)
                    {
                        for (int i = 0; i < query.ToArray().Count(); i++)
                        {
                            int submissions = 0;
                            if (query.ToArray()[i].submissions.Count() == 0)
                            {
                                getAssgn tmp = new getAssgn();
                                tmp.aname = query.ToArray()[i].aname;
                                tmp.cname = query.ToArray()[i].cname;
                                tmp.due = query.ToArray()[i].due;
                                tmp.submissions = 0;
                                arr[i] = tmp;
                            }
                            else
                            {
                                foreach (int score in query.ToArray()[i].submissions)
                                {
                                    if (score != -1)
                                    {
                                        submissions++;
                                    }
                                    getAssgn tmp = new getAssgn();
                                    tmp.aname = query.ToArray()[i].aname;
                                    tmp.cname = query.ToArray()[i].cname;
                                    tmp.due = query.ToArray()[i].due;
                                    tmp.submissions = submissions;
                                    arr[i] = tmp;
                                }
                            }
                        }

                        return Json(arr);

                    }
                    else
                    {
                        return Json(query.ToArray());
                    }
                                    
                }
                else
                {
                    var query =
                    from p in db.Courses
                    where p.Subject == subject && p.Number == num.ToString()
                    join c in db.Classes on p.CatalogId equals c.CatalogId
                    where c.Semester == (season + year.ToString())
                    join e in db.AssignmentCategories on c.CId equals e.CId
                    where e.Name == category
                    join a in db.Assignments on e.AcId equals a.AcId
                    select new
                    {
                        aname = a.Name,
                        cname = e.Name,
                        due = a.Due,
                        submissions = (from t in a.Submission select t.Score),
                    };
 
                    getAssgn[] arr = new getAssgn[query.ToArray().Count()];
                    if (query.ToArray().Count() != 0)
                    {
                        for(int i = 0; i< query.ToArray().Count(); i++)
                        {
                            int submissions = 0;
                            if(query.ToArray()[i].submissions.Count() == 0)
                            {
                                getAssgn tmp = new getAssgn();
                                tmp.aname = query.ToArray()[i].aname;
                                tmp.cname = query.ToArray()[i].cname;
                                tmp.due = query.ToArray()[i].due;
                                tmp.submissions = 0;
                                arr[i] = tmp;
                            }
                            else
                            {
                                foreach (int score in query.ToArray()[i].submissions)
                                {
                                    if (score != -1)
                                    {
                                        submissions++;
                                    }
                                    getAssgn tmp = new getAssgn();
                                    tmp.aname = query.ToArray()[i].aname;
                                    tmp.cname = query.ToArray()[i].cname;
                                    tmp.due = query.ToArray()[i].due;
                                    tmp.submissions = submissions;
                                    arr[i] = tmp;
                                }
                            }
                           
                        }

                        return Json(arr);
                        
                    }
                    else
                    {
                        return Json(query.ToArray());
                    }
                }
            }

        }


        /// <summary>
        /// Returns a JSON array of the assignment categories for a certain class.
        /// Each object in the array should have the folling fields:
        /// "name" - The category name
        /// "weight" - The category weight
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetAssignmentCategories(string subject, int num, string season, int year)
        {

            using (db)
            {
                var query =
                    from p in db.Courses
                    where p.Subject == subject && p.Number == num.ToString()
                    join c in db.Classes on p.CatalogId equals c.CatalogId
                    where c.Semester == (season + year.ToString())
                    join e in db.AssignmentCategories on c.CId equals e.CId

                    select new
                    {
                        name = e.Name,
                        weight = e.Weight
                    };
                return Json(query.ToArray());
            }
        }

        /// <summary>
        /// Creates a new assignment category for the specified class.
        /// If a category of the given class with the given name already exists, return success = false.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The new category name</param>
        /// <param name="catweight">The new category weight</param>
        /// <returns>A JSON object containing {success = true/false} </returns>
        public IActionResult CreateAssignmentCategory(string subject, int num, string season, int year, string category, int catweight)
        {
            using (db)
            {
                int acid = 1;
                int cID = 0;
                AssignmentCategories asc = new AssignmentCategories();

                var query =
                    (from p in db.AssignmentCategories
                     orderby p.AcId descending
                     select p.AcId).Take(1);
                if (query.ToArray().Count() != 0)
                {
                    acid = query.ToArray()[0] + 1;
                }
                var query2 =
                    from c in db.Courses
                    where c.Subject == subject && c.Number == num.ToString()
                    join c2 in db.Classes on c.CatalogId equals c2.CatalogId
                    where c2.Semester == (season + year.ToString())
                    select c2.CId;
                if (query2.ToArray().Count() != 0)
                {
                    cID = query2.ToArray()[0];
                }
                asc.AcId = acid;
                asc.CId = cID;
                var query3 =
                    from p in db.AssignmentCategories
                    where p.CId == cID
                    select p.Name;

                foreach (String n in query3.ToArray())
                {
                    if (n == category)
                    {
                        System.Diagnostics.Debug.WriteLine("----------");
                        System.Diagnostics.Debug.WriteLine(n);
                        System.Diagnostics.Debug.WriteLine("----------");
                        return Json(new { success = false });
                    }
                        
                }

                asc.Name = category;
                asc.Weight = Convert.ToSByte(catweight);
                try
                {
                    db.Add(asc);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("----------");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine("----------");
                    return Json(new { success = false });
                }
            }

        }

        /// <summary>
        /// Creates a new assignment for the given class and category.
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The new assignment name</param>
        /// <param name="asgpoints">The max point value for the new assignment</param>
        /// <param name="asgdue">The due DateTime for the new assignment</param>
        /// <param name="asgcontents">The contents of the new assignment</param>
        /// <returns>A JSON object containing success = true/false</returns>
        public IActionResult CreateAssignment(string subject, int num, string season, int year, string category, string asgname, int asgpoints, DateTime asgdue, string asgcontents)
        {
            using (db)
            {
                int acid = 0;
                int aid = 1;
                int cid = 0;
                /* Get assignment category ID*/
                var query =
                  from c in db.Courses
                  where c.Subject == subject && c.Number == num.ToString()
                  join c2 in db.Classes on c.CatalogId equals c2.CatalogId
                  where c2.Semester == (season + year.ToString())
                  join c3 in db.AssignmentCategories on c2.CId equals c3.CId
                  where c3.Name == category
                  select new
                  {
                      c3.AcId,
                      c2.CId
                  };


                if (query.ToArray().Count() != 0)
                {
                    acid = query.ToArray()[0].AcId;
                    cid = query.ToArray()[0].CId;
                }


                Assignments assg = new Assignments();

                var query2 =
                    (from a in db.Assignments
                     orderby a.AId descending
                     select a.AId).Take(1);
                if (query2.ToArray().Count() != 0)
                {
                    aid = query2.ToArray()[0] + 1;
                }
                assg.AId = aid;
                assg.AcId = acid;
                assg.Name = asgname;
                assg.Points = asgpoints;
                assg.Contents = asgcontents;
                assg.Due = asgdue;

                try
                {
                    /*
                    System.Diagnostics.Debug.WriteLine("----------");
                    System.Diagnostics.Debug.WriteLine(assg.AId);
                    System.Diagnostics.Debug.WriteLine(assg.AcId);
                    System.Diagnostics.Debug.WriteLine(assg.Name);
                    System.Diagnostics.Debug.WriteLine(assg.Points);
                    System.Diagnostics.Debug.WriteLine(assg.Contents);
                    System.Diagnostics.Debug.WriteLine(assg.Due);
                    System.Diagnostics.Debug.WriteLine("----------");
                    */
                    db.Add(assg);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("----------");
                    System.Diagnostics.Debug.WriteLine(e.Message);
                    System.Diagnostics.Debug.WriteLine("----------");
                    return Json(new { success = false });
                }

                /* Every UID in a specific cid class */
                var query3 =
                    from c in db.Courses
                    where c.Subject == subject && c.Number == num.ToString()
                    join c2 in db.Classes on c.CatalogId equals c2.CatalogId
                    where c2.Semester == (season + year.ToString())
                    join en in db.EnrollmentGrade on c2.CId equals en.CId
                    select en.UId;


                foreach (String uid in query3.ToArray())
                {
                    Submission sb = new Submission();
                    sb.AId = aid;
                    sb.Contents = "";
                    sb.UId = uid;
                    sb.Time = DateTime.Now;
                    sb.Score = -1; //Default submission, not counted as a REAL submission
                    db.Add(sb);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("----------");
                        System.Diagnostics.Debug.WriteLine("2:" + e.Message);
                        System.Diagnostics.Debug.WriteLine("----------");
                        return Json(new { success = false });
                    }

                }
                GradeUpdateClass(cid);
                return Json(new { success = true });

            }
        }


        /// <summary>
        /// Gets a JSON array of all the submissions to a certain assignment.
        /// Each object in the array should have the following fields:
        /// "fname" - first name
        /// "lname" - last name
        /// "uid" - user ID
        /// "time" - DateTime of the submission
        /// "score" - The score given to the submission
        /// 
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetSubmissionsToAssignment(string subject, int num, string season, int year, string category, string asgname)
        {

            using (db)
            {
                var query = from course in db.Courses
                            where course.Subject == subject && Int32.Parse(course.Number) == num
                            join cla in db.Classes
                            on course.CatalogId equals cla.CatalogId
                            where season == cla.Semester.Remove(cla.Semester.Count() - 4) && year == Int32.Parse(cla.Semester.Substring(cla.Semester.Count() - 4))

                            join ac in db.AssignmentCategories
                            on cla.CId equals ac.CId
                            where ac.Name == category

                            join a in db.Assignments
                            on ac.AcId equals a.AcId
                            where a.Name == asgname

                            join sub in db.Submission
                            on a.AId equals sub.AId
                            where sub.Score != -1

                            join u in db.Users
                            on sub.UId equals u.UId
                            select new
                            {
                                fname = u.FName,
                                lname = u.LName,
                                uid = u.UId,
                                time = sub.Time,
                                score = sub.Score

                            };

                return Json(query.ToArray());
            }
        }


        /// <summary>
        /// Set the score of an assignment submission
        /// </summary>
        /// <param name="subject">The course subject abbreviation</param>
        /// <param name="num">The course number</param>
        /// <param name="season">The season part of the semester for the class the assignment belongs to</param>
        /// <param name="year">The year part of the semester for the class the assignment belongs to</param>
        /// <param name="category">The name of the assignment category in the class</param>
        /// <param name="asgname">The name of the assignment</param>
        /// <param name="uid">The uid of the student who's submission is being graded</param>
        /// <param name="score">The new score for the submission</param>
        /// <returns>A JSON object containing success = true/false</returns>
        public IActionResult GradeSubmission(string subject, int num, string season, int year, string category, string asgname, string uid, int score)
        {
            using (db)
            {
                var query2 =
                    from c in db.Courses
                    where c.Number == num.ToString() && c.Subject == subject
                    join c2 in db.Classes on c.CatalogId equals c2.CatalogId
                    select c2.CId;

                var query =
                    from c in db.Courses
                    where c.Number == num.ToString() && c.Subject == subject
                    join c2 in db.Classes on c.CatalogId equals c2.CatalogId
                    join asc in db.AssignmentCategories on c2.CId equals asc.CId
                    join ass in db.Assignments on asc.AcId equals ass.AcId
                    where ass.Name == asgname
                    join Submission in db.Submission on ass.AId equals Submission.AId
                    where Submission.UId == uid
                    select Submission;

        
                if (query.ToArray().Count() != 0)
                {
                    query.ToArray()[0].Score = score;
                    try
                    {
                        db.SaveChanges();
                        GradeUpdateClass(query2.ToArray()[0]);
                        return Json(new { success = true });
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("----------");
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        System.Diagnostics.Debug.WriteLine("----------");
                    }
                    
                }
                
            }
           
            return Json(new { success = false });
        }


        /// <summary>
        /// Returns a JSON array of the classes taught by the specified professor
        /// Each object in the array should have the following fields:
        /// "subject" - The subject abbreviation of the class (such as "CS")
        /// "number" - The course number (such as 5530)
        /// "name" - The course name
        /// "season" - The season part of the semester in which the class is taught
        /// "year" - The year part of the semester in which the class is taught
        /// </summary>
        /// <param name="uid">The professor's uid</param>
        /// <returns>The JSON array</returns>
        public IActionResult GetMyClasses(string uid)
        {
            using (db)
            {
                var query = from cla in db.Classes
                            where cla.UId == uid
                            join course in db.Courses
                            on cla.CatalogId equals course.CatalogId
                            select new
                            {
                                subject = course.Subject,
                                number = course.Number,
                                name = course.Name,
                                season = cla.Semester.Remove(cla.Semester.Count() - 4),
                                year = cla.Semester.Substring(cla.Semester.Count() - 4)
                            };
                return Json(query.ToArray());
            }
        }


        private void GradeUpdateClass(int cid)
        {
            int allCatWeight = 0;
            Dictionary<String, double[]> studentRecord = new Dictionary<string, double[]>();
            using (db)
            {
                /* Get all the assigment cat in a class */
                var AssCat =
                    from p in db.AssignmentCategories
                    where p.CId == cid
                    select new
                    {
                        p.AcId,
                        p.Weight
                    };
                if (AssCat.ToArray().Count() == 0)
                {
                    return;
                }
                else
                {
                    /* Iterate over every catorgy */
                    foreach (var cat in AssCat.ToArray())
                    {

                        int acid = cat.AcId;
                        int catWeight = cat.Weight;
                        allCatWeight += catWeight;

                        /* Get the assignment in each cat */
                        var Assgnm =
                            from p in db.Assignments
                            where p.AcId == acid
                            join s in db.Submission on p.AId equals s.AId
                            select new
                            {
                                p.Points,
                                s.Score,
                                s.UId
                            };
                        if (Assgnm.ToArray().Count() == 0) continue; //DO NOT COUNT if no Assignments

                        /* Iterate every submission and put it into studentRecord */
                        foreach (var student in Assgnm.ToArray())
                        {
                            double catTotal = 0;
                            double catEarned = 0;
                            int score = student.Score ?? default(int);

                            if (!studentRecord.ContainsKey(student.UId))
                            {
                                studentRecord.Add(student.UId, new double[3]); //int[0] = earned, int[1] = total, int[2] =the Total of earned/total * Weight;
                            }
                            
                            catTotal += student.Points;
                            catEarned += score == -1 ? 0 : score; //no submission
                            catTotal += studentRecord[student.UId][1];
                            catEarned += studentRecord[student.UId][0];

                            //Update value
                            studentRecord[student.UId][0] = catEarned;
                            studentRecord[student.UId][1] = catTotal;
                        }
                        /* update total percentage grade without scaling in class */
                        foreach (var uid in studentRecord.Keys)
                        {
                            studentRecord[uid][2] += ((studentRecord[uid][0] / studentRecord[uid][1]) * catWeight);
                            System.Diagnostics.Debug.WriteLine("----------");
                            System.Diagnostics.Debug.WriteLine(uid + ": "  + cat.AcId + " : "+ studentRecord[uid][2]);
                            System.Diagnostics.Debug.WriteLine("earned: " + studentRecord[uid][0]);
                            System.Diagnostics.Debug.WriteLine("total: " + studentRecord[uid][1]);
                            System.Diagnostics.Debug.WriteLine("----------");
                            studentRecord[uid][0] = studentRecord[uid][1] = 0;
                        }
                    }
                    /* update total percentage grade with scaling in class 
                       and Convert percentage grade to letter grade and put in db */
                    foreach (var uid in studentRecord.Keys)
                    {
                        studentRecord[uid][2] = studentRecord[uid][2] * (100 / allCatWeight);
                        var getGrade =
                            from g in db.EnrollmentGrade
                            where g.UId == uid && g.CId == cid
                            select g;

                        getGrade.ToArray()[0].Grade = ConvertToLetter(studentRecord[uid][2]);
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("----------");
                            System.Diagnostics.Debug.WriteLine(e.Message);
                            System.Diagnostics.Debug.WriteLine("----------");
                        }
                    }                   
                }
            }

        }

        private string ConvertToLetter(double v)
        {
            System.Diagnostics.Debug.WriteLine("----------");
            System.Diagnostics.Debug.WriteLine(v);
            System.Diagnostics.Debug.WriteLine("----------");
            if (93 <= v && v <= 100)
            {
                return "A";
            }
            else if (90 <= v && v < 93)
            {
                return "A-";
            }
            else if (87 <= v && v < 90)
            {
                return "B+";
            }
            else if (83 <= v && v < 87)
            {
                return "B";
            }
            else if (80 <= v && v < 83)
            {
                return "B-";
            }
            else if (77 <= v && v < 80)
            {
                return "C+";
            }
            else if (73 <= v && v < 77)
            {
                return "C";
            }
            else if (70 <= v && v < 73)
            {
                return "C-";
            }
            else if (67 <= v && v < 70)
            {
                return "D+";
            }
            else if (63 <= v && v < 67)
            {
                return "D";
            }
            else if (60 <= v && v < 63)
            {
                return "D-";
            }
            else
            {
                return "E";
            }
        }

        public class getAssgn
        {
            public string aname;
            public string cname;
            public DateTime due;
            public int submissions;
        }

        /*******End code to modify********/

    }
}