# Normative Calculator App

This application allowed user to login and create recipes based on ingredients already seeded to database. All ingredients have name, quantity and price in database. App calculate cost of each recipe and gives user overview of costs of each recipe based on chosen ingredients. 


## Technologies

- .NET CORE 5
- Entity Framework with Microsoft SQL Server Express
- JWT for authentication
- ReactJS with Bootstrap UI

## Requirements

Please make sure you have .NET 5, Microsoft SQL Server Express installed on your local machine as application back-end will use IIS and MS SQL Server.

## Installation

- Clone git repository on your local machine
- CD into norm-calc folder

First you need to migrate and create database as follows.

- Enter in command line:

```
dotnet ef migrations add InitialCreate
```

```
dotnet ef database update
```

- CD into FRONTEND folder. In order to install ReactJS dependency modules enter to command line:

```
npm install
```

- In order to start server make sure you are in norm-calc root folder. To run application from single terminal enter:

```
dotnet run
```

- In order to start frontend of the application make sure you are in frontend folder. Then enter:

```
npm start
```

## Usage

Upon first run, application will seed the database with ingredients, some categories and default created user. Credentials for default user:

name: admin
password: admin123456

After successful frontend start, browser window should automatically open with the URL: http://localhost:3000. User will be presented with the login screen. Please use above credentials to login and start using application.

## Version
Version: 1.0