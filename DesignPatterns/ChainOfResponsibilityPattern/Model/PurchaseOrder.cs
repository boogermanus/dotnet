using System.Text;
using ChainOfResponsibilityPattern.Handler;

namespace ChainOfResponsibilityPattern.Model
{
    public class PurchaseOrder
    {
        private static int _count = 0;
        private int _id;
        public int Id => _id;
        private int _amount;
        public int Amount => _amount;
        private decimal _price;
        public decimal Price => _price;
        private string _name;
        public string Name => _name;
        private decimal _total;
        public decimal Total => _total;
        public Approver Approver { get; set; }
        private string ApprovedBy => Approver != null ? Approver.GetType().Name : string.Empty;


        public PurchaseOrder(string name, int amount, decimal price)
        {
            _id = ++_count;
            _name = name;
            _amount = amount;
            _price = price;

            _total = amount * price;
        }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"Purchase request for: {_name}")
                .AppendLine($" ({_amount} * {_price}) = {_total}")
                .AppendLine($"has been submitted with Id {_id}")
                .AppendLine($"Approved by: {ApprovedBy}")
                .ToString();
        }
    }
}