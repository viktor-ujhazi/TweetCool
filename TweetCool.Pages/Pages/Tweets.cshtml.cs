using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TweetCool.Pages.Models;
using TweetCool.Pages.Services;

namespace TweetCool.Pages
{
    public class TweetsModel : PageModel
    {
        public JsonFileTweetService TweetService;
        public IEnumerable<Tweet> AllTweets { get; private set; }
        public TweetsModel(JsonFileTweetService tweetService)
        {
            TweetService = tweetService;
        }
        public void OnGet()
        {
            AllTweets = TweetService.GetTweets();
        }
    }
}