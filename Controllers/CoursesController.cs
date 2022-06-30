using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Dynamic;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Test.Controllers
{

    public class CoursesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FirestoreDb _fireStoreDB;
        private string projectId;
        string directory;
        public CoursesController(ILogger<HomeController> logger)
        {
            directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int index = directory.IndexOf("KursiyerimNET");
            string path = directory.Substring(0, index);

            path += "KursiyerimNET\\wwwroot\\kursiyernet-6699d-7e20cada15c4.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            projectId = "kursiyernet-6699d";
            _fireStoreDB = FirestoreDb.Create(projectId);
            _logger = logger;
        }

        public async Task<IActionResult> Index(String category, String trainerId)
        {
            System.Console.WriteLine(category);
            Query courseQuery = _fireStoreDB.Collection("courses");
            QuerySnapshot courseQuerySnapshot = await courseQuery.GetSnapshotAsync();
            List<Course> courseList = new List<Course>();

            foreach (DocumentSnapshot dSnapShot in courseQuerySnapshot.Documents)
            {
                if (dSnapShot.Exists)
                {
                    Dictionary<string, object> courses = dSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(courses);
                    Course newCourse = JsonConvert.DeserializeObject<Course>(json);

                    DocumentSnapshot trainerDocument = await _fireStoreDB.Collection("trainees").Document(newCourse.trainerId).GetSnapshotAsync();

                    Dictionary<string, object> trainer = trainerDocument.ToDictionary();
                    json = JsonConvert.SerializeObject(trainer);
                    Trainer coursetrainer = JsonConvert.DeserializeObject<Trainer>(json);

                    newCourse.trainer = coursetrainer;

                    if (trainerId == null)
                    {
                        if (category != null && newCourse.category == category)
                            courseList.Add(newCourse);
                        else if (category == null)
                        {
                            courseList.Add(newCourse);
                        }
                    }
                    else
                    {
                        if (newCourse.trainerId == trainerId)
                        {
                            courseList.Add(newCourse);
                        }
                    }
                }
            }

            Query categoriesQeury = _fireStoreDB.Collection("categories");
            QuerySnapshot categoriesQeurySnapshot = await categoriesQeury.GetSnapshotAsync();
            List<Category> categoryList = new List<Category>();

            foreach (DocumentSnapshot dSnapShot in categoriesQeurySnapshot.Documents)
            {
                if (dSnapShot.Exists)
                {
                    Dictionary<string, object> categories = dSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(categories);
                    Category newCategory = JsonConvert.DeserializeObject<Category>(json);


                    categoryList.Add(newCategory);
                }
            }
            dynamic Model = new ExpandoObject();
            Model.categoryList = categoryList;
            Model.courseList = courseList;
            return View(Model);
        }

        public async Task<IActionResult> Course(String courseName)
        {
            System.Console.WriteLine(courseName);
            DocumentSnapshot courseDocument = await _fireStoreDB.Collection("courses").Document(courseName).GetSnapshotAsync();

            Dictionary<string, object> course = courseDocument.ToDictionary();
            string json = JsonConvert.SerializeObject(course);

            Course newCourse = JsonConvert.DeserializeObject<Course>(json);



            DocumentSnapshot trainerDocument = await _fireStoreDB.Collection("trainees").Document(newCourse.trainerId).GetSnapshotAsync();

            Dictionary<string, object> trainer = trainerDocument.ToDictionary();
            json = JsonConvert.SerializeObject(trainer);
            Trainer courseTrainer = JsonConvert.DeserializeObject<Trainer>(json);

            dynamic Model = new ExpandoObject();
            Model.course = newCourse;
            Model.trainer = courseTrainer;
            return View(Model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }

}