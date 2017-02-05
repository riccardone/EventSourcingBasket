namespace Domain.Messages.Commands
{
    public class AddProduct : Command
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public AddProduct(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
