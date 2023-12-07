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
