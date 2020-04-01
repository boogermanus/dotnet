using MementoPattern.Memento;

namespace MementoPattern.Caretaker
{
    public class SupplierMemory
    {
        public FoodSupplierMemento FoodSupplierMemento { get; set; }

        public SupplierMemory(FoodSupplierMemento memento)
        {
            FoodSupplierMemento = memento;
        }
    }
}