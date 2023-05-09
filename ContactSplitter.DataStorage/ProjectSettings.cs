using ContactSplitter.DataStorage.HelperClasses;

namespace ContactSplitter.DataStorage;

public class ProjectSettings
{
    public UiTheme Theme { get; set; } = UiTheme.Dunkel;
    public ParserType Parser { get; set; } = ParserType.Offline;
}