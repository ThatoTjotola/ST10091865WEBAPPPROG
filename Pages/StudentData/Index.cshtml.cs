using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ClassLibrary.CustomControl1;
using System.Data.SqlClient;

namespace ST10091865WEBAPPPROG.Pages.StudentData
{
    
    public class IndexModel : PageModel
    {
        //Student info list created
        public List<StudentInfo> studlist = new List<StudentInfo>();

        public void OnGet()
        {
            //Sql connection too display data specific too the user

              SqlConnection con = new SqlConnection("Data Source=prog62121st10091865.database.windows.net;Initial Catalog=ProgrammingPart2;User ID=jimmy;Password=4731598819Amo");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserData WHERE studentnum = '" + DataCalculations.studentnrsample +"'", con);

                SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            StudentInfo info = new StudentInfo();

                             info.id = reader.GetInt32(0);
                            info.studentnumber= reader.GetString(1);
                           info.modulenam =reader.GetString(2);
                           info.modulecod = reader.GetString(3);
                           
                           info.actualselfstudytim = reader.GetString(4);
                            info.selfstudytim =reader.GetString(5);

                            studlist.Add(info);
                            
                        }
                    
                

           
        }
        
    }
}
