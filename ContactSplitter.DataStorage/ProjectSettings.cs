#region

using ContactSplitter.DataStorage.Contracts;
using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactSplitter.DataStorage;

public class ProjectSettings : IProjectSettings
{
    public UiTheme Theme { get; set; } = UiTheme.Dunkel;
    public ParserType Parser { get; set; } = ParserType.Offline;
}