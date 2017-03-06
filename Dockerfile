FROM microsoft/dotnet
WORKDIR /server

COPY src/NetAuthServer/* ./
RUN dotnet restore