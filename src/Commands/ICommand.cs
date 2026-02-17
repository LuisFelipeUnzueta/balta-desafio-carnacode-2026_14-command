namespace DesignPatternChallenge.Commands;

/// <summary>
/// The Command interface declares a method for executing a command.
/// It also includes an Undo method for reversible operations.
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}
