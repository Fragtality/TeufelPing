# TeufelPing

## Description
A small Tool that prevents [Teufel Speakers](https://teufel.de/) from going into Standby while the Computer is running (can be used for any Speaker Systems, not specific to Teufel). Every 10 Minutes it plays the included "SilentNoise" Wave-File so that the Speaker-System receives an Input. The Wave-File is 5 Seconds of a 22kHz Sine-Wave - so it is not hearable for Human Ears (maybe some Pets won't like it).<br/>
Runs only on Windows and needs the [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) installed.
<br/><br/>

## Installation
Install the [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) if not already installed.<br/>
Unzip it anywhere you like and execute it. Maybe some AV-Scanners don't like it since it does not have an official Signature. You may need to define an Exclusion in your AV-Scanner.<br/>
It does not have a Window and can only be killed via Task Manager (it is intended to be stopped by Windows on Shutdown).<br/>
If you would like to start it automatically with Windows:
- Press the Windows+R Keys
- Type ```shell:startup```
- Create a Link to the Executable in the Window that opened
<br/>

## Configuration
By Default, the Wave-File is played on the Default Output Device configured in Windows. So if you change that (e.g. switching to a Headset) the Sound will not be played on the Speaker System anymore. If you have such Scenarios and want still prevent the Speaker System to go into Standby, you have to configure the Tool:
- Every Time it runs, it will create a File called "devices.txt" in its Folder
- Open that File and copy the Name of the Device where you Speaker System is connected (without [] !)
- Create a new File called "device.cfg" and paste the Name there (only one Line and just the Name)
- Stop and Start the Tool. It will now playback the Wave-File on the same Device, even if you switch the Default Output Device in Windows
<br/>

## Disclaimer
This Software is provided as-is without Warranty of any Kind. It is not an offical Software by Lautsprecher Teufel GmbH.
