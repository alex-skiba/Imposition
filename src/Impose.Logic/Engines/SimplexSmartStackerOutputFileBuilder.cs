using System;
using System.Collections.Generic;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Engines
{
    public class SimplexSmartStackerOutputFileBuilder : IOutputFileBuilder
    {
        private readonly Imposition _imposition;
        private readonly Layout _layout;

        public SimplexSmartStackerOutputFileBuilder(Layout layout, Imposition imposition)
        {
            _layout = layout ?? throw new ArgumentNullException(nameof(layout));
            _imposition = imposition ?? throw new ArgumentNullException(nameof(imposition));
        }

        public OutputFile Build(List<SourceFile> sourceFiles)
        {
            throw new NotImplementedException();
            //if (products.Count == 0)
            //{
            //    throw new ArgumentException("You must specify at least one product to be impositioned", nameof(products));
            //}

            //var frontColumnsPerProduct = ConvertToColumns(products);
            //var blocks = frontColumnsPerProduct.Select(cpp => BuildProductBlockFromColumns(cpp.Columns)).ToList();
            //var frontSmartStackerPages = BuildSmartStackerPages(_pageBuilder, frontColumnsPerProduct);
            //var outputFile = new OutputFile(Layout, frontSmartStackerPages, frontSmartStackerPages.Count, blocks);

            //return outputFile;
        }
    }
}