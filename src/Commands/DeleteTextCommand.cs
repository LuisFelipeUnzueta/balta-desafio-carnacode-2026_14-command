using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge.Commands;

/// <summary>
/// Concrete Command for deleting text.
/// It captures the deleted text so it can be restored during Undo.
/// </summary>
public class DeleteTextCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _length;
    private readonly int _position;
    private string? _deletedText;

    public DeleteTextCommand(TextEditor editor, int position, int length)
    {
        _editor = editor;
        _position = position;
        _length = length;
    }

    public void Execute()
    {
        // To undo a deletion, we must know what was deleted.
        // We capture it from the editor before deleting.
        if (_position >= 0 && _position + _length <= _editor.Content.Length)
        {
            _deletedText = _editor.Content.Substring(_position, _length);
        }
        
        _editor.DeleteText(_position, _length);
    }

    public void Undo()
    {
        if (_deletedText != null)
        {
            _editor.InsertText(_position, _deletedText);
        }
    }
}
