FROM microsoft/dotnet
WORKDIR /server

COPY src/NetAuthServer/NetAuthServer.csproj .
RUN dotnet restore

COPY src/NetAuthServer/* ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/NetAuthServer.dll"]