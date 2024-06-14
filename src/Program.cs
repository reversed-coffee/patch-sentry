namespace PatchSentry;

public static class Program {
    internal static ProgramState State = null!;

    [STAThread]
    static void Main() {
        State = new();
        ApplicationConfiguration.Initialize();
        Application.Run(new Forms.ToolboxForm());
    }
}