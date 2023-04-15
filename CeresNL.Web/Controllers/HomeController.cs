using CeresNL.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccessLayer;
using DataAccessLayer.ExtensionMethod;
using System.Data;
using Microsoft.Extensions.Configuration;
using CeresNL.Core.Repository;
using Newtonsoft.Json;

namespace CeresNL.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UsersRepository _usersRepo;

        public HomeController(ILogger<HomeController> logger,IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
            _usersRepo = new UsersRepository(config);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult test()
        {
            var list = _usersRepo.getUsersList();
            return Ok(JsonConvert.SerializeObject(list));
        }
    
    }
}