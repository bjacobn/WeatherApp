# WeatherApp


## About
A  responsive ASP.NET MVC API demo application that gets current weather data and allows user to create account, login and send feedback. 
All user input is validated and stored in MySql database. Deployed and hosted on Heroku platform. 
<br>
<br>
<br>


![Desktop](https://user-images.githubusercontent.com/91929228/177019363-8e4285f2-f4c8-422d-9766-2e8f4ad1c405.gif)


![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![MySQL](https://img.shields.io/badge/mysql-%2300f.svg?style=for-the-badge&logo=mysql&logoColor=white) ![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white) ![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white) ![Bootstrap](https://img.shields.io/badge/bootstrap-%23563D7C.svg?style=for-the-badge&logo=bootstrap&logoColor=white) ![Heroku](https://img.shields.io/badge/heroku-%23430098.svg?style=for-the-badge&logo=heroku&logoColor=white)
<br>
<br>
<br>

## Navigation

- [Build](#build)
- [Usage](#usage)
- [Support](#support)


## Build

Framework : ASP.NET Core 3.1 

Design Pattern : MVC

Nuget Libraries :
- Dapper : ORM queries database.
- dotenv.net : Secure API key in environment variable.
- FluentValidation.AspNetCore : Validate user input.
- MySql.Data ; Connect application to MySql database.
- Newtonsoft.Json : Convert json data to .NET type.
- RestSharp : Build and send API requests


## Usage

To demo the application on Heroku : [Click here](https://weathermvcdemo.herokuapp.com/ "Click here")

To Fork or Clone and run on your local machine :

Configure API:
1. Get API Key : [Click here](https://rapidapi.com/apishub/api/yahoo-weather5/ "Click here")
2. Rename .envExample file to .env
3. Place your API key in the new .env file
4. Run application

Configure MySql Database:
1. Download MySql Workbench [Click here](https://www.mysql.com/products/workbench/ "here")
2. Create local instance database
3. Create new schema named **weatherapp** 
4. Create table named **contact** with 3 columns named ***FullName* , *Email*, *Feedback***
5. Create table named **userdata** with 5 columns named ***UserId* , *FirstName*, *LastName*, *Email, Password***
6. Add the connection string below to appsettings.json file in the source code with your new MySql password. <br>
 "weatherapp":    "Server=localhost;Database=weatherapp;uid=root;Pwd=**your_MySql_password**;Port=3306;", <br>
7. Go to Startup.cs and rename Mysql connection string to weatherapp.





## Support

Please [open an issue](https://github.com/bjacobn/WeatherApp/issues) for support.



