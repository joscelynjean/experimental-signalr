# Experimenting SignalR

This project is a simple experimentation of SignalR. Basically, we are building a chat system that is running in-memory on the server side.

Objectives :

 - Demonstrate the use of SignalR

## How to run

### Requirements

 - Visual Studio 2015 update 1 or higher

### Run solution

#### Run the server

In **src/chat-server**, open the **chat-server.sln**. Press F5 or run the application. You can validate that the application is up and running by accessing the following url : http://localhost:8082/signalr/hubs .

#### Run the client

In **src/chat-client**, open the **chat-client.sln**. Press F5 or run the application. You can access the client at the following url : http://localhost:8081/index.html .

### Troubleshooting during development

#### Add the right NuGet package

With the new version of SignalR, we must bootstrap the application by using OWIN. Be sure to get the Microsoft.OWIN NuGet package.

#### Negotiate not found

Before attemps to start connection to hubs, be sure to change the base url :

    $.connection.hub.url = 'http://localhost:8082/signalr'

#### CORS to enable

In the OWIN Startup class, you must enable cors.

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }

I used WebAPI in the same solution and I had to adjust the CORS also but both configuration was in conflict. I had to remove from the WebAPI controller :

    [EnableCors(origins: "*", headers: "*", methods: "*")]

Also, I removed this from the WebAPIConfig.cs :

    config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

**Note : Since this is an experimentation, I didn't bother with the cors but this part must be adjust to whitelist only the hostnames that can access the services.**
