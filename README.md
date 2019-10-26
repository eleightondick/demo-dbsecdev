# demo-dbsecdev

Demos - Database Security and Privacy for Developers

# SecurityApplication

The purpose of this is a simple application that demonstrates the topics discussed during the presentation.

## Launch and Use

This application should be launched using Visual Studio 2019.  Community edition should be fine, but it's only been tested with the Professional Edition.

Check out the repository, or download a zip file.  Once that's done do the following:

1.  Load the `SecurityApplication/SecurityApplication.sln` in Visual Studio
2.  Restore NUGET packages.  You can do this by making the "Package Manager Console" (Under View -> Other Windows) visible, and selecting the "Restore Packages" once prompted.
3.  Setup your database connection.  This can be done by editing the Web.config file under line 12 (EFDbContext).  Right now, it's assuming there's a database server called "SQL" with a preexisting database called "SecurityPresentation"
4.  Run the application once.  This should create the tables and run all necessary migrations.
5.  Execute the `Scripts/TemplateData.sql` within "SQL Management Studio" to load the template data.

## Some Notes

1.  The `Scripts/TemplateData.sql` can be run multiple times, and will have to be for some of the presentation content.  It wipes all existing records before recreating.
