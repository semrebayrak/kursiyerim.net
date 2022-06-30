
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Test.Models
{

    [FirestoreData]
    public class Category


    {
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string[] trainers { get; set; }
        [FirestoreProperty]
        public string[] courses { get; set; }
    }
}