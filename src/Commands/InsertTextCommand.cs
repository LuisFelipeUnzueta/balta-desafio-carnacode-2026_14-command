using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge.Commands;

/// <summary>
/// Concrete Command for inserting text.
/// It stores the necessary information to undo the operation.
/// </summary>
public class InsertTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly string _text;
    private readonly int _position;

    public InsertTextCommand(TextEditor editor, int position, string text)
    {
        _editor = editor;
        _position = position;
        _text = text;
    }

    public void Execute()
    {
        _editor.InsertText(_position, _text);
    }

    public void Undo()
    {
        _editor.DeleteText(_position, _text.Length);
    }
}
