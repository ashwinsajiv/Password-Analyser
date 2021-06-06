## Introduction
This is a .NET project that has two applications. PasswordAnalyser serves as a backend 
and returns the strength and number of breaches of a password using HaveIBeenPwned's API.
PasswordAnalyserConsole is a console application that gets the password from the user on
the console, while 'asteriking' each character. This then communicates with the locally
running backend system and does a POST to the single exposed endpoint to get the strength
and the number of breaches of a password and displays it on the console. 

## Requirements
To run these applications successfully, you will need

    - .NET Framework (preferrably 5.0)
    - Make (optional)

## Installation
If you have Make installed, run the following commands from the project's root.

    - `make`
    - `make run-backend`
    - `make run-frontend`

If you don't have make and want to do it manually, run the following commands. 
1. First `cd PasswordAnalyser`
    - `dotnet restore`
    - `dotnet build`
    - `dotnet run`
2. Second `cd PasswordAnalyserConsole`
    - `dotnet restore`
    - `dotnet build`
    - `dotnet run`

## Testing
To run all the tests, run `make test` from the project's root. 
Again, if no make, `cd PasswordAnalyser` and `dotnet test`

The API has been tested in ./PasswordAnalyser/Controllers and there are more tests under 
./PasswordAnalyser/Services to test the logic of finding the strength and breaches.

## Documentation
Check ./PasswordAnalyser/Swagger for OpenAPI 3 definition of the endpoint.

## Postman
Check ./PasswordAnalyser/Postman for the Postman file.

## Future works
Containerize these applications in Docker so that "but it works on my machine" kind of errors can be avoided. 

