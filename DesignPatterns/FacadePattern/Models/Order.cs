using System.Text;
namespace FacadePattern.Models
{
    public class Order
    {
        public FoodItem Appetizer { get; set; }
        public FoodItem Entree { get; set; }
        public FoodItem Drink { get; set; }
        public Patron Patron { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
            .AppendLine($"{Patron.Name} places order for:")
            .AppendLine($"{Appetizer.ItemName}")
            .AppendLine($"{Entree.ItemName}")
            .AppendLine($"{Drink.ItemName}")
            .ToString();
        }
    }
}