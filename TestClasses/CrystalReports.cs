//int jobN;

//            Console.Write("Enter JobN: ");
//            while (!Int32.TryParse(Console.ReadLine().ToString(), out jobN))
//            {
//                Console.Write("Try again: ");
//            }

//            Console.WriteLine("JobN: " + jobN);

//            try
//            {
//                CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
//                report.Load("../../Invoice_ElectronicDistribution.rpt");
//                report.SetDatabaseLogon("sa", "F!neline25", "SQL1", "pLogic");
//                report.SetParameterValue("InvType", "Shawn");
//                report.SetParameterValue("InvKey", "100660");
//                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "C://Users/shawnh/Desktop/test.pdf" );
//                report.
//                Console.WriteLine("Success!");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
           // } 