## Assignment: Books CRUD

### What I implemented
- Book model with full validation (Name, Author, PublishDate, PageCount, IsSecondHand)
- EF Code First migration to create Books table
- Books List page (/Books)
- Create page (/Books/Create)
- Edit/Update page (/Books/Edit/{id})
- Delete confirmation page (/Books/Delete/{id})
- Navigation link added to shared layout

### How to run locally
1. Clone the repository
   git clone https://github.com/SENİNKULLANICIADIN/CetStudentBook
2. Open the solution in Visual Studio 2022+
3. Run migration steps (see below)
4. Press F5 or run `dotnet run`

### Migration steps
1. Open Package Manager Console (Tools → NuGet Package Manager → Package Manager Console)
2. Run the following commands:
   
   Add-Migration AddBooksTable
   Update-Database

   OR via terminal:
   
   dotnet ef migrations add AddBooksTable
   dotnet ef database update

3. This will create the Books table in your local database automatically.

### Requirements
- .NET 10.0 SDK
- SQL Server (LocalDB)
- Visual Studio 2022+

### Screenshots
<img width="1919" height="985" alt="Ekran görüntüsü 2026-04-04 132015" src="https://github.com/user-attachments/assets/c40cac93-0767-4ea9-b58c-44948ecd7776" />
<img width="1919" height="967" alt="Ekran görüntüsü 2026-04-04 132027" src="https://github.com/user-attachments/assets/38d4a11b-2972-4ce2-ab8b-a63c2160d3dd" />
<img width="1919" height="974" alt="Ekran görüntüsü 2026-04-04 132038" src="https://github.com/user-attachments/assets/4f901167-dcc6-4c2c-8425-925de631b48a" />
<img width="1919" height="975" alt="Ekran görüntüsü 2026-04-04 132055" src="https://github.com/user-attachments/assets/b7f99cc1-fe0a-46e4-9792-ed98ad565334" />





