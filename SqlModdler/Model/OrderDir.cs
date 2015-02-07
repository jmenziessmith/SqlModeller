namespace SqlModdler.Model
{
    public enum OrderDir
    {
        Asc,
        Desc
    } 

    public static class OrderDirectionExtensions
    {
        public static string ToSqlString(this OrderDir value)
        {
            return value.ToString().ToUpper();
        }
    }
}