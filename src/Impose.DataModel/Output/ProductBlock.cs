namespace Albelli.Impose.DataModel.Output
{
    /// <summary>
    /// Describes product block: number of tiles to be kept (delivered to output conveyor) and waste (removed after cutting)
    /// </summary>
    public class ProductBlock
    {
        public ProductBlock(int size, int waste)
        {
            Size = size;
            Waste = waste;
        }

        public int Size { get; set; }
        public int Waste { get; set; }
    }
}
