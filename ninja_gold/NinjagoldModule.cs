using Nancy;
using System;
namespace HelloNancy
{
    public class NinjagoldModule : NancyModule
    {
        public NinjagoldModule()
        
        {
            Get("/", args => {
                System.Console.WriteLine("in root");
                
                return View["index"]; 
            });
        }
    }
}
