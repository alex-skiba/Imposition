using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.Logic.Contract
{
    public interface ILayoutRepository
    {
        Layout Get(string key);
        void Save(Layout layout);
    }
}