using UnitySortingLayer = UnityEngine.SortingLayer;

namespace Run.Pug.Ugh.Unity
{
    public class UghSortingLayer
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int SortOrder { get; private set; }

        public UghSortingLayer(int id, string name, int sortOrder)
        {
            ID = id;
            Name = name;
            SortOrder = sortOrder;
        }

        public static implicit operator int(UghSortingLayer o)
        {
            return o.ID;
        }

        public static implicit operator string(UghSortingLayer o)
        {
            return o.Name;
        }

        public static implicit operator UnitySortingLayer(UghSortingLayer o)
        {
            return UnitySortingLayer.layers[o.ID];
        }
    }
}
