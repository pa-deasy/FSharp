module FileSystemFold.Operations

open FileSystemFold.Domain

let rec foldFS fFile fDir acc item : 'r =
    let recurse = foldFS fFile fDir
    match item with
    | File file ->
        fFile acc file
    | Directory dir ->
        let newAcc = fDir acc (dir.name, dir.dirSize)
        dir.subItems |> List.fold recurse newAcc

let totalSize fileSystemItem = 
    let fFile acc (file : File) =
        acc + file.fileSize
    let fDir acc (name, size) =
        acc + size
    foldFS fFile fDir 0 fileSystemItem


let largestFile fileSystemItem =
    let fFile (largestFileSoFarOpt : File option) (file : File) =
        match largestFileSoFarOpt with
        | None ->
            Some file
        | Some largestFileSoFar ->
            if largestFileSoFar.fileSize > file.fileSize then
                Some largestFileSoFar
            else
                Some file

    let fDir largestFileSoFarOpt (name, size) = 
        largestFileSoFarOpt

    foldFS fFile fDir None fileSystemItem