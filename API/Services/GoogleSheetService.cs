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

        public static void DeleteRowById(string id) 
        {
            var service = GetSheetsService();
            var spreadsheet = GetSpreadsheetValuesResource(service);

            var range = "Orders!A2:Z";
            
            // Fetch the data from the column to check for the row with the matching value
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = spreadsheet.Get(SpreadsheetId, range);
            ValueRange getResponse = getRequest.Execute();
            IList<IList<object>> rows = getResponse.Values;

            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            // Look for the row with the value "DeleteMe"
            int rowIndexToDelete = -1; // Initialize to an invalid value
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Count > 0 && rows[i][4].ToString() == id) // Assuming the value is in column A
                {
                    rowIndexToDelete = i + 1; // Add 1 because the data starts from row 2 (offset by 1 for actual row index)
                    break;
                }
            }

            if (rowIndexToDelete == -1)
            {
                Console.WriteLine("Row with matching value not found.");
                return;
            }

            // Prepare the request to delete the found row
            int sheetRowIndex = rowIndexToDelete + 1; // Adjust for 0-based index, and account for header row

            Request deleteRequest = new Request
            {
                DeleteDimension = new DeleteDimensionRequest
                {
                    Range = new DimensionRange
                    {
                        SheetId = 266468733, // Adjust if necessary based on your sheet ID
                        Dimension = "ROWS",
                        StartIndex = sheetRowIndex - 1, // Zero-based index
                        EndIndex = sheetRowIndex // Delete one row (exclusive end)
                    }
                }
            };

            // Add the delete request to the batch update
            BatchUpdateSpreadsheetRequest batchRequest = new BatchUpdateSpreadsheetRequest
            {
                Requests = new List<Request> { deleteRequest }
            };

            // Execute the batch update request to delete the row
            var batchUpdateRequest = service.Spreadsheets.BatchUpdate(batchRequest, SpreadsheetId);
            BatchUpdateSpreadsheetResponse response = batchUpdateRequest.Execute();

            Console.WriteLine($"Row {sheetRowIndex} deleted successfully.");
        }

        public static void DeleteRowById2(IEnumerable<string> ids) 
        {
            var service = GetSheetsService();
            var spreadsheet = GetSpreadsheetValuesResource(service);

            var range = "Orders!A2:Z";
            
            // Fetch the data from the column to check for the row with the matching value
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = spreadsheet.Get(SpreadsheetId, range);
            ValueRange getResponse = getRequest.Execute();
            IList<IList<object>> rows = getResponse.Values;

            if (rows == null || rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            // List of strings to search for (multiple values)

            // Prepare the batch update request for deleting multiple rows
            List<Request> deleteRequests = new List<Request>();

            // Track the indices of rows to be deleted (adjust for 0-based indexing)
            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Count > 0)
                {
                    string cellValue = rows[i][4].ToString();
                    
                    // If the cell value matches any value in the stringsToDelete list
                    if (ids.Contains(cellValue))
                    {
                        int sheetRowIndex = i + 1 + 1; // Add 1 because data starts from row 2; another +1 for 0-based index

                        // Add the delete request for the found row
                        deleteRequests.Add(new Request
                        {
                            DeleteDimension = new DeleteDimensionRequest
                            {
                                Range = new DimensionRange
                                {
                                    SheetId = 266468733, // Adjust if necessary based on your sheet ID
                                    Dimension = "ROWS",
                                    StartIndex = sheetRowIndex - 1, // Zero-based index
                                    EndIndex = sheetRowIndex // Delete one row (exclusive end)
                                }
                            }
                        });
                    }
                }
            }

            // Check if there are any rows to delete
            if (deleteRequests.Count > 0)
            {
                // Prepare the batch update request
                BatchUpdateSpreadsheetRequest batchRequest = new BatchUpdateSpreadsheetRequest
                {
                    Requests = deleteRequests
                };

                // Execute the batch update request to delete the rows
                var batchUpdateRequest = service.Spreadsheets.BatchUpdate(batchRequest, SpreadsheetId);
                BatchUpdateSpreadsheetResponse response = batchUpdateRequest.Execute();

                Console.WriteLine($"{deleteRequests.Count} rows deleted successfully.");
            }
            else
            {
                Console.WriteLine("No matching rows found to delete.");
            }
        }
    
    
    }
}