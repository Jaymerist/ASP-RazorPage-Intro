using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CPSC1517_Ex03_MihiriKamiss.Models;

namespace CPSC1517_Ex03_MihiriKamiss.Pages.Samples
{
    public class PersonInfoModel : PageModel
    {
        public string FeedBack { get; set; }
        [BindProperty]
        public Person person { get; set; }
        [BindProperty]
        public DateTime OnDate { get; set; }
        public void OnGet()
        { }
        public void OnPostCurrentAge()
        {
            try
            {
                FeedBack = $"{person.Name} is currently {person.CurrentAge} years old and born on {person.DateOfBirth.ToString("dd/MM/yyyy")}.";
            }
            catch (ArgumentException ex)
            {
                FeedBack += ex.Message;
            }
        }

        public void OnPostAgeOn()
        {
            try
            {
                int ageOn = person.AgeOn(OnDate);

                FeedBack = $"{person.Name} born on {person.DateOfBirth.ToString("dd/MM/yyyy")} will be {ageOn} years old on {OnDate.ToString("dd/MM/yyyy")}.";
            }
            catch (ArgumentException ex)
            {
                FeedBack += ex.Message;
            }
        }

        public IActionResult OnPostClear()
        {
            return RedirectToPage();
        }
        
    }
}
