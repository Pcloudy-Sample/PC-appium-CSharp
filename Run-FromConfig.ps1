param(
    [Parameter(Mandatory = $true)]
    [ValidateSet("android-single", "ios-single")]
    [string]$Mode
)

$map = @{
    "android-single" = "Android/AndroidPCloudy.csproj"
    "ios-single" = "Ios/IosPCloudy.csproj"
}

dotnet test $map[$Mode]
