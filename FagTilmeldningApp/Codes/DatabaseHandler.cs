using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldningApp.Codes
{
    internal class DatabaseHandler
    {
        enum TecDBTables
        {
            Teacher,
            Course,
            Student,
            Enrollment
        }
        public string ConnectionString
        {
            get => "Data Source=SKAB1-PC-05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public object GetRecords(TecDBTables tableName)
        {
            object list = new object();
            using SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", con);
        }



        }
}
