namespace LanguageInetgratedQuery.Models
{
    /// <summary>
    /// Product class
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Gets or sets productID
        /// </summary>
        /// <value>
        /// ProductID
        /// </value>
        public string? ProductId { get; set; }

        /// <summary>
        /// Gets or sets productName
        /// </summary>
        /// <value>
        /// ProductName
        /// </value>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets product Catgeory
        /// </summary>
        /// <value>
        /// ProductCategory
        /// </value>
        public string? ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets product Price
        /// </summary>
        /// <value>
        /// ProductPrice
        /// </value>
        public double ProductPrice { get; set; }
    }
}
