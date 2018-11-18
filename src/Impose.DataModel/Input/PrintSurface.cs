namespace Albelli.Impose.DataModel.Input
{
    /// <summary>
    /// Simplex or Duplex
    /// For duplex products (PsTumble).
    /// X means that x axis of the back page is reverted.
    /// Y means that y axis of the back page is reverted.
    /// </summary>
    public enum PrintSurface
    {
        /// <summary>
        /// Simplex
        /// </summary>
        Simplex,
        // _________
        // |_F_|_B_|
        DuplexFlipX,
        //_____
        //|_F_|
        //|_B_|
        DuplexFlipY
    }
}
