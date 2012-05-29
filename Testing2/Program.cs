using System;
using System.Collections;
using System.Text;
using System.Xml;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace Testing2
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = 0;

            Console.WriteLine("Fineline Credit Card Number Return");

            while (test == 0)
            {

                Helpers help = new Helpers();

                Console.Write(Environment.NewLine + "Enter a Job Number: ");
                help.ref1 = Convert.ToInt32(Console.ReadLine());

                Helpers help2 = new Helpers();
                help2.getRefRecord(help.ref1);

                Console.Write(Environment.NewLine + "Go again? ");
                string input = Console.ReadLine();

                if (input == "yes")
                    test = 0;
                else
                    test = 1;
            }
        }
    }

    public class Helpers
    {
        public int ref1;
        public string ref2;
        public string ref3;

        public Helpers()
        {

        }

        public void insertRefRecord(int job, string cc, string cv2)
        {
            string q = @"INSERT INTO CT_Ref
                         VALUES ('" + job + "', EncryptByPassPhrase('F!neline25', '" + cc + "'), '" + cv2 + "')";
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=SQL1; Initial Catalog=printable; User ID=FPGwebservice; Password=kissmygrits"))
                {
                    SqlCommand command = new SqlCommand(q, conn);
                    try
                    {
                        int rowsInserted = 0;
                        command.Connection.Open();
                        rowsInserted = command.ExecuteNonQuery();
                        command.Dispose();
                        command = null;
                        Console.WriteLine(rowsInserted + " rows inserted.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void getRefRecord(int job)
        {
            string q = @"SELECT ref1, DecryptByPassPhrase('F!neline25',ref2), ref3
                         FROM printable.dbo.CT_Ref
                         WHERE ref1 = " + job;
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=SQL1; Initial Catalog=printable; User ID=FPGwebservice; Password=kissmygrits"))
                {
                    SqlCommand command = new SqlCommand(q, conn);
                    try
                    {
                        command.Connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                this.ref1 = Convert.ToInt32(reader[0].ToString());
                                this.ref2 = Encoding.ASCII.GetString((byte[])reader[1]);
                                this.ref3 = reader[2].ToString();

                                Console.WriteLine("JobN: " + ref1);
                                Console.WriteLine("CC #: " + ref2);
                                Console.WriteLine("CV2 : " + ref3);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
