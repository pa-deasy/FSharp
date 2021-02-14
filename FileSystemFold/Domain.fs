module FileSystemFold.Domain

type FileSystemItem =
    | File of File
    | Directory of Directory
and File = { name : string ; fileSize : int }
and Directory = { name : string; dirSize : int; subItems : FileSystemItem list }