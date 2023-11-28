if (Test-Path publish) {
    Remove-Item -Recurse -Force publish
}
dotnet publish -c Release -o publish -p:PublishSingleFile=true --self-contained false