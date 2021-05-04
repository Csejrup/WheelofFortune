# Wheel of Fortune

----------------------------------
About the Application
----------------------------------
This is an phone application for Android - with future possibilities to be deployed on iOS as the application is coded to be multiplatform compatible. 
The application is a Wheel of Fortune where the User can spin the wheel to recieve points that can be used as discount at a specific webshop. 

----------------------------------------
To Run the Application
----------------------------------------
To be able to test and run the application you must use an android Emulator, example a Pixel 2 Pie 9.0 - API 28 (Android 9.0 - API 28), 
or connect your own Android to Visual Studio. 
Follow the microsoft guide on this link if you wish to connect your own Android Phone:

[Set up Device for Development](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/set-up-device-for-development)

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

[Link to Google Docs](https://docs.google.com/document/d/18tU1W9ROD--ZrSM-N7SD8Ortk4kMmCiPd9nDaHYnbA8/edit?usp=sharing)

----------------------------------
User Guide
----------------------------------

When you run the Application the first page (view) you will see is the Wheel of Fortune. If you have already spun the Wheel, you can click the "Prize History" Button in the bottom right corner on the tab bar to see what you previously have won. 
When you spin the wheel the wheel will spin for X amount of seconds before slowing down and eventually stopping. When stopped a Popup window will appear showing you how many points you have won and thereby you click the "CLAIM" Button and the points have been claimed. When claimed the Points will appear in the "Prize History" page, however to make it fully appear you must click the "Refresh" Button on the bottom of the page, and the list will be refreshed, and you will be able to see what you just won. 

----------------------------------
Technical Specifications
----------------------------------

As said the application uses Xamarin Framework. If you haven't installed Xamarin on Visual Studio. You must follow this guide to do so:

[Guide to Install/Add Xamarin to VS Studio](https://docs.microsoft.com/en-us/xamarin/get-started/installation/windows)

The application uses the Android 11 SDK. Thereby you must download and install this SDK. Follow this guide:

Click Tools > SDK Manager.

In the SDK Platforms tab, select Android 11.

In the SDK Tools tab, select Android SDK Build-Tools 30 (or higher).

Click OK to begin install.

[To see all SDKs on the List](https://docs.microsoft.com/en-us/answers/questions/191019/missing-android-11-in-sdk-manager.html)


The Application uses the Xamarin(Forms) Framework from Visual Studio

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

