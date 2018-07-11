I have used following library/ tools to create the api:
1. OData standard 
2. Unity container for dependency injection.
3. Entity Framework
3. Divided application in 3 layers
    1. Core which is business layer
    2. Data layer to interact with database
    3. webAPi which handles the routing and call the services.

I have followed code first approach with the EF. Used MSSQLLocalDB to create/access database.
In order to run the application check for the valid connection string and run the application. It will create the db itself.

Due to time constrain I was not able to host the application. Although I still try to host and let you know if it’s done.
If you run it locally or it is hosted. Following url patters will show, add/edit the contact data
http://[hostname]/odata/contacts/
GET will show the contact list.
http://[hostname]/odata/contacts/[key]
POST with contact details will add new contact to db
http://[hostname]/odata/contacts/[key]
PUT/PATCH with contact details will update the contact to db

Reason behind choosing the OData is that as this is a standard any type of client can easily consume and query the entities.
 
