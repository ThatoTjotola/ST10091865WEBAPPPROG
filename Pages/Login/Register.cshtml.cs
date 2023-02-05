using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using static ClassLibrary.CustomControl1;

namespace ST10091865WEBAPPPROG.Pages.Login
{
    public class RegisterModel : PageModel
    {

        // Variables used too capture user errors and incorrect inputs
        //https://learn.microsoft.com/en-us/answers/questions/834155/how-to-validate-a-user-entered-sql-instance-name-e.html

        public String ErrorMessage = "";
        public String AllFieldsRequired = "";
        
        public void OnPost()
        {
           
        DataCalculations.username = Request.Form["studnum"];
            DataCalculations.Password = Request.Form["pass"];

            SqlConnection conA = new SqlConnection("Data Source=prog62121st10091865.database.windows.net;Initial Catalog=ProgrammingPart2;User ID=jimmy;Password=4731598819Amo");
            conA.Open();

            //Preventing duplicate users in Database

            string query2 = "SELECT * FROM USERS WHERE StudentNumber = '" + Request.Form["studnum"] + "' and Passwords = '" + encryptPass(Request.Form["pass"]) + "'";
            SqlDataAdapter tda2 = new SqlDataAdapter(query2, conA);
            DataTable dtb2 = new DataTable();
            tda2.Fill(dtb2);




            if (dtb2.Rows.Count == 1)
            {
                ErrorMessage = "User already exists";

              
            }
            if(DataCalculations.username.Length == 0 || DataCalculations.Password.Length ==0)
            {
                AllFieldsRequired = "All Fields are required";
            }
            else
            {
          
                Insertion();
              
                Response.Redirect("/Login/login");
               


            }
        


    }
        //Insertion method where data is inserted into the User Table in the azure database

        public static void Insertion()
        {
           

            SqlConnection con = new SqlConnection("Data Source=prog62121st10091865.database.windows.net;Initial Catalog=ProgrammingPart2;User ID=jimmy;Password=4731598819Amo");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO USERS VALUES(@StudentNumber,@Passwords)", con);
            cmd.Parameters.AddWithValue("@StudentNumber", DataCalculations.username);
            string pass = DataCalculations.Password;
            cmd.Parameters.AddWithValue("@Passwords", encryptPass(pass));


            cmd.ExecuteNonQuery();
            con.Close();

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
