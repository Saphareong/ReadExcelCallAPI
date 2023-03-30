using Add50Registration;
using Add50Registration.body;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

Excel.Application excelApp = new Excel.Application();

string executablePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

// Combine the directory path with the file name of the Excel file
string filePath = Path.Combine(executablePath, "50-places.xlsx");

// Open the Excel file
Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

// Get the first worksheet in the workbook
Excel.Worksheet worksheet = workbook.Sheets[1];

// Get the range of cells that contain data
Excel.Range range = worksheet.UsedRange;

Stack<RegisterLocation> fiftyLocations = new Stack<RegisterLocation>();

// Loop through the cells and read the data
for (int row = 2; row <= range.Rows.Count; row++)
{
    //classic way
    string[] values = new string[6];

    for (int col = 1; col <= range.Columns.Count; col++)
    {
        string cellValue = range.Cells[row, col].Value2.ToString();

        values[col - 1] = cellValue;
    }

    fiftyLocations.Push(new RegisterLocation
    {
        address = values[0],
        compound = new Compound
        {
            commune = values[1],
            district = values[2],
            province = values[3]
        },
        location = new NotLocation
        {
            lat = values[4],
            lng = values[5]
        }
    });
}

// Close the workbook and release resources
workbook.Close();
excelApp.Quit();

Console.WriteLine("Loaded 50 places");

//const string FixedPassword = "Tinhnguyenvientest001//";


//S4lifeBloodDonationContext context = new S4lifeBloodDonationContext();

//using HttpClient client = new();
//client.DefaultRequestHeaders.Accept.Clear();
//client.DefaultRequestHeaders.Accept.Add(
//    new MediaTypeWithQualityHeaderValue("application/json"));


//await ProcessRepositoriesAsync(client, context, fiftyLocations);





//static async Task ProcessRepositoriesAsync(HttpClient client, S4lifeBloodDonationContext context, Stack<RegisterLocation> fiftyLocations)
//{
//    var testVolunteers = await context.Users.Where(u => u.UserName.Contains("tinhnguyenvientest")).Take(50).Select(u => u.UserName).ToListAsync();

//    Console.WriteLine("Loaded 50 test volunteers");

//    foreach (var volunteer in testVolunteers)
//    {
//        var requestLogin = new StringContent(JsonConvert.SerializeObject(new LoginBody { username = volunteer, password = FixedPassword }), Encoding.UTF8, "application/json");

//        var response = await client.PostAsync("https://api.s4life.site/api/v1/auth/login", requestLogin);
//        //var response = await client.PostAsync("https://localhost:7061/api/v1/auth/login", requestLogin);

//        var loginResult = JsonConvert.DeserializeObject<LoginResult>(await response.Content.ReadAsStringAsync());

//        client.DefaultRequestHeaders.Remove("Authorization");
//        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginResult.result.accessToken);

//        var requestRegistration = new StringContent(JsonConvert.SerializeObject(
//            new RegistrationBody { eventCode = "MOBILE50", eventId = 3186, participationDate = new DateTime(2023, 4, 6), registerLocation = fiftyLocations.Pop() })
//            , Encoding.UTF8, "application/json");

//        response = await client.PostAsync("https://api.s4life.site/api/v1/event-registrations", requestRegistration);
//        //response = await client.PostAsync("https://localhost:7061/api/v1/event-registrations", requestRegistration);

//        if (response.StatusCode == System.Net.HttpStatusCode.OK)
//        {
//            Console.WriteLine("Successfully added: " + volunteer);
//        }
//        else
//        {
//            Console.WriteLine("Failed added: " + volunteer);
//        }
//        //break;
//    }


//}