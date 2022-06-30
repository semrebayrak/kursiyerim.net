
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Test.Models
{


    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

}