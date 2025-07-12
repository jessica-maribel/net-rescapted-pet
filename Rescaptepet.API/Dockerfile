FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY ../ ./
RUN dotnet restore "Rescaptepet.API/Rescaptepet.API.csproj"
RUN dotnet publish "Rescaptepet.API/Rescaptepet.API.csproj" -c Release -o /out

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .
EXPOSE 5139
ENTRYPOINT ["dotnet", "Rescaptepet.API.dll"]