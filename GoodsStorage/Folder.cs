using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoodsStorage
{
    /// <summary>
    /// Class for the folder.
    /// </summary>
    [DataContract]
    public class Folder : Node
    {
        [DataMember]
        public List<Item> AllItems { get; set; } = new List<Item>();
        [DataMember]
        public List<Folder> AllFolders { get; set; } = new List<Folder>();
        // A list for storing all inner elements.
        [JsonIgnore]
        public List<Node> AllNodes = new List<Node>();
        // The folder name was not saved, so I had to make a crutch.
        [DataMember]
        public string FolderName { get { return this.Name; } set { this.Name = value; } }
        public Folder(string name) : base(name)
        {
            Name = name;
        }
        
    }
}
