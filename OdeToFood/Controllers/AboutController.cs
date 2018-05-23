using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "1231331313";
        }
        [Route("address")]
        public string Address()
        {
            return "England";
        }
    }
}
