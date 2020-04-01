using MementoPattern.Originator;

namespace MementoPattern.Memento
{
    public class FoodSupplierMemento
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public FoodSupplierMemento(FoodSupplier supplier)
        {
            Name = supplier.Name;
            Phone = supplier.Phone;
            Address = supplier.Address;
        }
    }
}