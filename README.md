Price beating project
-------------------------------------
Project list:  
    
    1. project API, based on dotnet core framework
    2. beater simulator, dotnet console application
    3. front end interface for real user, created on ReactJS

Database:
    
    MongoDB is used to develope this project. In appsettings.json of TaskAPI must be included MongoDB database connection settings:
    
    "MongoDBConnection": {
        "CollectionName": "beat",
        "ConnectionString": "mongodb://localhost:27017",
        "DatabaseName": "BeatDB"
    }

Required tools:
    
    TaskAPI
        DotNetCore 3.0.1
        MongoDB.Driver 2.10.0
    
    TaskWeb       
        ReactJS 16.12.0 
        > npm install jquery
        > npm install datatables.net

Using project:
    
    1. TaskAPI - start debugging
        > cd /path/to/TaskAPI
        > dotnet run
    
    2. Beater - to create simulated user, you must locate inside of project folder, run console application in console, and give a name to virtual user.  
        > cd /path/to/Beater 
        > dotnet run        
        Insert your name: Xxxx

    3. TaskWeb - run react project
        > npm start
