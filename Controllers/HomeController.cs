using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Dynamic;
using Firebase.Auth;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Test.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FirestoreDb _fireStoreDB;
        private string projectId;
        string directory;
        string ApiKey = "AIzaSyChp0o1S3CGy07paJlAyrQTCHzObCL1I0Y";

        public HomeController(ILogger<HomeController> logger)
        {

            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyChp0o1S3CGy07paJlAyrQTCHzObCL1I0Y"));
            directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int index = directory.IndexOf("KursiyerimNET");
            string path = directory.Substring(0, index);
            path += "KursiyerimNET\\wwwroot\\kursiyernet-6699d-7e20cada15c4.json";

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            projectId = "kursiyernet-6699d";
            _fireStoreDB = FirestoreDb.Create(projectId);
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

          
            if (HttpContext.Session.IsAvailable && HttpContext.Session.GetString("token") != null)
            {


                var user = await auth.GetUserAsync(HttpContext.Session.GetString("token"));
              
                ViewBag.user = true;
            }


            Query trainerQuery = _fireStoreDB.Collection("trainees");
            QuerySnapshot trainerQuerySnapshot = await trainerQuery.GetSnapshotAsync();
            List<Trainer> trainerList = new List<Trainer>();

            foreach (DocumentSnapshot dSnapShot in trainerQuerySnapshot.Documents)
            {
                if (dSnapShot.Exists)
                {
                    Dictionary<string, object> trainers = dSnapShot.ToDictionary();
                    string json = JsonConvert.SerializeObject(trainers);
                    Trainer newtrainer = JsonConvert.DeserializeObject<Trainer>(json);
                    newtrainer.Id = dSnapShot.Id;
                    trainerList.Add(newtrainer);
                }
            }

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
                    Trainer courseTrainer = JsonConvert.DeserializeObject<Trainer>(json);

                    newCourse.trainer = courseTrainer;

                    courseList.Add(newCourse);
                }
            }
            dynamic Model = new ExpandoObject();
            Model.trainerList = trainerList;
            Model.courseList = courseList;
            return View(Model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}