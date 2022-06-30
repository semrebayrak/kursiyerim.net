
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Test.Models
{

    [FirestoreData]
    public class Course


    {
        public string name { get; set; }
        [FirestoreProperty]
        public string category { get; set; }
        [FirestoreProperty]
        public string description { get; set; }
        [FirestoreProperty]
        public List<String> coverPhoto { get; set; }
        [FirestoreProperty]
        public string trainerId { get; set; }
        [FirestoreProperty]
        public double price { get; set; }
        [FirestoreProperty]
        public string link { get; set; }

        public Trainer trainer { get; set; }


    }
}