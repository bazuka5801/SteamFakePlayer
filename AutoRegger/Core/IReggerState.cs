using AutoRegger.Core.Data;

namespace AutoRegger.Core.States
{
    public interface IReggerState
    {
        void Setup(ReggerAccountData data);
        void Execute();
    }
}