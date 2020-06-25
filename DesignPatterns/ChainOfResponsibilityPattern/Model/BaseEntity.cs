namespace ChainOfResponsibilityPattern.Model
{
    public abstract class BaseEntity
    {
        private string _name;
        public string Name => _name;

        public BaseEntity(string name)
        {
            _name = name;
        }
    }
}