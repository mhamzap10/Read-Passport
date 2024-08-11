using IronOcr;


namespace ReadPassport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            License.LicenseKey = "IRONSUITE.WINSWRITERSIRONSOFTWARECOM.31102-3E7C9B3308-CIHWVP2-L2A7FVEBUSFN-DP6CI32YVXIN-45HQSAZOBOCW-YCYETGS4ENQX-NZXXG4YCPAYI-EBCIJ43PNLJW-DKWC7U-TFXPQ4LKLXGPEA-DEPLOYMENT.TRIAL-G43TTA.TRIAL.EXPIRES.20.MAY.2025";
            IronTesseract ocr = new IronTesseract();
            using OcrInput input = new OcrInput();
            //Load Passport Image
            input.LoadImage("Passport.jpeg");

            // Read Passport
            OcrPassportResult result = ocr.ReadPassport(input);
            
            // Extract Passoport Information
           PassportInfo info = result.PassportInfo;
            Console.WriteLine(@$"Country: {info.Country}
Passport Number: {info.PassportNumber}
Given Names: {info.GivenNames}
SurName: {info.Surname}
Date of Birth: {info.DateOfBirth}
Date of Expiry: {info.DateOfExpiry}");
        }
    }
}
