# How to Read Passport Data Using IronBarcode

Reading passport data accurately is a critical task for applications that require identity verification, such as border control systems, financial services, or travel booking platforms. The ReadPassport() method from IronBarcode provides an advanced solution to extract relevant information from passport documents.

IronBarcode, enhanced with the 'IronOcr.Extensions.AdvancedScan' package offers specialized methods for reading various document types, including passports. The ReadPassport() method simplifies the extraction of key data fields from passport images, ensuring high accuracy and reliability.

## Install with NuGet
```
Install-Package IronOcr
Install-Package IronOcr.Extensions.AdvancedScan
```
## How to Read Passport Data

To read passport data from an image using IronBarcode, follow these steps:

1.  **Install** [IronBarcode](https://www.nuget.org/packages/IronOcr) and the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package to access the ReadPassport() method.
2.  **Initialize the OCR engine** by creating an instance of the IronTesseract class.
3.  **Create an OCR input** object using a 'using' statement to ensure proper resource management.
4.  **Load the passport image** into the OCR input object by specifying the image file path.
5.  **Read the passport data** from the loaded image using the 'ReadPassport' method of the OCR engine.
6.  **Utilize the PassportInfo** object to access structured data such as passport number, issuing country, name, date of birth, and expiry date. Alternatively, use the result.Text property to obtain the complete text extracted from the passport.

## ReadPassport Example

After loading the passport image, the ReadPassport() method can be used to extract essential details. Below is an example of how to implement this method.
```
using IronOcr;
            

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
```        

Sample Passport Image used as Input (downloaded from [here](https://sanatoriikavkaza.ru/foto/inostrannyj-pasport))
![passport](https://github.com/user-attachments/assets/d27d8f3b-c636-453c-b6de-fddf63c9bfe5)

## Understanding the Result

1. **PassportInfo Object:** This object contains structured data extracted from the passport, including:
   -    **Country:** The country code of the passport's issuing authority.
   -    **PassportNumber:** The unique passport number extracted from the document.
   -    **GivenNames:** The given names (first and middle names) of the passport holder.
   -    **Surname:** The surname (last name) of the passport holder.
   -    **DateOfBirth:** The birth date of the passport holder.
   -    **DateOfExpiry:** The expiration date of the passport.

2. **result.Text:** This property provides the complete text extracted from the passport image, which may include additional information not parsed into the PassportInfo object.

Output Screenshot

![image](https://github.com/user-attachments/assets/15ebf3b4-79a1-437c-8433-3c2eaf6fcd36)

## Important Considerations

1. **Installation Note:** Ensure that both the IronOCR and IronOcr.Extensions.AdvancedScan libraries are installed to utilize the ReadPassport() method effectively.

2. **Image Quality:** Ensure the passport image is clear and unobstructed for optimal accuracy. If the passport image is of low resolution or contains noise, the OCR process might struggle to accurately extract the information. To enhance the quality of the input image, you can apply [OCR image filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/) provided by IronOCR. These filters can help improve the clarity and readability of the text, leading to more accurate results.
