### Run the project for the first time
requisits:
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

