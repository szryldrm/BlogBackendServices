#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5010

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["ArticleServices/ArticleServices.csproj", "ArticleServices/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "ArticleServices/ArticleServices.csproj"
COPY . .
WORKDIR "/src/ArticleServices"
RUN dotnet build "ArticleServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArticleServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:5010
ENTRYPOINT ["dotnet", "ArticleServices.dll"]