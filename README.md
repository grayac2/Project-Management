# README #

This application was created as a project for a university course. Anyone is free to use it and/or modify it for their own purposes.

### What is this repository for? ###

* This application is a project management tool. It allows the user to manage people, projects, and roles. It also allows assignment of the three to each other. It currently does not support user authentication, so it is most suitable for local use only, unless modified.

* Version 1.0.0

### How do I get set up? ###

This application runs on ASP .NET Core 1.1

It should come with all required components. The only setup should be the database. This application uses a code-first approach, so to set it up, an update needs to be applied to the database. It is configured to set up a local database, but if you would like to direct it to a database elsewhere, you can modify the appsettings.json file.
The commands to use in the Package Manager Console are as follows:
Update-Database

*This application has, so far, only been run in development mode. Any additional steps necessary for deployment have not been made.*
