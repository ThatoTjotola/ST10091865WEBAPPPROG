using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ClassLibrary.CustomControl1;

namespace ST10091865WEBAPPPROG.Pages.StudentData
{
    public class CreateModel : PageModel
    {
        public String Allfield = "";
        public String Success = "";
       
        public void OnGet()
        {
           
        }
        public void OnPost()
        {

            //Covertion of form inputs too usable variables
            ///https://learn.microsoft.com/en-us/sql/sql-server/install/configure-the-windows-firewall-to-allow-sql-server-access?view=sql-server-ver16

            DataCalculations.ModuleName = Request.Form["name"];
            DataCalculations.ModuleCode = Request.Form["code"];
            DataCalculations.NumberOfCredits = Convert.ToDouble(Request.Form["credits"]);
            DataCalculations.ClassHoursPerWeek = Convert.ToDouble(Request.Form["hours"]);
            DataCalculations.NumberOfWeeks = Convert.ToDouble(Request.Form["weeks"]);
            DataCalculations.SpecificHours = Convert.ToDouble(Request.Form["specifichours"]);
            DataCalculations.n = Convert.ToString(Request.Form["date"]);
            DataCalculations.sample = Request.Form["specific date"];

            if (DataCalculations.ModuleName.Length == 0 || DataCalculations.ModuleCode.Length == 0 || DataCalculations.n.Length == 0 || DataCalculations.sample.Length == 0
             || DataCalculations.NumberOfCredits.ToString().Length == 0 || DataCalculations.ClassHoursPerWeek.ToString().Length == 0 || DataCalculations.NumberOfWeeks.ToString().Length == 0
             || DataCalculations.SpecificHours.ToString().Length == 0)
            {
                Allfield = "Please insert all required fields";
            }
            else
                //Necessary Methods for calculation 
                ///https://learn.microsoft.com/en-us/sql/sql-server/install/configure-the-windows-firewall-to-allow-sql-server-access?view=sql-server-ver16
            Calculations.SelfStudyCalculation();
            Calculations.RemainingSelfStudy();

            Calculations.Manipulation();

            Calculations.Persist();

            Success = "Module added successfully thank you , too view module and calculations click view data button";



        }
 
    }
    
}
