namespace GoodsStorage
{
    /// <summary>
    /// Class for the item.
    /// </summary>
    public class Item : Node
    {
        public ulong VendorСode { get; set; }
        public uint Amount { get; set; }
        public uint Price { get; set; }
        public string Path { get; set; } = "";
        /// <summary>
        /// Constructor for the item.
        /// </summary>
        /// <param name="name">Item name.</param>
        /// <param name="code">A certain code an article of the element.</param>
        /// <param name="amount">Item quantity.</param>
        /// <param name="price">Item price.</param>
        public Item(string name, ulong code, uint amount, uint price) : base(name)
        {
            Name = name;
            VendorСode = code;
            Amount = amount;
            Price = price;
        }
    }
}
