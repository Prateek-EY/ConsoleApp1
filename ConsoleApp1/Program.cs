using System.Data;
using System.Web;
using ConsoleApp1;
using IronXL;
using Newtonsoft.Json;

string cityName = Console.ReadLine();
WorkBook workBook = WorkBook.Load(@"C:\Users\Prateek_Dev\OneDrive - Dell Technologies\Desktop\City\Cities.xlsx");
WorkSheet workSheet = workBook.DefaultWorkSheet;

// Convert the worksheet to DataTable
DataTable dataTable = workSheet.ToDataTable(true);

// Enumerate by rows or columns first at your preference
var result_rows = dataTable.AsEnumerable().Where(r => r.Field<string>("city_ascii") == cityName).ToArray();
var lat = result_rows[0].ItemArray[2];
var longitude = result_rows[0].ItemArray[3];
using (var httpClient = new HttpClient())
{
    string requestUri = "https://api.open-meteo.com/v1/forecast";
    var uriBuilder = new UriBuilder(requestUri);
    var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);
    paramValues.Add("latitude", (string?)lat.ToString());
    paramValues.Add("longitude", (string?)longitude.ToString());
    paramValues.Add("current_weather","true");
    uriBuilder.Query = paramValues.ToString();
    using (var response = await httpClient.GetAsync(uriBuilder.Uri))
    {
        string apiResponse = await response.Content.ReadAsStringAsync();
        var response_json = JsonConvert.DeserializeObject<CityResponse>(apiResponse);
    }

}