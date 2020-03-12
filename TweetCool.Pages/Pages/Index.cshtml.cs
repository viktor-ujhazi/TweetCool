using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TweetCool.Pages.Models;
using TweetCool.Pages.Services;

namespace TweetCool.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileTweetService TweetService;
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        //public Tweet tweet;


        public IndexModel(ILogger<IndexModel> logger, JsonFileTweetService tweetService)
        {
            _logger = logger;
            TweetService = tweetService;

        }
        public void OnGet()
        {

        }
        public void OnPost(string poster,string Body)
        {
            _logger.LogInformation($"{poster} said:\n{Body}");
            TweetService.AddTweet(poster,Body);
            
            //tweet.AllTweets.Add($"{poster} said:\n{Body}");
            
        }
    }
}
