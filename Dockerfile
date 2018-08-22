FROM microsoft/dotnet:2.1-sdk
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000
WORKDIR todo-mvc-csharp-problem-sankalpjohri
RUN ls
ENTRYPOINT dotnet run