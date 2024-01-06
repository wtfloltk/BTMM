#!/bin/bash

ProjectPath="$(dirname "$(readlink -f "$0")")/BTMM/BTMM.csproj"
ReleasePath="bin/Release"

echo "clear $ReleasePath..."
rm -rf "$ProjectPath/$ReleasePath"

TargetPlatforms=("osx-arm64" "osx-x64")

for platform in "${TargetPlatforms[@]}"; do
    echo
    echo "build $platform..."
    dotnet publish "$ProjectPath" -c Release -o "$ProjectPath/$ReleasePath/$platform/" --runtime $platform --self-contained true --framework net6.0 -p:PublishSingleFile=true -p:TrimMode=false
    echo "build $platform success"
done

echo
echo "all build success"
