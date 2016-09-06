using System.Collections.Generic;
using System.Text;

namespace Run.Pug.Resgen
{
    /**
     * A recursive value object used as an intermediate representation of a
     * folder/asset structure.
     */
    public class Node
    {
        public List<string> RelativeDirectoryEntities { get; set; }
        public Dictionary<string, Node> Subnodes { get; set; }
        public HashSet<string> AssetNames { get; set; }

        public int Depth
        {
            get { return RelativeDirectoryEntities.Count; }
        }

        public Node(List<string> relativePath)
        {
            this.RelativeDirectoryEntities = relativePath;
            Subnodes = new Dictionary<string, Node>();
            AssetNames = new HashSet<string>();
        }
    }
}
