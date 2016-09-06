using System;
using System.Collections.Generic;
using System.IO;
using Run.Pug.Diagnostics;
using Run.Pug.Patterns;

namespace Run.Pug.Resgen
{
    public class NodeBuilder
    {
        private string[] searchDirectories;
        private IPatternMatcher<string> fileNameBlacklist;

        public NodeBuilder(string searchDirectory, IPatternMatcher<string> fileNameBlacklist) 
            : this(new string[] { searchDirectory }, fileNameBlacklist) {}

        public NodeBuilder(string[] searchDirectories, IPatternMatcher<string> fileNameBlacklist)
        {
            this.searchDirectories = searchDirectories;
            this.fileNameBlacklist = fileNameBlacklist;
        }

        public Node Build()
        {
            Node baseNode = new Node(new List<string>());

            foreach (string directory in searchDirectories)
            {
                IEnumerable<string> assetPaths =
                        Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

                foreach (string assetPath in assetPaths)
                {
                    string relativeAssetPath = assetPath.Remove(0, directory.Length);

                    if (IsAssetPathAllowed(relativeAssetPath))
                    {
                        AddRelativeAssetPathToNode(baseNode, relativeAssetPath);
                    }
                }
            }

            return baseNode;
        }

        private Boolean IsAssetPathAllowed(string path)
        {
            return !fileNameBlacklist.IsMatch(path);
        }

        private void AddRelativeAssetPathToNode(Node baseNode, string relativeAssetPath)
        {
            // Split relative path
            string[] entries = relativeAssetPath.Split(
                    new [] { Path.DirectorySeparatorChar },
                    StringSplitOptions.RemoveEmptyEntries);

            // Traverse baseNode, creating subNodes as nessary to mimic the
            // asset's relativePath directories.
            int assetNameIndex = entries.Length - 1;
            Node currentNode = baseNode;
            for (int i = 0; i < assetNameIndex; i++)
            {
                string entry = entries[i];

                bool doesSubNodeExist =
                        currentNode.Subnodes.ContainsKey(entry);
                if (!doesSubNodeExist)
                {
                    List<string> relativePath = new List<string>(entries);
                    relativePath.RemoveAt(assetNameIndex);
                    Node newNode = new Node(relativePath);
                    currentNode.Subnodes.Add(entry, newNode);
                    currentNode = newNode;
                }
                else
                {
                    currentNode.Subnodes.TryGetValue(entry, out currentNode);
                }
            }

            // Determine the name of the asset.
            string assetName = entries[assetNameIndex];
            int periodIndex = assetName.IndexOf('.');
            if (periodIndex >= 0)
            {
                assetName = assetName.Substring(0, periodIndex);
            }

            Preconditions.ensureTrue(assetName.Length > 0, "Asset names must not be empty");

            currentNode.AssetNames.Add(assetName);
        }
    }
}
