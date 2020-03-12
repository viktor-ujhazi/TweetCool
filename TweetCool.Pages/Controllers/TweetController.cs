using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweetCool.Pages.Models;
using TweetCool.Pages.Services;

namespace TweetCool.Pages.Controllers
{
    public class TweetController : Controller
    {
        public TweetController(JsonFileTweetService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileTweetService ProductService { get; }
        [HttpGet]
        public IEnumerable<Tweet> Get()
        {
            return ProductService.GetTweets();
        }
        //[HttpPost]
        
    }
}