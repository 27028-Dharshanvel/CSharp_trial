using ConsoleTables;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Console Helper
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Displays any collection as a console table using a custom row selector.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="data">The collection of items to display.</param>
        /// <param name="columnNames">The headers for the table.</param>
        /// <param name="rowSelector">A function to extract row values from an item.</param>
        public static void DisplayTable<T>(IEnumerable<T> data, string[] columnNames, Func<T, object[]> rowSelector)
        {
            if (data == null)
            {
                return;
            }

            var table = new ConsoleTable(columnNames);

            foreach (var item in data)
            {
                table.AddRow(rowSelector(item));
            }

            table.Write();
        }
    }
}
