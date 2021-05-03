# Wheel of Fortune

----------------------------------
About the Application
----------------------------------
This is an phone application for Android - with future possibilities to be deployed on iOS as the application is coded to be multiplatform compatible. 
The application is a Wheel of Fortune where the User can spin the wheel to recieve points that can be used as discount at a specific webshop. 

-----------------------------------------
Database
-----------------------------------------
This application uses a SQLite Database which is lightweight for phone applications.
The only table the database contains is a "Prize" table. 
With the following entites:

(PK) 
ID

Points

Date

-----------------------------------------
System Development Methodology
-----------------------------------------
For the development of this application 
a mixture of SCRUM and XP was used by a single developer
to beable to fullfill the desired requirements set by the customer.
A focus on daily standup meeting was a priority so an overview of the day to come and the day before could be created (in-visioned)
From the XP perspective a focus on refactoring and fast deployment was the focus. 

What could have been included would have been a test focused approach (Think XP) to test the code before deployment inform of Unit Testing and Acceptance Testing to ensure software quality for example. 

----------------------------------
Link to Documentation (Report)
----------------------------------

[](https://docs.google.com/document/d/18tU1W9ROD--ZrSM-N7SD8Ortk4kMmCiPd9nDaHYnbA8/edit?usp=sharing "Link to Google Docs")

----------------------------------
Technical Specifications
----------------------------------
Environment: Microsoft Visual Studio Enterprise 2019 (v 16.8.4)

Microsoft .NET Framework (v 4.8.04084)

TargetFramework netstandard 2.0

Android compatible with Android 11.0(R) and previous versions

Nuget Packages for both Projects
--------------------------------

SkiaSharp.Views.Forms (v2.80.2)

Xamarin.Essentials (1.5.3.2)

Xamarin.Forms(4.8.0.1451)

Polly (v7.2.2)

Refractored.MvvmHelpers (v.1.6.2)

Rg.Plugins.Popup (v2.0.0.11)

sqlite-net-pcl (v1.7.335)

System.Threading.Tasks.Extensions (v4.5.4)

SkiaSharp.Views.Forms (v2.80.2)

