using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Run.Pug.Resgen
{
    public class NodeUtil
    {
        /**
         * Return the relative directory path of a given node formated using
         * the given directorySeperator.
         */
        public static string GetRelativeDirectory(Node node, string directorySeperator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(directorySeperator);

            foreach (string directory in node.RelativeDirectoryEntities)
            {
                sb.Append(directory + directorySeperator);
            }

            return sb.ToString();
        }

        /**
         * Returns the directory of a given node if available otherwise null.
         */
        public static string GetNodeDirectory(Node node)
        {
            if (node.Depth == 0)
            {
                return null;
            }

            return node.RelativeDirectoryEntities[node.Depth - 1];
        }
    }
}
