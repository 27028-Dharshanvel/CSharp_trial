namespace Reflections
{
    /// <summary>
    /// Plugin interface
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        string Name { get; }

        /// <summary>
        /// Execution method
        /// </summary>
        void Execute();
    }
}
