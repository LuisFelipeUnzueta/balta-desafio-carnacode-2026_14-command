namespace DesignPatternChallenge.Commands;

/// <summary>
/// The Invoker class is associated with one or several commands. 
/// It sends a request to the command.
/// It also manages the history of commands to support Undo and Redo operations.
/// </summary>
public class CommandManager
{
    private readonly Stack<ICommand> _undoStack = new();
    private readonly Stack<ICommand> _redoStack = new();

    /// <summary>
    /// Executes a command and adds it to the undo history.
    /// </summary>
    public void Execute(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear(); // New operation invalidates redo history
    }

    /// <summary>
    /// Reverts the last executed command.
    /// </summary>
    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
            _redoStack.Push(command);
        }
        else
        {
            Console.WriteLine("[Manager] Nothing to undo.");
        }
    }

    /// <summary>
    /// Re-executes the last undone command.
    /// </summary>
    public void Redo()
    {
        if (_redoStack.Count > 0)
        {
            var command = _redoStack.Pop();
            command.Execute();
            _undoStack.Push(command);
        }
        else
        {
            Console.WriteLine("[Manager] Nothing to redo.");
        }
    }
}
