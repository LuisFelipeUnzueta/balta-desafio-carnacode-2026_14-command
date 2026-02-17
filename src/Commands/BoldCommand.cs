using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge.Commands;

/// <summary>
/// Concrete Command for applying bold formatting.
/// </summary>
public class BoldCommand : ICommand
{
    private readonly TextEditor _editor;
    private readonly int _start;
    private readonly int _length;

    public BoldCommand(TextEditor editor, int start, int length)
    {
        _editor = editor;
        _start = start;
        _length = length;
    }

    public void Execute()
    {
        _editor.SetBold(_start, _length, true);
    }

    public void Undo()
    {
        _editor.SetBold(_start, _length, false);
    }
}
