$nugetCLI = "./nuget.exe" 
$msbuild = "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"

if (!(Test-Path $nugetCLI)) {
    Invoke-WebRequest -Uri https://dist.nuget.org/win-x86-commandline/latest/nuget.exe -OutFile $nugetCLI
}

& $msbuild ..\Windows\Facebook.Yoga.Desktop.sln /m:4 /nodeReuse:false /p:Configuration=Release /p:Platform="x64" /t:Build
& $msbuild ..\Windows\Facebook.Yoga.Desktop.sln /m:4 /nodeReuse:false /p:Configuration=Release /p:Platform="x86" /t:Build

.\nuget.exe pack .\Facebook.Yoga.nuspec