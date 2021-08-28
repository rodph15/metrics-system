#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /inputmachine
COPY ./bin .
ENTRYPOINT dotnet Metrics.InputMachine.dll