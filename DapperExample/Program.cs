using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperExample.Helpers;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DapperExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            List<SurveyQuestions> questions = p.ReadAll();
        }

        public List<SurveyQuestions> ReadAll()
        {
            string connectionString = "Data Source=myDatabase;Initial Catalog=myCatalog;Persist Security Info=True;User ID=userid;Password=password";
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<SurveyQuestions>
                    ("SELECT * FROM survey_questions (NOLOCK)").ToList();
            }          

        }
    }
}
