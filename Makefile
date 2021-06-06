all: clean restore build

clean:
	cd PasswordAnalyser && dotnet clean
	cd PasswordAnalyserConsole && dotnet clean

restore:
	cd PasswordAnalyser && dotnet restore
	cd PasswordAnalyserConsole && dotnet restore

build: 
	cd PasswordAnalyser && dotnet build
	cd PasswordAnalyserConsole && dotnet build

run-backend:
	cd PasswordAnalyser && dotnet run

run-frontend:
	cd PasswordAnalyserConsole && dotnet run
