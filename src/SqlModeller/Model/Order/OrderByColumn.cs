namespace SqlModeller.Model.Order
{
    public class OrderByColumn : Column
    {
        public OrderByColumn(string tableAlias, string fieldName, OrderDir direction, Aggregate aggregate = Aggregate.None)
            : base(tableAlias, fieldName)
        {
            Direction = direction;
            Aggregate = aggregate;
        }

        public OrderDir Direction { get; set; }

        public Aggregate Aggregate { get; set; }
    }
}