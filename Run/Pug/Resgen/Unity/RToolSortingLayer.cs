using SortingLayer = UnityEngine.SortingLayer;

namespace Run.Pug.Resgen.Unity
{
    public class RToolSortingLayer
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int SortOrder { get; private set; }

        public RToolSortingLayer(int id, string name, int sortOrder)
        {
            ID = id;
            Name = name;
            SortOrder = sortOrder;
        }

        public static implicit operator int(RToolSortingLayer o)
        {
            return o.ID;
        }

        public static implicit operator string(RToolSortingLayer o)
        {
            return o.Name;
        }

        public static implicit operator SortingLayer(RToolSortingLayer o)
        {
            return SortingLayer.layers[o.ID];
        }
    }
}
