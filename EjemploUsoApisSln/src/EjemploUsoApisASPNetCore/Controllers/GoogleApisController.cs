using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Discovery.v1;
using Google.Apis.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EjemploUsoApisASPNetCore.Controllers
{
    public class GoogleApisController : Controller
    {
        BaseClientService.Initializer _initializer;
        DiscoveryService _service;
        public GoogleApisController()
        {
            this._initializer =
            new BaseClientService.Initializer()
            {
                ApplicationName = "Ejemplo Uso APIs ASP Net Core",
                ApiKey = "AIzaSyChm0FekYCHKTPx2s0hNbe75MrIwhHEUHU"
            };
            this._service = new DiscoveryService(_initializer);
        }

        // GET: /<controller>/
        public async Task<IActionResult> List()
        {
            Google.Apis.Discovery.v1.Data.DirectoryList apisList = await this._service.Apis.List().ExecuteAsync();
            return View(apisList.Items);
        }

        public async Task<IActionResult> ListBloggerPosts()
        {
            Google.Apis.Blogger.v3.BloggerService bloggerService = new Google.Apis.Blogger.v3.BloggerService(this._initializer);
            Google.Apis.Blogger.v3.Data.PostList postList = await bloggerService.Posts.List("3364769811062992436").ExecuteAsync();
            return View(postList.Items);
        }
    }
}
