namespace ContactSplitter.DataStorage.HelperClasses;

public class Title
{
    public string MaleTitle { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string FemaleTitle => MaleTitle + "in";
    public string GenericTitle => MaleTitle + "en" + " und " + MaleTitle + "innen";

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