@echo off

@set inquiry_Reference=

@set ConnectionString="..\ChinookDatabase\bin\Debug\ChinookDatabase.dacpac"
@set engineerRoot=Organization
@set dbName=Chinook
@set Context=Db%dbName%Context
@set ContextNamespace=%engineerRoot%.%dbName%.Repository
@set ContextDir=../%ContextNamespace%
@set Namespace=%engineerRoot%.%dbName%.Table
@set OutputDir=../%Namespace%
@set EFCoreTextTemplatingDir=../EFCore.TextTemplating

@set ToolEnvironmentProjectName=%engineerRoot%.ToolEnvironment
@set ToolEnvironmentProjectFileName=%ToolEnvironmentProjectName%.csproj
@set ToolEnvironmentProjectPath=../%ToolEnvironmentProjectName%
@set ToolEnvironmentProjectProgramFileName=Program.cs
@set ToolEnvironmentProjectDesignTimeServicesFileName=DesignTimeServices.cs

@if exist "%ToolEnvironmentProjectPath%" rd /s /q "%ToolEnvironmentProjectPath%"
@md "%ToolEnvironmentProjectPath%"
@cd "%ToolEnvironmentProjectPath%"

@echo ^<Project Sdk=^"Microsoft.NET.Sdk^"^>  >> "%ToolEnvironmentProjectFileName%"
@echo   ^<PropertyGroup^>  >> "%ToolEnvironmentProjectFileName%"
@echo     ^<OutputType^>Exe^</OutputType^>  >> "%ToolEnvironmentProjectFileName%"
@echo     ^<TargetFramework^>netcoreapp3.1^</TargetFramework^>  >> "%ToolEnvironmentProjectFileName%"
@echo     ^<RootNamespace^>%Namespace%^</RootNamespace^>  >> "%ToolEnvironmentProjectFileName%"
@echo   ^</PropertyGroup^>  >> "%ToolEnvironmentProjectFileName%"
@echo ^</Project^>  >> "%ToolEnvironmentProjectFileName%"

@echo class Program >> "%ToolEnvironmentProjectProgramFileName%"
@echo { >> "%ToolEnvironmentProjectProgramFileName%"
@echo     static void Main^(string[] args^) >> "%ToolEnvironmentProjectProgramFileName%"
@echo     { >> "%ToolEnvironmentProjectProgramFileName%"
@echo     } >> "%ToolEnvironmentProjectProgramFileName%"
@echo } >> "%ToolEnvironmentProjectProgramFileName%"

@echo using Microsoft.EntityFrameworkCore.Design; >> "%ToolEnvironmentProjectDesignTimeServicesFileName%"
@echo // EF Core scans for these while configuring the design-time services. >> "%ToolEnvironmentProjectDesignTimeServicesFileName%"
@echo [assembly: DesignTimeServicesReference(^"EFCore.TextTemplating.DesignTimeServices, EFCore.TextTemplating^")] >> "%ToolEnvironmentProjectDesignTimeServicesFileName%"

@REM https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-package
@REM https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-reference
@dotnet add package Microsoft.EntityFrameworkCore.Design
@REM @dotnet add package Microsoft.EntityFrameworkCore.Tools
@dotnet add package ErikEJ.EntityFrameworkCore.SqlServer.Dacpac --version 3.1.0
@dotnet add reference %EFCoreTextTemplatingDir%

@REM https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
@REM https://docs.microsoft.com/zh-cn/ef/core/miscellaneous/cli/dotnet
@REM @dotnet ef dbcontext scaffold %ConnectionString% ErikEJ.EntityFrameworkCore.SqlServer.Dacpac --data-annotations --context %Context% --context-dir %ContextDir% --context-namespace %ContextNamespace% --output-dir %OutputDir% --namespace %Namespace% -f
@dotnet ef dbcontext scaffold %ConnectionString% ErikEJ.EntityFrameworkCore.SqlServer.Dacpac --data-annotations --context %Context% --context-dir %ContextDir% --output-dir %OutputDir% -f
@if errorlevel 1 (@goto :end)

@cd %~dp0
@if exist "%ToolEnvironmentProjectPath%" rd /s /q "%ToolEnvironmentProjectPath%"

@goto :Reference
:inquiry_Reference
@echo.  
@echo ***是否将项目可能的引用添加或更新至最新版本？***  
@echo （“Y/y”【是】；“N/n”【否】）  
@set /p inquiry_Reference=_请输入：
@echo.  
:Reference
@if /i "%inquiry_Reference%"=="y" (
	@cd %OutputDir%
	@dotnet add package System.ComponentModel.Annotations
	@cd %ContextDir%
	@dotnet add package Microsoft.EntityFrameworkCore
	@dotnet add package ErikEJ.EntityFrameworkCore.SqlServer.Dacpac --version 3.1.0
	@dotnet add reference %OutputDir%
) else (
	@if /i not "%inquiry_Reference%"=="n" (
		@goto :inquiry_Reference
	)
)

@goto :success


@REM -----------------------------------------------------------------------
:end
@echo.  
@echo ***暂停挂起***  
@echo.  
@echo.&pause
@exit /B 1

:success
@set timeout=3
@echo.  
@echo ***等待%timeout%秒***  
@echo.  
@timeout %timeout%
@set timeout=
@exit /B 0