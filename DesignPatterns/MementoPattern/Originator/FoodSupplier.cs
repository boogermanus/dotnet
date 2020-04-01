using System;
using System.Text;
using MementoPattern.Memento;

namespace MementoPattern.Originator
{
    public class FoodSupplier
    {
        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                Console.WriteLine($"Name: {_name}");
            }
        }

        private string _phone;
        public string Phone {
            get => _phone;
            set
            {
                _phone = value;
                Console.WriteLine($"Phone: {_phone}");
            }
        }

        private string _address;
        public string Address 
        {
            get => _address;
            set 
            {
                _address = value;
                Console.WriteLine($"Address: {_address}");
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }

        public FoodSupplierMemento SaveMemento()
        {
            Console.WriteLine($"Saving state for: {this}");
            return new FoodSupplierMemento(this);
        }

        public void RestoreMemento(FoodSupplierMemento memento)
        {
            this.Name = memento.Name;
            this.Address = memento.Address;
            this.Phone = memento.Phone;
        }
    }
}