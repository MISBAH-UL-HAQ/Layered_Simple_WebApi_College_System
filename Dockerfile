# -------- 1) BUILD STAGE --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1.1 Copy everything
COPY . .

# 1.2 Restore & publish your Web API in one go
RUN dotnet restore CollegeSystem2/CollegeSystem2.csproj
RUN dotnet publish  CollegeSystem2/CollegeSystem2.csproj \
    -c Release -o /app/publish

# -------- 2) RUNTIME STAGE --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 2.1 Copy the published app
COPY --from=build /app/publish .

# 2.2 Listen on port 80 internally
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80


ENTRYPOINT ["dotnet", "CollegeSystem2.dll"]
