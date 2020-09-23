@echo off

@set migrationsScriptFrom=""

@set engineerRoot=Organization
@set dbName=Chinook
@set Context=Db%dbName%Context
@set ContextNamespace=%engineerRoot%.%dbName%.Repository
@set ContextDir=../%ContextNamespace%

@set EFCoreOverviewProjectName=EFCore.Overview
@set EFCoreOverviewProjectFileName=%EFCoreOverviewProjectName%.csproj
@set EFCoreOverviewProjectPath=../%EFCoreOverviewProjectName%
@set EFCoreOverviewProjectProgramFileName=Program.cs
@set EFCoreOverviewProjectDbContextMirroringName=%Context%Mirroring
@set EFCoreOverviewProjectDbContextMirroringFileName=%EFCoreOverviewProjectDbContextMirroringName%.cs

@set flagIndex=0
@set inquiryValue%flagIndex%=inquiry_Archive
@set inquiryText%flagIndex%=迁移现有配置和模型并归档
@set /a flagIndex+=1
@set inquiryValue%flagIndex%=inquiry_Script
@set inquiryText%flagIndex%=将现有已归档的迁移生成SQL脚本
@set /a flagIndex+=1
@set inquiryValue%flagIndex%=inquiry_Update
@set inquiryText%flagIndex%=将现有已归档的迁移同步至数据库
@set /a flagIndex+=1
@set flagLength=%flagIndex%
:load_DefaultSelectionMode
@echo.  
@echo ***请选择模式***  
@set flagValues=0
@set flagIndex=0
:setFlageValue
@set /a flagValue=1 "<<" %flagIndex%
@set flagValue%flagIndex%=%flagValue%
@if %flagValue% NEQ 2 (

@set /a flagValues "|=" %flagValue%

)
@call set inquiryText=%%inquiryText%flagIndex%%%
@set option%flagIndex%=选项%flagIndex%：【%flagValue%】%inquiryText%  
@call echo %%option%flagIndex%%%
@set /a flagIndex+=1
@if %flagIndex% LSS %flagLength% (@goto :setFlageValue)
@echo （使用按位或进行多项选择）  
@echo （默认为选择【%flagValues%】，键入-1则所有选项在遭遇时选择）  
@VERIFY OTHER 2>nul
@SETLOCAL ENABLEEXTENSIONS
@IF ERRORLEVEL 1 (
	@ECHO Unable to enable extentsions
	@REM @GOTO :end
	@GOTO :inquiry_DefaultSelectionMode
)
@IF DEFINED inquiry_DefaultSelectionMode (
	@GOTO :SelectionMode
)
@ENDLOCAL
:inquiry_DefaultSelectionMode
@set /p inquiry_DefaultSelectionMode=_请输入：
@echo.  
:SelectionMode
@if	/i "%inquiry_DefaultSelectionMode%"=="-1" (@goto :ExecuteStart)
@if "%inquiry_DefaultSelectionMode%"=="" (
	@set inquiry_DefaultSelectionMode=%flagValues%
)
@set flagIndex=0
:setInquiryValue
@set /a flagValue="flagValue%flagIndex%"
@call set inquiryValue=%%inquiryValue%flagIndex%%%
@call set inquiryText=%%inquiryText%flagIndex%%%
@set /a flag=%inquiry_DefaultSelectionMode% "&" %flagValue%
@if %flag%==%flagValue% (
	@set %inquiryValue%=y
	@call echo 已选择：%%option%flagIndex%%%
) else (
	@set %inquiryValue%=n
)
@set /a flagIndex+=1
@if %flagIndex% LSS %flagLength% (@goto :setInquiryValue)
@goto :ExecuteStart

:ExecuteStart

@if not exist "%EFCoreOverviewProjectPath%" md "%EFCoreOverviewProjectPath%"
@cd "%EFCoreOverviewProjectPath%"

@if not exist "%EFCoreOverviewProjectProgramFileName%" (

@echo class Program >> "%EFCoreOverviewProjectProgramFileName%"
@echo { >> "%EFCoreOverviewProjectProgramFileName%"
@echo     static void Main^(string[] args^) >> "%EFCoreOverviewProjectProgramFileName%"
@echo     { >> "%EFCoreOverviewProjectProgramFileName%"
@echo     } >> "%EFCoreOverviewProjectProgramFileName%"
@echo } >> "%EFCoreOverviewProjectProgramFileName%"

)

@if not exist "%EFCoreOverviewProjectFileName%" (

@echo ^<Project Sdk=^"Microsoft.NET.Sdk^"^>  >> "%EFCoreOverviewProjectFileName%"
@echo   ^<PropertyGroup^>  >> "%EFCoreOverviewProjectFileName%"
@echo     ^<OutputType^>Exe^</OutputType^>  >> "%EFCoreOverviewProjectFileName%"
@echo     ^<TargetFramework^>netcoreapp3.1^</TargetFramework^>  >> "%EFCoreOverviewProjectFileName%"
@echo   ^</PropertyGroup^>  >> "%EFCoreOverviewProjectFileName%"
@echo ^</Project^>  >> "%EFCoreOverviewProjectFileName%"

@REM https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-package
@REM https://docs.microsoft.com/zh-cn/dotnet/core/tools/dotnet-add-reference
@dotnet add package Microsoft.EntityFrameworkCore.Design
@REM @dotnet add package Microsoft.EntityFrameworkCore.Tools
@dotnet add reference %ContextDir%

)

@if not exist "%EFCoreOverviewProjectDbContextMirroringFileName%" (

@echo namespace %EFCoreOverviewProjectName% >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo { >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo     using %ContextNamespace%; >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo:>> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo     class %EFCoreOverviewProjectDbContextMirroringName% : %Context% >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo     { >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo     } >> "%EFCoreOverviewProjectDbContextMirroringFileName%"
@echo } >> "%EFCoreOverviewProjectDbContextMirroringFileName%"

)

@goto :Archive
:inquiry_Archive
@echo.  
@echo ***是否迁移现有配置和模型并归档？***  
@echo （“Y/y”【是】；“N/n”【否】）  
@set /p inquiry_Archive=_请输入：
@echo.  
:Archive
@set timestamp=%date:~0,4%%date:~5,2%%date:~8,2%0%time:~1,1%%time:~3,2%%time:~6,2%
@if /i "%inquiry_Archive%"=="y" (
	@REM https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/
	@REM https://docs.microsoft.com/zh-cn/ef/core/miscellaneous/cli/dotnet
	@dotnet ef migrations add Archive%timestamp%
	@if errorlevel 1 (@goto :end)
) else (
	@if /i not "%inquiry_Archive%"=="n" (
		@goto :inquiry_Archive
	)
)

@goto :Script
:inquiry_Script
@echo.  
@echo ***是否将现有已归档的迁移生成SQL脚本？***  
@echo （“Y/y”【是】；“N/n”【否】）  
@set /p inquiry_Script=_请输入：
@echo.  
:Script
@if "%timestamp%"=="" ( @set timestamp=%date:~0,4%%date:~5,2%%date:~8,2%0%time:~1,1%%time:~3,2%%time:~6,2% )
@if /i "%inquiry_Script%"=="y" (
	@REM https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/applying#sql-scripts
	@REM @dotnet ef migrations script --idempotent
	@if "%migrationsScriptFrom%"=="" (
		@dotnet ef migrations script --output %timestamp%.sql --idempotent
		@if errorlevel 1 (@goto :end)
	) else (
		@dotnet ef migrations script %migrationsScriptFrom% --output %migrationsScriptFrom%.sql
		@if errorlevel 1 (@goto :end)
		@dotnet ef migrations script %migrationsScriptFrom%
		@pause
	)
) else (
	@if /i not "%inquiry_Script%"=="n" (
		@goto :inquiry_Script
	)
)

@goto :Update
:inquiry_Update
@echo.  
@echo ***是否将现有已归档的迁移同步至数据库？***  
@echo （“Y/y”【是】；“N/n”【否】）  
@set /p inquiry_Update=_请输入：
@echo.  
:Update
@if /i "%inquiry_Update%"=="y" (
	@dotnet ef database update
	@if errorlevel 1 (

@echo EF Core `update-database` on MySql fails with `__EFMigrationsHistory' doesn't exist`
@echo https://stackoverflow.com/questions/46089982/ef-core-update-database-on-mysql-fails-with-efmigrationshistory-doesnt-ex
@echo:
@echo CREATE TABLE `__EFMigrationsHistory` 
@echo ^( 
@echo     `MigrationId` nvarchar^(150^) NOT NULL, 
@echo     `ProductVersion` nvarchar^(32^) NOT NULL, 
@echo      PRIMARY KEY ^(`MigrationId`^) 
@echo ^);
@echo:

@echo EF Core Overview table already exists
@echo https://stackoverflow.com/questions/38128534/ef-migration-object-already-exists-error/47193842
@echo:
@echo Execute 'dotnet EF Database Update' after UP and Down in annotated Migration
@echo:

	@goto :end
	)
) else (
	@if /i not "%inquiry_Update%"=="n" (
		@goto :inquiry_Update
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