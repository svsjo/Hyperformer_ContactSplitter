#region

using ContactSplitter.DataStorage.Contracts;

#endregion

namespace ContactSplitter.DataStorage;

public class UserGuidingNotes : IUserGuidingNotes
{
    public string EmptyInput { get; } = "Eingabe darf nicht leer sein";
    public string InvalidCharacter { get; } = "Es werden nur Zeichen des deutschen Tastaturlayouts akzeptiert!";
}