using Nancy;
using System;
namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        
        {
            Get("/", args => {
                System.Console.WriteLine("in root");
                if(Session["randNum"] == null){
                    Session["randNum"] = new Random().Next(1,101);
                }
                if(Session["str"] == null){
                    Session["str"] = ":]";
                }
                if(Session["color"] == null){
                    Session["color"] = "gray";
                }
                ViewBag.myStr = Session["str"];
                ViewBag.color = Session["color"];
                return View["index"]; 
            });

            Post("/guess", args => { 
                int user_guess = Request.Form.guess;
                if(user_guess == (int)(Session["randNum"])){
                    System.Console.WriteLine("GOT IT!!!!");
                    Session["str"] = "You got it!";
                    Session["color"] = "green";
                } else if (user_guess > (int)Session["randNum"]){
                    System.Console.WriteLine("GUESS TOO HIGH!");
                    Session["str"] = "Too high! Guess again!";
                    Session["color"] = "red";
                } else{
                    System.Console.WriteLine("GUESS TOO LOW!!");
                    Session["str"] = "Too Low! Guess again!";
                    Session["color"] = "red";
                }

                return Response.AsRedirect("/");
            }); 
        }
    }
}
