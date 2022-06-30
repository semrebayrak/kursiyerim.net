using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Google.Cloud.Firestore;
using System.Reflection;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Test.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FirestoreDb _fireStoreDB;
        private string projectId;
        string directory;
        string ApiKey = "AIzaSyChp0o1S3CGy07paJlAyrQTCHzObCL1I0Y";

        public UserController(ILogger<HomeController> logger)
        {

            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            int index = directory.IndexOf("KursiyerimNET");
            string path = directory.Substring(0, index);

            path += "KursiyerimNET\\wwwroot\\kursiyernet-6699d-7e20cada15c4.json";

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            projectId = "kursiyernet-6699d";
            _fireStoreDB = FirestoreDb.Create(projectId);
            _logger = logger;

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var ab = await auth.SignInWithEmailAndPasswordAsync(model.email, model.password);
                    string token = ab.FirebaseToken;
                    var user = ab.User;
                    if (token != "")
                    {

                        this.SignInUser(token);
                        return this.RedirectToLocal("localhost:7098");

                    }
                    else
                    {
                        // Setting.
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            return View(model);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginModel model)
        {


            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        private void SignInUser(string token)
        {

            try
            {

                HttpContext.Session.SetString("token", token);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}