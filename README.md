Prerequisites:
- .Net 8 SDK
- VS 20222 17.8.6
- MS SQL server with Blog db
- executed Blog.sql

The solution file in in the BlogAPI folder.
The API is configured to use the localhost MS SQL db server. You may change the connection string in the appsettings.Development.json in the BlogAPI project.
You need to create a database called Blog and run the Blog.sql script attached in this folder.
The integration tests use the in memeory db.
I have made the the e2e testing with Postman.