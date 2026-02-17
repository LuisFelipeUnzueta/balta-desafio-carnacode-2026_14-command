namespace DesignPatternChallenge.Editor;

/// <summary>
/// The Receiver class contains some important business logic. 
/// It knows how to perform all kinds of operations associated with carrying out a request. 
/// In this case, it's the TextEditor that manages the content and cursor.
/// </summary>
public class TextEditor
{
    private string _content = "";
    private int _cursorPosition = 0;

    public string Content => _content;
    public int CursorPosition => _cursorPosition;

    public void InsertText(int position, string text)
    {
        if (position < 0 || position > _content.Length)
            position = _content.Length;

        _content = _content.Insert(position, text);
        _cursorPosition = position + text.Length;
        
        Console.WriteLine($"[Editor] Text inserted: '{text}' at position {position}");
        Console.WriteLine($"[Editor] Current content: '{_content}'");
    }

    public void DeleteText(int position, int length)
    {
        if (position < 0 || position + length > _content.Length)
            return;

        _content = _content.Remove(position, length);
        _cursorPosition = position;

        Console.WriteLine($"[Editor] {length} characters deleted at position {position}");
        Console.WriteLine($"[Editor] Current content: '{_content}'");
    }

    public void SetBold(int start, int length, bool bold)
    {
        string action = bold ? "Applying" : "Removing";
        Console.WriteLine($"[Editor] {action} bold formatting from {start} to {start + length}");
        // Simulation of formatting
    }

    public void SetCursorPosition(int position)
    {
        if (position >= 0 && position <= _content.Length)
        {
            _cursorPosition = position;
        }
    }
}
