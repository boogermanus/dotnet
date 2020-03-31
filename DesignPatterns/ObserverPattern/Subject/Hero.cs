namespace ObserverPattern.Subject
{
   public class Hero
   {
       private string _name;
       public string Name => _name;
       private string _move;
       public string Move => _move;

       public Hero(string name, string move)
       {
           _name = name;
           _move = move;
       }

       public override string ToString()
       {
           return $"{_name} has joined the fray, {_move}!";
       }
   }
}