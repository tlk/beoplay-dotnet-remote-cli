# Experimental .NET BeoplayRemoteCLI

This is an unofficial command line interface (CLI) for .NET to remote control network enabled Beoplay loudspeakers.

Very experimental :-)

Example:
```
$ ./BeoplayRemoteCLI.exe Play
$ ./BeoplayRemoteCLI.exe Pause
```


## Tinker with it

#### Install the dotnet SDK
See https://docs.microsoft.com/en-us/dotnet/core/install/

Install the SDK if running on WSL2/Ubuntu:
```
sudo apt install dotnet-sdk-6.0
```

#### Configuration
Optionally, set the name of one of your devices in an environment variable.
If the environment variable is not set the application will connect to the first device it finds.
```
export DEVICE_NAME="My device"
```

#### Compile and run the application
The application will send simple commands to the remote device.
Simple commands are: Play, Pause, Stop, Forward, Backward.
It is also possible to get the current volume with the GetVolume command.

Example:
```
dotnet run --project ConsoleApp1/BeoplayRemoteCLI.csproj Play
dotnet run --project ConsoleApp1/BeoplayRemoteCLI.csproj GetVolume
```

#### Edit the code
Open the project in Visual Studio 2022 Community edition:
https://visualstudio.microsoft.com/vs/community/


## Credits

https://github.com/novotnyllc/Zeroconf
