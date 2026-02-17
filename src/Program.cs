using DesignPatternChallenge.Commands;
using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Text Editor - Command Pattern Implementation ===\n");

        // The Receiver
        var editor = new TextEditor();
        
        // The Invoker (holds history)
        var manager = new CommandManager();

        Console.WriteLine("--- Performing Actions ---");
        
        // Action 1: Type "Hello"
        manager.Execute(new InsertTextCommand(editor, 0, "Hello"));
        
        // Action 2: Type " World"
        manager.Execute(new InsertTextCommand(editor, 5, " World"));
        
        ShowStatus(editor);

        // Action 3: Make "Hello" bold
        manager.Execute(new BoldCommand(editor, 0, 5));

        // Action 4: Delete " World"
        manager.Execute(new DeleteTextCommand(editor, 5, 6));
        
        ShowStatus(editor);

        Console.WriteLine("--- Testing Undo ---");
        
        // Undo Delete " World"
        Console.WriteLine("\n[Undo] Reverting deletion:");
        manager.Undo();
        ShowStatus(editor);

        // Undo Bold
        Console.WriteLine("\n[Undo] Reverting bold:");
        manager.Undo();

        // Undo Type " World"
        Console.WriteLine("\n[Undo] Reverting second insert:");
        manager.Undo();
        ShowStatus(editor);

        Console.WriteLine("--- Testing Redo ---");
        
        // Redo Type " World"
        Console.WriteLine("\n[Redo] Re-applying second insert:");
        manager.Redo();
        ShowStatus(editor);

        // Redo Bold
        Console.WriteLine("\n[Redo] Re-applying bold:");
        manager.Redo();

        Console.WriteLine("\n=== Implementation Reflection ===");
        // Reflection Answers:
        // - How to encapsulate operations as objects? 
        //   By creating classes that implement a common ICommand interface.
        // - How to parameterize, queue and record requests? 
        //   Commands are objects that store parameters. They can be stored in lists or stacks.
        // - How to implement reversible operations (undo)? 
        //   Each command implementation knows how to reverse its own Execute() logic in its Undo() method.
        // - How to decouple command sender from executor? 
        //   The sender (Invoker/Manager) only calls ICommand methods, not knowing what the receiver (Editor) is doing.
    }

    static void ShowStatus(TextEditor editor)
    {
        Console.WriteLine($"\n>> Current Content: '{editor.Content}'");
        Console.WriteLine($">> Cursor Position: {editor.CursorPosition}\n");
    }
}
