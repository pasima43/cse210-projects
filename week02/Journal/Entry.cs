// Entry.cs
public interface IEntry
{
    string Prompt { get; set; }
    string Response { get; set; }
    string Date { get; set; }

    string ToString();
}

public class NewBaseType
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public override string ToString()
    {
        return $"Date: {Date}\\nPrompt: {Prompt}\\nResponse: {Response}\\n";
    }
}

public class Entry : NewBaseType, IEntry
{
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}