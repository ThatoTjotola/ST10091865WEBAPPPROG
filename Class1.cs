using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class CustomControl1 
    {
        

        //ArrayList Declaration
        //https://stackoverflow.com/questions/65837593/array-which-stores-information-from-user-input 
        //(stackoverflow,2022).
        public static ArrayList myList = new ArrayList();


        public static class DataCalculations
        {


            //Variable Declaration 
            //https://www.w3schools.com/cs/cs_user_input.php 
            //(w3schools,2022).
            public static string ModuleCode, ModuleName, n, b, sample, studnum,username,Password,studentnrsample, usname,passw;
            public static double NumberOfCredits, ClassHoursPerWeek, SelfStudyTime, NumberOfWeeks, num, sum, SpecificHours, ActualSelfStudy;



            //Getters and setters
            public static string Getpassw()
            {
                return passw;
            }
            public static void Setpassw(string Passw)
            {
                passw = Passw;
            }

            public static string Getstudentnrsample()
            {
                return studentnrsample;
            }
            public static void Setstudentnrsample(string Studentnrsample)
            {
                studentnrsample = Studentnrsample;
            }
            public static string Getusername()
            {
                return username;
            }
            public static void Setusername(string Username)
            {
                Username = username;
            }

            public static string GetPassword()
            {
                return Password;
            }
            public static void SetPassword(string password)
            {
                password = Password;
            }
            public static string GetStudNum()
            {
                return studnum;
            }
            public static void SetStudNum(string Studnum)
            {
                Studnum = studnum;
            }
            public static string GetSample()
            {
                return sample;
            }
            public static void SetSample(string Sample)
            {
                Sample = sample;
            }
            public static double Getactualselfstudy()
            {
                return ActualSelfStudy;
            }
            public static void Setactualselfstudy(double actualselfstudy)
            {
                ActualSelfStudy = actualselfstudy;
            }
            public static string GetB()
            {
                return b;
            }
            public static void SetB(string B)
            {
                b = B;
            }
            public static double Getspecifichours()
            {
                return SpecificHours;
            }
            public static void Setspecifichours(double Hours)
            {
                SpecificHours = Hours;
            }
            public static string Getn()
            {
                return n;
            }
            public static void Setn(string N)
            {
                N = n;
            }

            public static string Getmodulename()
            {
                return ModuleName;
            }
            public static void Setmodulename(string modulename)
            {
                ModuleName = modulename;
            }
            public static string Getmodulecode()
            {
                return ModuleCode;
            }

            public static void Setmodulecode(string modulecode)
            {
                ModuleCode = modulecode;
            }
            public static double Getnumberofcredits()
            {
                return NumberOfCredits;
            }
            public static void Setnumberofcredits(double credits)
            {
                NumberOfCredits = credits;
            }
            public static double Getclasshours()
            {
                return ClassHoursPerWeek;
            }
            public static void Setclasshours(double classhours)
            {
                ClassHoursPerWeek = classhours;
            }
            public static double Getnumberofweeks()
            {
                return NumberOfWeeks;
            }
            public static void Setnumberofweeks(double weeks)
            {
                NumberOfWeeks = weeks;
            }
            public static double Getselfstudytime()
            {
                return SelfStudyTime;
            }
            public static void Setselfstudy(double selfstudy)
            {
                SelfStudyTime = selfstudy;
            }
            public static double Getsum()
            {
                return sum;
            }
            public static void setsum(double Sum)
            {
                sum = Sum;
            }
            public static double Getnum()
            {
                return num;
            }
            public static void Setnum(double Num)
            {
                num = Num;
            }
        }
        //New class added for Display of data in page
        public class StudentInfo
        {
            public Int32 id { get; set; }
            public String studentnumber { get; set; }
            public String modulenam { get; set; }

            public String modulecod { get; set; }
            public String selfstudytim { get; set; }
            public String actualselfstudytim { get; set; }



        }

        //public class User
        //{
        //    public String username { get; set; }
        //    public String password { get; set; }

        //}

        //Calculations class contains essential methods
        public static class Calculations
        {

            public static void SelfStudyCalculation()
            {

                // Selfstudytime calculations
                //https://www.thecodingguys.net/tutorials/csharp/csharp-math-operations 
                //(thecodingguys,2022).
                DataCalculations.num = DataCalculations.NumberOfCredits * 10;
                DataCalculations.sum = DataCalculations.num / DataCalculations.NumberOfWeeks;
                DataCalculations.SelfStudyTime = DataCalculations.sum - DataCalculations.ClassHoursPerWeek;

            }
            public static void RemainingSelfStudy()
            {
                //SelfStudy calculation
                //https://www.thecodingguys.net/tutorials/csharp/csharp-math-operations 
                //(thecodingguys,2022).
                DataCalculations.ActualSelfStudy = DataCalculations.SelfStudyTime - DataCalculations.SpecificHours;


            }
            public static void Manipulation()
            {

                //Population of ArrayList
                //https://stackoverflow.com/questions/65837593/array-which-stores-information-from-user-input 
                //(stackoverflow,2022).

                myList.Add(DataCalculations.ModuleName);
                myList.Add("Module Code : " + DataCalculations.ModuleCode);
                myList.Add("Self study hours required per week : " + DataCalculations.SelfStudyTime + " Hours");
                myList.Add("Start Date : " + DataCalculations.n);
                myList.Add("ActualSelfStudy : " + DataCalculations.ActualSelfStudy + " Hours");


            }
            public static void linq()
            {
                //Linq for manipulation as required in POE
                //https://learn.microsoft.com/en-us/dotnet/csharp/linq/
                //(Microsoft,2022).
                var strings = from object o in myList
                              select o.ToString();

                DataCalculations.b = string.Join(" \n", strings.ToArray());
            }
            public static void Persist()
            {

                //Persiting of data
                //https://learn.microsoft.com/en-us/answers/questions/724367/c-storing-data-in-a-database.html
                //(Microsoft,2022)

                SqlConnection con = new SqlConnection("Data Source=prog62121st10091865.database.windows.net;Initial Catalog=ProgrammingPart2;User ID=jimmy;Password=4731598819Amo");
                con.Open();


                SqlCommand cmd = new SqlCommand("INSERT INTO UserData VALUES (@studentnum,@modulename,@modulecode,@selfstudytime,@actualselfstudytime)", con);
                cmd.Parameters.AddWithValue("@studentnum", DataCalculations.studentnrsample);
                cmd.Parameters.AddWithValue("@modulename", DataCalculations.ModuleName);
                cmd.Parameters.AddWithValue("@modulecode", DataCalculations.ModuleCode);
                cmd.Parameters.AddWithValue("@selfstudytime", DataCalculations.SelfStudyTime + " Hours");
                cmd.Parameters.AddWithValue("@actualselfstudytime", DataCalculations.ActualSelfStudy + " Hours");

                cmd.ExecuteNonQuery();
                con.Close();
               // MessageBox.Show("Saved", "UserData data", MessageBoxButton.OK, MessageBoxImage.Information);





            }
        }
    }
}
