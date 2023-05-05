namespace ContactSplitter.DataStorage.HelperClasses;

public class Title
{
    public string MaleTitle { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string FemaleTitle => IsGeneric ? MaleTitle : MaleTitle + "in";
    public string GenericTitle => IsGeneric ? MaleTitle : MaleTitle + "en" + " und " + MaleTitle + "innen";
    public bool IsGeneric { get; set; } = false;

    public bool TryGetGender(string title, out string gender)
    {
        gender = string.Empty;
        if (title == MaleTitle)
        {
            gender = "M";
            return true;
        }

        if (title == FemaleTitle)
        {
            gender = "F";
            return true;
        }

        return false;
    }
}