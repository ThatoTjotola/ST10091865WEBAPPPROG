using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using static ClassLibrary.CustomControl1;

namespace ST10091865WEBAPPPROG.Pages.Login
{
    public class loginModel : PageModel
    {
        //Declaration of Variables
        public String successMessage = "";
        public String error = "";
        public String AllFields = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //Sqlconnection to azure , firewall rules have been updated so it can run on any device or machine
            //https://learn.microsoft.com/en-us/sql/sql-server/install/configure-the-windows-firewall-to-allow-sql-server-access?view=sql-server-ver16
            //(Microsoft,2022).
           
            DataCalculations.passw = Request.Form["Password"];
           


            string pall = encryptPass(Request.Form["pass"]);
            SqlConnection con = new SqlConnection("Data Source=prog62121st10091865.database.windows.net;Initial Catalog=ProgrammingPart2;User ID=jimmy;Password=4731598819Amo");
            con.Open();

            //User validation
            //https://learn.microsoft.com/en-us/answers/questions/834155/how-to-validate-a-user-entered-sql-instance-name-e.html
            //(Microsoft,2022).

            string query = "SELECT * FROM USERS WHERE StudentNumber = '" + Request.Form["studentnr"] + "' and Passwords = '" + pall + "'";
            SqlDataAdapter tda = new SqlDataAdapter(query, con);
            DataTable dtb1 = new DataTable();
            tda.Fill(dtb1);


            DataCalculations.studentnrsample = Request.Form["studentnr"];

            //User authentication
           
             
            if (dtb1.Rows.Count == 1)
            {
                successMessage = "Login successful Welcome " + DataCalculations.studentnrsample;

                Response.Redirect("/StudentData/Index");


            }

            else 
            {
                error = " incorrect entry, try again";
            }
            
        }
        public static string encryptPass(string pall)
        {
            //PasswordEncryption
            //https://learn.microsoft.com/en-us/dotnet/standard/security/encrypting-data
            //(Microsoft,2022).
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(pall);
            byte[] hashed = System.Security.Cryptography.SHA256.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }
    }
}
