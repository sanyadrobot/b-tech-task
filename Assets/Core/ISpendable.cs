using System;

namespace Core
{
    public interface ISpendable
    {
        Action<bool> OnBeSpendableChange { get; set; }
        bool CanSpend();
        void Spend();
    }
}
