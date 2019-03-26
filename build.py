import os
import subprocess
import reactor

def runWithCWD(cmd, cwd):
    cwd = f"{os.getcwd()}/{cwd}".replace('/', '\\')
    subprocess.call(cmd, cwd=cwd)


runWithCWD("dotnet publish -c Release --self-contained --runtime win-x64 --no-dependencies", "SteamFakePlayer")

reactor.process("Joiner", "SteamFakePlayer", [
    "Facepunch.Network.dll",
    "Facepunch.System.dll",
    "Assembly-CSharp.dll",
    "UnityEngine.CoreModule.dll",
    "SapphireEngine.dll",
    "Rust.Data.dll",
    "Sentry.dll",
    "Sentry.Protocol.dll"
])
