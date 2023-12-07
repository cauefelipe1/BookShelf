# BookShelf

The BookShelf is a Web API for storing books and listing the books stored.

It is a Web API written in C#/Asp Net Core using Postgres SQL as Database and pure ADo to interact with the database layer.

The application implements a very simple user login process, very unsecure for actual standards, it was done to respect the restriction of not using EF. But as the idea behind is only to illustrate some sort of authorization behaviour in the API, it achieves this goal.

The application is split in three main layers, that are listed bellow: 

  * API
  * Application
  * Data

**API**

This layer that is the Web API itself, this layers is responsible for receiving the requests and use the appropriate service provided by the Application layer.

**Application**

This layer is responsible for providing the services that will be used by the API layer and also responsible to interact with the data layer.
Also this is the layer that will hold all business logic and validations.

**Data**
This is the layer responsible for connecting to interact with the database and perform all database related logic.
It also holds the DAOs models that represents the physical table.


Besides the layers already meant, there is also another library called *BookShelf.Models*. This library is responsible for holding all models for the application. In that way this library can be shared for any other library or application that interact with the same domain.  


## Running the Application

The application can be executed via IDE or via Docker.

### Docker

The application can be executed via docker, executing the following command in the root path of the repository in your machine:

`docker compose --profile book_shelf up`

After the containers are created and started, you can access the following address in the web browser to access the swagger interface:

http://localhost:5100/swagger/index.html

### IDE
Just open the solution *BookShelf.sln* in your preferred IDE, and start the project *BookShelf.API*

For creating the database, you can either run the following command following command in the root path of the repository in your machine:

`docker compose --profile database up`

Or, you can grab the init script in the path ./Scripts/Database/init_db.sql and execute it in your PostgreSQL server.


## Configuring the database access
The database configuration lives in the *appsettings.json* in the *BookShelf.API* project.

