using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace TaxScheduler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string filePath = Contants.FilePath;
            string fileName = Contants.FileName;



            Console.WriteLine("Loading TaxInformation to the Database");

            await WebApiHelper.UploadTaxInformation(filePath, fileName);
            

            Console.WriteLine("*************************************************************************");

            Console.WriteLine("Started Fetching Tax Details");

            Console.WriteLine("Please Enter Municipality Name:-");

            string name = Console.ReadLine();

            Console.WriteLine("Please Enter Date:-");

            string date = Console.ReadLine();

            await WebApiHelper.GetTaxDetails(name, date);            

            Console.WriteLine("*************************************************************************");

            Console.WriteLine("Started Saving Tax Information");

            Console.WriteLine("Please Enter Municipality Name:-");

            string municipalityName = Console.ReadLine();

            Console.WriteLine("Please Enter Date:-");

            string dt = Console.ReadLine();

            Console.WriteLine("Please Enter Frequency:-");

            string frequency = Console.ReadLine();

            Console.WriteLine("Please Enter Tax:-");

            string tax = Console.ReadLine();

            await WebApiHelper.SaveTaxDetails(municipalityName, dt, frequency, tax);

            

            Console.WriteLine("*************************************************************************");
            

            Console.WriteLine("Update Tax Information");

            Console.WriteLine("Please Enter Municipality Name:-");

            string strName = Console.ReadLine();

            Console.WriteLine("Please Enter Date:-");

            string strDate = Console.ReadLine();

            Console.WriteLine("Please Enter Frequency:-");

            string strFrequency = Console.ReadLine();

            Console.WriteLine("Please Enter Tax:-");

            string strTax = Console.ReadLine();

            await WebApiHelper.UpdateTaxDetails(strName, strDate, strFrequency, strTax);
           

            Console.WriteLine("*************************************************************************");

            Console.WriteLine("Get TaxInformation from the Database");

            await WebApiHelper.GetALLTaxDetails();

            Console.WriteLine("*************************************************************************");


        }
    }
}

