import os
import subprocess

def runWithCWD(cmd, cwd):
	cwd = (os.getcwd() + "/"+ cwd).replace('/', '\\')
	subprocess.call(cmd, cwd=cwd)

runWithCWD("dotnet publish -c Release --self-contained --no-build --runtime win-x64", "SteamFakePlayer")