import json
import os
import subprocess
from shutil import copyfile, rmtree


def copyfiles(src, dst):
    files = os.listdir(src)
    for bFile in files:
        src_file = os.path.join(src, bFile)
        dest_file = os.path.join(dst, bFile)
        copyfile(src_file, dest_file)


def fullpath(path):
    return f"{os.getcwd()}\\{path}"


def buildpath(build_folder, path):
    return fullpath(os.path.join(f"build\\{build_folder}", path))


def runWithCWD(cmd, cwd):
    cwd = f"{os.getcwd()}\\{cwd}".replace('/', '\\')
    subprocess.call(cmd, cwd=cwd)


def run(cmd):
    runWithCWD(cmd, "")


def readjson(path):
    with open(path, 'r') as f:
        js = json.loads(f.read())
    return js


def writejson(path, js):
    with open(path, 'w') as f:
        f.write(json.dumps(js, indent=2))


def clear_dependencies(build_folder, assembly_name, references):
    jsonpath = buildpath(build_folder, f"{assembly_name}.deps.json")
    js = readjson(jsonpath)

    # Remove from targets
    dic = dict(js["targets"][".NETCoreApp,Version=v2.1/win-x64"])
    for key in dic.keys():
        for ref in references:
            if "runtime" in dic[key]:
                if list(dic[key]["runtime"].keys())[0].find(ref) >= 0:
                    del js["targets"][".NETCoreApp,Version=v2.1/win-x64"][key]
                    break
            if "dependencies" in dic[key]:
                for depKey in list(dic[key]["dependencies"].keys()):
                    if depKey.find(ref.replace('.dll', '')) >= 0:
                        del js["targets"][".NETCoreApp,Version=v2.1/win-x64"][key]["dependencies"][depKey]

    # Remove from libraries
    dic = dict(js["libraries"])
    for key in dic.keys():
        for ref in references:
            if key.find(f"{ref.replace('.dll', '')}/") >= 0:
                del js["libraries"][key]

    writejson(jsonpath, js)


def process(build_folder, assembly_name, references):
    cmd = [
        "C:/Program Files (x86)/Eziriz/.NET Reactor/dotNET_Reactor.Console.exe",
        "-file", fullpath(f"build/{build_folder}/{assembly_name}.dll"),

        # Options
        "-merge", "1",
        "-control_flow_obfuscation", "1",
        "-flow_level", "9",
        "-merge_namespaces", "1",
        "-mapping_file", "1",
        "-stealth_mode", "1",
        "-all_params", "1",
        "-obfuscate_public_types", "1",

        # Dependencies
        "-satellite_assemblies",
        ";".join([buildpath(build_folder, ref) for ref in references])
    ]

    # Run the Reactor
    run(cmd)

    project_path = fullpath(f"build/{build_folder}")
    secure_path = f"{project_path}/{assembly_name}_Secure"
    copyfiles(secure_path, project_path)

    rmtree(secure_path)

    for ref in references:
        os.remove(buildpath(build_folder, f"{ref}"))

    # Remove unnecessary dependencies
    clear_dependencies(build_folder, assembly_name, references)
