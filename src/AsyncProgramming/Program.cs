namespace AsyncProgramming;

/// <summary>
/// Program class
/// </summary>
internal class Program
{
    /// <summary>
    /// Main entry point for the application.
    /// </summary>
    /// <param name="args">CMD line args</param>
    /// <returns>Task</returns>
    public static async Task Main(string[] args)
    {
        await MainMenu.DisplayMainMenu();
    }
}