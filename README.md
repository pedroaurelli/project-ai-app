## Run the project for the first time
requirements:
- [Docker](https://www.docker.com/products/docker-desktop/)
- [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)

step-by-step:
1. ```docker-compose up```
2. ```npm run create-bucket```
3. cd backend/database. ```dotnet ef database update```
4. set your Open-AI API Key in appsetting.json
5. run the project. Swagger running at https://localhost:7276/swagger/index.html

## How to use the application
This application is a simulation to user input his actions, is enable by default only five actions: Eat; Jump; Walk; Run; Swim.

1. Record a audio saved in .mp3 file
2. POST ```/audio-transcriptions/transcribe``` endpoint, and attach your audio file to be transcribed and formatted to JSON.
3. POST ```action-values``` endpoint to save data in your database

## How the application works
It´s simple, your attached audio file will be transcribed and save to a s3 bucket. The transcription will be saved in database in plain-text, and only the result of endpoint returns a JSON formatted from your transcription audio.
Then, your transcribed JSON formatted audio can be send to ```action-values``` endpoint to be storage on database.






