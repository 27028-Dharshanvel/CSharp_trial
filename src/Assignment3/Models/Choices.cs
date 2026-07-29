namespace Assignment3.Models
{
    /// <summary>
    /// Choices
    /// </summary>
    public class Choices
    {
        /// <summary>
        /// InventoryOperations
        /// </summary>
        public enum InventoryOperations
        {
            /// <summary>
            /// Adds Products.
            /// </summary>
            AddProducts = 1,

            /// <summary>
            /// Views Products.
            /// </summary>
            ViewProducts,

            /// <summary>
            /// Edits Products.
            /// </summary>
            EditProducts,

            /// <summary>
            /// Deletes Products.
            /// </summary>
            DeleteProducts,

            /// <summary>
            /// Searches products.
            /// </summary>
            SearchProducts,

            /// <summary>
            /// Sorts products.
            /// </summary>
            SortBy,

            /// <summary>
            /// Exits application.
            /// </summary>
            Exit,
        }
    }
}