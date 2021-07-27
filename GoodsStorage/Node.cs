using System.Runtime.Serialization;

namespace GoodsStorage
{
    /// <summary>
    /// The parent class for folders and items, so that you can store them in a single sheet.
    /// </summary>
    public class Node
    {
        [DataMember]
        public string Name { get; set; }
        public Node(string name)
        {
            Name = name;
        }
    }
}
