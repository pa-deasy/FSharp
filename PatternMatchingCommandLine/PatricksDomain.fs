module PatternMatchingCommandLine.PatricksDomain

type Flag = 
    | Disabled
    | Enabled

type OrderBy =
    | Name
    | Size

type CommandLineOption =
    | Verbose of Flag
    | Subdir of Flag
    | Order of OrderBy

