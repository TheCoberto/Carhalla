# Mock-Car-Dealership

This is a mock car dealership full-stack web application utilizing ASP.NET MVC framework. Data storage is implemented via ADO.NET to a SQL Server instance.  Client-side will be implemented using C# Razor, HTML, CSS, BootStrap, and JavaScript/JQuery.

There will be two modes this application can run in, "QA" using an in-memory mock repository for testing, and "Production" using ASP.NET ADO and a SQL Server database instance.  These modes will be selectable using web.config's appSettings Key "Mode" and entering either of the above modes as the referenced value.

The dependency injection will be managed by Microsoft's Unity Framework.

Application user tables in the database were migrated using Entity Framework with ASP.Identity managing security and user roles.

#What the app will do:

The application's purpose is to allow a user to access the dealership's inventory via search parameters based on a user's selectable preferences (price range, make/model, used or new, etc.).  The user will have the ability via a web form to contact the dealership about a car they are interested in.

On the dealership side,  there will be two user roles (Sales, Admin).  The "Sales" user will only be able to access stored inventory and log new purchases into the database.  The "Admins" will be the only users with the CRUD priveledges consisting of manipulating new users (sales persons), vehicles, makes/models, dealership specials, and have access to sales and inventory in the database.





