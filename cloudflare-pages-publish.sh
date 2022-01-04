# Get the emsdk repo
git clone https://github.com/emscripten-core/emsdk.git
./emsdk/emsdk install latest
./emsdk/emsdk activate latest
source ./emsdk/emsdk_env.sh

curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh;
chmod +x dotnet-install.sh;
./dotnet-install.sh -c 6.0 -InstallDir ./dotnet6;
./dotnet6/dotnet --version;
./dotnet6/dotnet workload install wasm-tools
./dotnet6/dotnet publish libanvl.monkey/libanvl.monkey.csproj -c Release -o output;
