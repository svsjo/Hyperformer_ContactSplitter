#region

using ContactSplitter.DataStorage.Contracts.HelperClasses;

#endregion

namespace ContactSplitter.DataStorage.Contracts;

public interface IProjectSettings
{
    public UiTheme Theme { get; set; }
    public ParserType Parser { get; set; }
}