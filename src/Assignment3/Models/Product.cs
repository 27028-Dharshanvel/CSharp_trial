    namespace Assignment3.Models
{
    /// <summary>
    /// Products
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Gets or sets unique Id for product.
        /// This is used internally by backend.
        /// </summary>
        /// <value>
        /// Guid.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets Product Id.
        /// This is entered by user.
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
        public double Price { get; set; }

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
        /// <returns>Products</returns>
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