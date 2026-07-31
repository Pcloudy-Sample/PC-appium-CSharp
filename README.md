<div align="center">

# Run Appium C# Tests on pCloudy

[![pCloudy](https://img.shields.io/badge/Made%20by-pCloudy-1a73e8?style=for-the-badge)](https://www.pcloudy.com)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge)](https://dotnet.microsoft.com/)
[![NUnit](https://img.shields.io/badge/Test%20Runner-NUnit-0E9F6E?style=for-the-badge)](https://nunit.org/)

</div>

## Getting Started

[pCloudy](https://www.pcloudy.com) is a mobile app testing platform that gives you access to real Android and iOS devices directly from your browser. You can use those devices to run manual and automated tests, connect the platform to your CI pipeline, and validate builds on real devices.

This repository is a C# Appium sample that shows how to run mobile automation tests on the pCloudy Real Device Cloud using .NET 8 and NUnit. It includes separate Android and iOS project files, shared configuration helpers, and platform-specific test runners.

## Prerequisites

- .NET SDK 8.0 or later
- A pCloudy account
- A mobile app uploaded to pCloudy if you want to run against a real app

## Project Structure

```text
PC-appium-CSharp/
|-- Android/
|   `-- AndroidPCloudy.csproj
|-- Ios/
|   `-- IosPCloudy.csproj
|-- config/
|   |-- AndroidPCloudySettings.cs
|   |-- IIosPCloudySettings.cs
|   |-- IosPCloudySettings.cs
|   `-- PCloudyEnvironment.cs
|-- src/
|   |-- PCloudyDriverFactory.cs
|   `-- PCloudyIosDriverFactory.cs
|-- tests/
|   |-- AndroidAppRunner.cs
|   `-- IOSAppRunner.cs
|-- Run-FromConfig.ps1
`-- README.md
```

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

## Setup

```powershell
git clone https://github.com/Pcloudy-Sample/PC-appium-CSharp.git
cd PC-appium-CSharp
dotnet restore
```

If you are running from PowerShell, you can set the environment variables for the current session like this:

```powershell
$env:PCLOUDY_USERNAME="your-username"
$env:PCLOUDY_API_KEY="your-api-key"
$env:PCLOUDY_CLOUD_URL="https://device.pcloudy.com/appiumcloud/wd/hub"
$env:PCLOUDY_APP_PATH="pCloudyAppiumDemo.apk"
$env:PCLOUDY_DEVICE_NAME="your-device-name"
$env:PCLOUDY_DEVICE_MANUFACTURER="ONEPLUS"
$env:PCLOUDY_PLATFORM_NAME="Android"
$env:PCLOUDY_PLATFORM_VERSION="13.0.0"
```

## Running the Sample

Single Android run:

```bash
dotnet test Android/AndroidPCloudy.csproj
```

Single iOS run:

```bash
dotnet test Ios/IosPCloudy.csproj
```

You can also use the helper script:

```powershell
powershell -ExecutionPolicy Bypass -File Run-FromConfig.ps1 -Mode android-single
```

```powershell
powershell -ExecutionPolicy Bypass -File Run-FromConfig.ps1 -Mode ios-single
```

## Example PowerShell Session

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

- The sample is intentionally small and mirrors a starter project layout.
- You can extend it with additional test classes, page objects, and device-specific capabilities as needed.
- If you want to run against a real application, make sure `PCLOUDY_APP_PATH` points to an uploaded app on pCloudy.

## How It Works

- `config/` holds the platform settings and environment abstraction.
- `src/` contains the driver factories that create Appium sessions.
- `tests/` contains the NUnit runner classes for Android and iOS.
- `Run-FromConfig.ps1` is a small helper for launching the correct `dotnet test` command.

## Extending the Project

- Add more test methods in `tests/AndroidAppRunner.cs` and `tests/IOSAppRunner.cs`.
- Centralize reusable Appium actions in helper classes under `src/`.
- Expand the `config/` layer if you need device selection rules or more environment-driven behavior.
- Add more `.csproj` files if you want separate execution paths for additional platforms or variants.

## Support

If you need to adjust capabilities or add more platform-specific options, update the configuration classes in `config/` and the driver factories in `src/`.

## API Documentation

For the full pCloudy REST API reference (device booking, app upload, reports, and more), see:

- [pCloudy API Documentation](https://content.pcloudy.com/apidocs/index.html)

## Learn More

- [pCloudy Website](https://www.pcloudy.com)
- [Appium Integration on pCloudy](https://www.pcloudy.com/appium-integration-architecture-redefined-appium-runs-become-simpler-with-pcloudy/)

## Contributions

Contributions are welcome. Please open an issue to discuss your idea before submitting a pull request.
