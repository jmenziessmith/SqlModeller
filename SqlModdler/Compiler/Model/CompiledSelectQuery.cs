using System.Collections.Generic;
using System.Linq;

namespace SqlModdler.Compiler.Model
{
    public class CompiledSelectQuery
    {
        public string Select { get; set; }
        public string From { get; set; }
        public string Where { get; set; }
        public string GroupBy { get; set; }
        public string Having { get; set; }
        public string OrderBy { get; set; }
        public string OffsetLimit { get; set; }
       
        public string Sql
        {
            get { return GetSql(); }
        }

        private string GetSql()
        {
            var parts = new List<string>
                        {
                            Select,
                            From,
                            Where,
                            GroupBy,
                            Having,
                            OrderBy,
                            OffsetLimit
                        };


            var result = string.Empty;

            foreach (var part in parts.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                result += string.Format("{0} \n", part);
            }

            result = result.TrimEnd('\n');

            return result;

        }

    }
}