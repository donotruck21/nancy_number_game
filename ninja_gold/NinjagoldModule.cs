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
                if(Session["total_gold"] == null){
                    Session["total_gold"] = 0;
                }

                if(Session["activity"] == null){
                    Session["activity"] = "";
                }

                ViewBag.total_gold = Session["total_gold"];
                ViewBag.activity = Session["activity"];
                System.Console.WriteLine(Session["activity"]);
                return View["index"]; 
            });





            Post("/process", args => {
                System.Console.WriteLine("processing....");
                string building = Request.Form.building;

                if(building == "farm"){
                    System.Console.WriteLine("in farm");
                    int money = new Random().Next(10,21);
                    Session["total_gold"] = (int)Session["total_gold"] + money;
                    Session["activity"] = "Earned " + money + " gold at the farm!<br>" + Session["activity"];
                    System.Console.WriteLine(Session["activity"]);
                }
                if(building == "house"){
                    System.Console.WriteLine("in house");
                    int money = new Random().Next(5,11);
                    Session["total_gold"] = (int)Session["total_gold"] + money;
                    Session["activity"] = "Earned " + money + " gold at the house!<br>" + Session["activity"];
                }
                if(building == "cave"){
                    System.Console.WriteLine("in cave");
                    int money = new Random().Next(2,6);
                    Session["total_gold"] = (int)Session["total_gold"] + money;
                    Session["activity"] = "Found " + money + " gold in the cave!<br>" + Session["activity"];
                }
                if(building == "casino"){
                    System.Console.WriteLine("in casino");
                    int money = new Random().Next(-50,51);
                    Session["total_gold"] = (int)Session["total_gold"] + money;
                    Session["activity"] = "Made/Lost " + money + " gold at the casino!<br>" + Session["activity"];
                }

                return Response.AsRedirect("/"); 
            });
        }
    }
}
