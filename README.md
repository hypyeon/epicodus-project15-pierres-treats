# Pierre's Sweet and Savory Treats 🧁
by Hayeong Pyeon

![preview](./PierresTreats/wwwroot/img/preview.png)

## Table of Contents
1. [Technologies Used](#technologies-used)
2. [Description](#description)
3. [Setup Instructions](#setup-instructions)
4. [Known Bugs](#known-bugs)
5. [License](#license)

## Technologies Used
- C#, .NET
- ASP.NET Core MVC
- MySQL (Community Server, Workbench)
- Entity Framwork Core
- Many-To-Many Relationships, CRUD
- Authentication and Identity: User Registration Controller, ViewModel, Validation, and Views; Login and Logout; and Authorization 
- SCSS

## Description
- This application is an independent project as a review of **Authentication with Identity** chapter of **C#** course provided by Epicodus.
- The project objectives are as follows:    
*boxes will be checked upon completion of this project*
> - [x] Many-to-many relationship is applied between `Treat`s and `Flavor`s.
> - [x] The application should have user authentication. 
> - [x] A user should be able to log in and log out; to navigate to a splash page that lists all treats and flavors; and to click on each item to see all the treats/flavors that belong to it. 
> - [x] Only logged in users should have access to create, update, and delete items (full CRUD functionality). All others can only view them (Read functionality only).  
- Stylings are complete only for `Index.cshtml` and `Details.cshtml` files. 

## Setup Instructions
1. Clone this repo. 
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's production directory named **PierresTreats**. 
3. Create a file named **appsettings.json**. 
> [!CAUTION]
> Before pushing commits with the step 4, you should have a `.gitignore` file in the root directory with the following content:
```
obj
bin
appsettings.json
```
4. In the `appsettings.json` file, write the following code, replacing `uid` and the `pwd` values with your own username and password registered for MySQL. 
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=pierres_auth;uid=[YOUR-USERNAME];pwd=[YOUR-PASSWORD];"
  }
}
```
5. Install tools in order to use `dotnet-ef` by running the following commands:
- Has to be run globally: 
```
dotnet tool install --global dotnet-ef --version 6.0.0
```
- Has to be run under the production directory: 
```
dotnet add package Microsoft.EntityFrameworkCore.Design -v 6.0.0
```
6. Run `dotnet ef migrations add [AddEntity]` to create a data migration for the database. *Check out how to name your migration [here](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli).*
7. Refer to the following commands when updating, deleting, and viewing migrations. These commands should be made within the production directory. 
- To **update** the database after making a change, run `dotnet ef database update` in the terminal. 
- To **remove** the recent update, run `dotnet ef migrations remove` in the terminal. 
- To **view** the update history, run `dotnet ef migrations list` in the terminal. 
8. To configure Identity to work with EF Core, run the following command in the terminal.
```
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 6.0.0
```
9. To compile and run the application in development mode with a watcher, run `dotnet watch run` which will open the browser automatically - if not - open the browser and navigate to https://localhost:5001. 

## Known Bugs
No known bugs as of the last update made on March 20, 2024 

## License
[MIT](/LICENSE.txt) | Copyright © 2024 Hayeong Pyeon