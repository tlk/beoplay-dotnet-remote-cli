# Experimental .NET BeoplayRemoteCLI

This is an unofficial command line interface (CLI) for .NET to remote control network enabled Beoplay loudspeakers.

Very experimental :-)


```
# Optionally insert the name of one of your devices here
# If the environment variable is not set the application
# will connect to the first device found.
#export DEVICE_NAME="My device"

dotnet run --project ConsoleApp1/BeoplayRemoteCLI.csproj Play
```


## Credits

https://github.com/novotnyllc/Zeroconf