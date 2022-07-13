using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers{

    public class HelloWorldController:Controller{

        //Get: /HelloWorld/

        //Index is the pre-defined method if the the method name is not specified
        public IActionResult Index(){
            //Default view is the same as the method, Index
            return View();
        }

        //Get: /HelloWorld/Welcome/

        public IActionResult Welcome(string name, int numTimes = 1){

            ViewData["Message"]= "Hello " + name;
            ViewData["NumTimes"]= numTimes;
            return View();
            
        }
    }
}