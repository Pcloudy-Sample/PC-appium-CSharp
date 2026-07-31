# PC-appium-C-

Sample C# Appium project for running mobile automation tests on pCloudy.

## Overview

This repository is the C# equivalent of the `PC-appium-java-testng` sample. It uses:

- .NET 8
- NUnit as the test runner
- Appium .NET client for mobile automation

The project is set up to launch an Android session on pCloudy, run a basic smoke test, and shut the driver down cleanly.

## Project Structure

- `Android/AndroidPCloudy.csproj` - Android single run
- `Ios/IosPCloudy.csproj` - iOS single run
- `config/*.cs` - platform settings
- `src/*.cs` - platform driver factories
- `tests/*.cs` - platform runner tests

## Prerequisites

- .NET SDK 8.0 or later
- A pCloudy account
- A mobile app uploaded to pCloudy if you want to run against a real app

## Environment Variables

Set these before running the tests:

- `PCLOUDY_USERNAME`
- `PCLOUDY_API_KEY`
- `PCLOUDY_CLOUD_URL` - defaults to `https://device.pcloudy.com`
- `PCLOUDY_APP_PATH`
- `PCLOUDY_DEVICE_NAME`
- `PCLOUDY_DEVICE_MANUFACTURER`
- `PCLOUDY_PLATFORM_NAME` - defaults to `Android`
- `PCLOUDY_PLATFORM_VERSION`

## Run

Single Android:

```bash
dotnet test Android/AndroidPCloudy.csproj
```

Single iOS:

```bash
dotnet test Ios/IosPCloudy.csproj
```

You can also use the helper script:

```powershell
powershell -ExecutionPolicy Bypass -File Run-FromConfig.ps1 -Mode android-single
```

### Example PowerShell setup

```powershell
$env:PCLOUDY_USERNAME="your-username"
$env:PCLOUDY_API_KEY="your-api-key"
$env:PCLOUDY_CLOUD_URL="https://device.pcloudy.com/appiumcloud/wd/hub"
$env:PCLOUDY_APP_PATH="pCloudyAppiumDemo.apk"
$env:PCLOUDY_DEVICE_NAME="your-device-name"
$env:PCLOUDY_DEVICE_MANUFACTURER="ONEPLUS"
$env:PCLOUDY_PLATFORM_NAME="Android"
$env:PCLOUDY_PLATFORM_VERSION="13.0.0"

dotnet test Android/AndroidPCloudy.csproj
```

Use the iOS project path for iPhone or iPad runs:

```powershell
dotnet test Ios/IosPCloudy.csproj
```

## Notes

- The current sample is intentionally small and mirrors the structure of a starter project.
- You can extend it with additional page objects, multiple test classes, and device-specific capabilities as needed.
