#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build-env 
WORKDIR /app
 
# Copy csproj and restore as distinct layers
COPY *.csproj ./ 
RUN dotnet restore
 
# Copy everything else and build
COPY . . 
RUN dotnet publish -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 
WORKDIR /app 
COPY --from=build-env /app/out .
 
# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll 
ENTRYPOINT ["dotnet", "APIGrandstream.dll"]




#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["APIGrandstream/APIGrandstream.csproj", "APIGrandstream/"]
#RUN dotnet restore "APIGrandstream/APIGrandstream.csproj"
#COPY . .
#WORKDIR "/src/APIGrandstream"
#RUN dotnet build "APIGrandstream.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "APIGrandstream.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "APIGrandstream.dll"]