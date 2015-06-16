using SqlModeller.Interfaces;
using System.Collections.Generic;

namespace SqlModeller.Model.Where
{
    public class ColumnInWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public List<LiteralValue> RightValues { get; set; } 
        

        /// <summary>
        /// Optional value, used for naming parameters. If not set, the field name will be used
        /// </summary>
        public string ParameterAlias { get; set; }
    }
}