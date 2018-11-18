using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.Logic.Contract
{
    public interface IImpositionRepository
    {
        Imposition Get(string key);
        void Save(Imposition imposition);
    }
}