FROM mcr.microsoft.com/dotnet/aspnet:8.0 As base
WORKDIR /app
EXPOSE 8080
eNv ASPNETCORE_URLS=http://+8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 As build
WORKDIR /src
COPY . .
RUN dotnet restore "CalingacionLibraryNowAPI/CalingacionLibraryNowAPI.csproj"
RUN dotnet publish "CalingacionLibraryNowAPI/CalingacionLibraryNowAPI.csproj" -c Release -o /app/out

FROm base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "CalingacionLibraryNowAPI.dll"]
