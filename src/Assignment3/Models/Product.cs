    namespace Assignment3.Models
{
    /// <summary>
    /// Products
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Gets or initializes unique Id for product.
        /// </summary>
        /// <value>
        /// Guid.
        /// </value>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets or sets Product Id.
        /// </summary>
        /// <value>
        /// Product Id.
        /// </value>
        public string? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// Product name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        /// <value>
        /// Price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        /// <value>
        /// Quantity.
        /// </value>
        public double Quantity { get; set; }

        /// <summary>
        /// Clones objects
        /// </summary>
        /// <returns>Product</returns>
        public Product Clone()
        {
            return new Product
            {
                Id = this.Id,
                ProductId = this.ProductId,
                Name = this.Name,
                Price = this.Price,
                Quantity = this.Quantity,
            };
        }
    }
}