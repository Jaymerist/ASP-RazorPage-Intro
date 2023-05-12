using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CPSC1517_Ex03_MihiriKamiss.Models;
using System.Text.Json;
using System.IO;


namespace CPSC1517_Ex03_MihiriKamiss.Pages.Samples
{
    public class RoyalFamilyListModel : PageModel
    {
        private IWebHostEnvironment _env;
        public RoyalFamilyListModel(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string fileName = "RoyalFamily.json";

        public RoyalList royalPerson { get; set; }

        public void OnGet()
        {
            string contentPathName = _env.ContentRootPath; //the phyiscal path
            string filePathName = Path.Combine(contentPathName, @"Data\" + fileName);
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    IncludeFields = true
                };
                string jsonstring = System.IO.File.ReadAllText(filePathName);
                royalPerson = JsonSerializer.Deserialize<RoyalList>(jsonstring, options);

            
        }
    }
}
