using MementoPattern.Originator;

namespace MementoPattern.Memento
{
    public class FoodSupplierMemento
    {
        private FoodSupplier _foodSupplier;
        
        public string Name => _foodSupplier.Name;
        public string Phone => _foodSupplier.Phone;
        public string Address => _foodSupplier.Address;

        public FoodSupplierMemento(FoodSupplier supplier)
        {
            _foodSupplier = supplier;
        }
    }
}