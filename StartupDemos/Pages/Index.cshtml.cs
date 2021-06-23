using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupDemos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Activity { get; private set; }
        public string Type { get; private set; }
        public string Key { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;

            Activity = config["EXTERNAL_STARTUP_ACTIVITY"];
            Type = config["EXTERNAL_STARTUP_TYPE"];
            Key = config["EXTERNAL_STARTUP_KEY"];
        }

        public void OnGet()
        {

        }
    }
}
