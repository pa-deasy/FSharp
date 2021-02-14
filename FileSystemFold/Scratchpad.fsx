#load "Domain.fs"
#load "Operations.fs"

open FileSystemFold.Domain
open FileSystemFold.Operations


let readme = File { name = "readme.txt"; fileSize = 1 }
let config = File { name = "config.xml"; fileSize = 2 }
let build = File { name = "build.bat"; fileSize = 3 }
let src = Directory { name = "src"; dirSize = 10; subItems = [readme; config; build] }
let bin = Directory { name = "bin"; dirSize = 10; subItems = [] }
let root = Directory { name = "root"; dirSize = 5; subItems = [src; bin] }


readme |> totalSize
src |> totalSize
root |> totalSize

readme |> largestFile
src |> largestFile
bin |> largestFile
root |> largestFile