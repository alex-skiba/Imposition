using System;
using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.Logic.Tests.Extensions
{
    public static class TileExtensions
    {
        public static Tile With(this Tile source, Action<Tile> modifier)
        {
            modifier(source);

            return source;
        }
    }
}