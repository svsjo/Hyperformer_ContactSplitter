namespace ContactSplitter.DataStorage.HelperClasses;

public class Title
{
    public string MaleTitle { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string FemaleTitle => IsGeneric ? MaleTitle : MaleTitle + "in";
    public string GenericTitle => IsGeneric ? MaleTitle : MaleTitle + "en" + " und " + MaleTitle + "innen";
    public bool IsGeneric { get; set; } = false;

    public string GetFormattedTitle(string gender)
    {
        return gender switch
        {
            "M" => MaleTitle,
            "F" => FemaleTitle,
            _ => GenericTitle,
        };
    }
}