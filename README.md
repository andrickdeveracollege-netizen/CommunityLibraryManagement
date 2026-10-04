**COMMUNITY LIBRARY MANAGEMENT SYSTEM**



The Community Library Management System is a RESTful Web API built with ASP.NET Core and Entity Framework Core. It is designed to manage three related resources: books, members, and loans. The system allows users to perform CRUD operations and manage the relationship between members and the books they borrow.


**_Database Setup_**
Open SQL Server Management Studio and run _/database/database-design.sql_ first to create the database and tables. After that, run _/database/database-content.sql_ to insert the sample data.

Configure the connection string in _appsettings.json_ to match your SQL Server setup. The connection string should point to the _CommunityLibraryDb_ database.

After configuring the database, run the application using:
_dotnet run_


**_Endpoints_**

_Books:_
-GET /api/Books
-GET /api/Books/{id}
-POST /api/Books
-PUT /api/Books/{id}
-DELETE /api/Books/{id}

_Members:_
-GET /api/Members
-GET /api/Members/{id}
-POST /api/Members
-PUT /api/Members/{id}
-DELETE /api/Members/{id}
