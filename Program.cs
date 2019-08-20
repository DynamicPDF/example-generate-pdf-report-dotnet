using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using System.Text.RegularExpressions;

namespace example_generate_pdf_report_dotnet
{
    // This example shows how to create a PDF report.
    // It references the ceTe.DynamicPDF.CoreSuite.NET NuGet package.
    class Program
    {
        // Generates a PDF report using a collection of objects.
        // The collection of objects is in the SimpleReportWithCoverPageExampleData class.
        // This code uses the DynamicPDF ReportWriter for .NET product.
        // Import the ceTe.DynamicPDF namespace for the Document class.
        // Import the ceTe.DynamicPDF.LayoutEngine namespace for the DocumentLayout class.
        static void Main(string[] args)
        {
            // Create DocumentLayout object using the DLEX (report layout) file
            DocumentLayout layoutReport = new DocumentLayout(GetResourcePath("SimpleReportWithCoverPage.dlex"));

            // Create a NameValueLayoutData object with the Data
            NameValueLayoutData layoutData = new NameValueLayoutData();
            layoutData.Add("ReportCreatedFor", "Alex Smith");
            layoutData.Add("Products", SimpleReportWithCoverPageExampleData.Products);

            // Get the Document from the DocumentLayout
            Document document = layoutReport.Layout(layoutData);

            //Save the Document
            document.Draw("output.pdf");
        }

        // This is a helper function to get the full path to a file in the Resources folder.
        public static string GetResourcePath(string inputFileName)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, "Resources", inputFileName);
        }
    }
}
