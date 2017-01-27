using Nancy;
namespace HelloNancy
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/", args => {
                return View["Hello"];
            });
            Get("/{name}", args => $"Hello {args.name}");
        }
    }
}
