namespace SqlModdler.Model.Order
{
    public class OrderByColumn : Column
    {
        public OrderByColumn(string tableAlias, string fieldName, OrderDir direction)
            : base(tableAlias, fieldName)
        {
            Direction = direction;
        }

        public OrderDir Direction { get; set; }
    }
}