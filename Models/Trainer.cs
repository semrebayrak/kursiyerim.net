
using Google.Cloud.Firestore;

using System;
using System.Collections.Generic;

namespace Test.Models
{


    [FirestoreData]
    public class Trainer


    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string name { get; set; }
        [FirestoreProperty]
        public string photoLink { get; set; }
        [FirestoreProperty]
        public string category { get; set; }
        [FirestoreProperty]
        public List<String> courses { get; set; }
        [FirestoreProperty]
        public string profession { get; set; }
    }
}