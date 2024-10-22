using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace Company.Function
{
    public static class GoogleSheetService
    {
        static string ApplicationName = "Google Sheets API with C#";
        static string SpreadsheetId = "1jprjTBJcZgMsBYtUdPbfejCze4o5W5jeM_sB8g0aXgw";


        private static SheetsService GetSheetsService()
        {
            // Create Google Sheets API service
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = GoogleCredentialHelper.GetCredentials(),
                ApplicationName = ApplicationName,
            });

            return service;
        }
    
        private static SpreadsheetsResource.ValuesResource GetSpreadsheetValuesResource(SheetsService service)
        {
            return service.Spreadsheets.Values;
        }

        public static IList<IList<object>> GetData() 
        {
            var service = GetSheetsService();
            var spreadsheet = GetSpreadsheetValuesResource(service);

            var range = "Orders!A2:Z";
            
            // Read data from the sheet
            SpreadsheetsResource.ValuesResource.GetRequest request = spreadsheet.Get(SpreadsheetId, range);
            ValueRange response = request.Execute();
            var values = response.Values;

            return values;
        }


        public static void PutData(string range, IEnumerable<string> values) 
        {
            var service = GetSheetsService();
            var spreadsheet = GetSpreadsheetValuesResource(service);

            // var range = "Menu!A:A";

            var valuesList = values.Select(v => {

                return new List<object>() { v };
            }).ToArray();

            
            // Create the values to write
            var valueRange = new ValueRange
            {
                Values = valuesList
            };

            var clearRequest = new ClearValuesRequest();

            // Execute the clear request
            var response1 = spreadsheet.Clear(clearRequest, SpreadsheetId, range).Execute();
            Console.WriteLine("All data in the first column has been cleared.");

            // Create the request to update the values in the sheet
            var updateRequest = spreadsheet.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            // Execute the update request
            var response2 = updateRequest.Execute();
            Console.WriteLine($"{response2.UpdatedCells} cells updated.");
        }

        public static void PutWWWData() 
        {
            var service = GetSheetsService();
            var spreadsheet = GetSpreadsheetValuesResource(service);

            var range = "Menu!E2:E";

            // Retrieve the data from the sheet to determine how many rows exist in column E
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = spreadsheet.Get(SpreadsheetId, range);
            ValueRange getResponse = getRequest.Execute();
            IList<IList<object>> existingRows = getResponse.Values;

            int rowCount = existingRows != null ? existingRows.Count : 0;

            List<IList<object>> guids = new List<IList<object>>();
            for (int i = 0; i < rowCount; i++)
            {
                // Generate a GUID for each empty row in column E
                string guid = Guid.NewGuid().ToString();
                guids.Add(new List<object> { guid });
            }

            // Prepare the value range to write the GUIDs back into the sheet
            ValueRange valueRange = new ValueRange
            {
                Range = range,
                Values = guids
            };

            // Update the sheet with the new GUIDs
            var updateRequest = spreadsheet.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse updateResponse = updateRequest.Execute();

            Console.WriteLine($"Inserted {updateResponse.UpdatedCells} GUIDs into column E.");
        }

    
    
    
    }
}