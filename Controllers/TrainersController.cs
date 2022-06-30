using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Google.Cloud.Firestore;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Test.Controllers {

public class TrainersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private FirestoreDb _fireStoreDB;
    private string projectId;
    string directory;
    public TrainersController(ILogger<HomeController> logger)
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

    public async Task<IActionResult> Index(String category)

    {
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

                if (category != null && newtrainer.category == category)
                    trainerList.Add(newtrainer);
                else if (category == null)
                {
                    trainerList.Add(newtrainer);
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
        Model.trainerList = trainerList;
        return View(Model);

        return View(trainerList);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}