## Run the project for the first time
requirements:
- docker
- .net
- visual studio

step-by-step
1. ```docker-compose up```
2. ```npm run create-bucket```
3. cd backend/database
   3.1 ```dotnet ef database update```
4. set your Open-AI API Key in appsetting.json
5. run the project

## How to use the application
This application is a simulation to user input his actions, is enable by default only five actions: Eat; Jump; Walk; Run; Swim.

1. Record a audio saved in .mp3 file
2. POST ```/audio-transcriptions/transcribe``` endpoint, and attach your audio file to be transcribed and formatted to JSON.
3. POST ```action-values``` endpoint to save data in your database

### How the application works






