using Nancy;
namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/", args => {
                Session["SomeName"] = "Some stuff!";
                ViewBag.hello = Session["SomeName"];
                return View["index"]; 
            });

            Get("/{name}", args => $"Hello {args.name}"); 
        }
    }
}
