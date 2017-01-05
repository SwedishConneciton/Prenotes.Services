# Prenotes.Services
[Prenotes](http://swedishconnection.github.io/Prenotes/) has services that aren't tied to how a user interacts with the application.  The Prenotes [Rest](https://github.com/SwedishConneciton/Prenotes.Rest) repository is the default interaction with the browser but eventually we want daycare to use smart voice (i.e. Echo from Amazon, Home from Google or similar).  The services here put and grab information from a graph database.  Any changes to state will be echoed to a commit log for stuff like statistical analysis or trending (i.e. how often does daycare report stomach flu).

Services are written in C# on Asp Net Core (1.1 at the time of writing).  The graph database will be Neo4j simply because it is cool and has roots from southern Sweden.
