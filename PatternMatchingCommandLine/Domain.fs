module PatternMatchingCommandLine.Domain

type OrderByOption = OrderBySize | OrderByName

type SubdirectoryOption = IncludeSubDirectories | ExcludeSubdirectories

type VerboseOption = VerboseOutput | TerseOutput

type CommandLineOptions = {
    orderBy : OrderByOption;
    subdirectories : SubdirectoryOption;
    verbose : VerboseOption
}

