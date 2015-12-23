using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class ColumnContainsWhereFilterCompiler : IWhereCompiler<ColumnContainsWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as ColumnContainsWhereFilter;

            switch (where.ContainsMode)
            {
                case ContainsMode.AllWords:
                case ContainsMode.AllWordsWildcardRight:
                case ContainsMode.AnyWord:
                case ContainsMode.AnyWordWildcardRight:
                    return MultiWord(where, parameters);

                case ContainsMode.Default: 
                case ContainsMode.WildcardRight:
                    return SingleWord(where, parameters);

                case ContainsMode.FreeText: 
                    return FreeText(where, parameters);
                
            }

            throw new NotImplementedException();
        }



        private string SingleWord(ColumnContainsWhereFilter where, IQueryParameterManager parameters, bool exclude = false )
        {
            const string wc = "*"; 
            var rightWildCard = (SingleWordContainsMode(where.ContainsMode) == ContainsMode.WildcardRight);

            var formattedWhereText = string.Format("\"{0}{1}\"", where.Text, rightWildCard ? wc : null);

            var parameterisedText = parameters.Parameterize(formattedWhereText, DbType.String, where.LeftColumn.Field.Name);
             
            return string.Format("{0}({1}, {2})",
                                exclude ? "NOT CONTAINS" : "CONTAINS",
                                where.LeftColumn.FullName,
                                parameterisedText
                                );
        }
         

        private string MultiWord(ColumnContainsWhereFilter where, IQueryParameterManager parameters)
        {
            var words = where.Text.Split(' ');

            var Containss = new List<string>();
            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                var Contains = SingleWord(new ColumnContainsWhereFilter()
                                      {
                                          LeftColumn = where.LeftColumn,
                                          Text = word,
                                          ContainsMode = where.ContainsMode
                                      }, 
                                      parameters);
                Containss.Add(Contains);
            }

            
            return CombineContainss(Containss, where.ContainsMode == ContainsMode.AllWords); 
           
        }

        /// <summary>
        /// Converts all wildcard modes to WildCardRight and all non wildcard modes to Default
        /// </summary>
        private ContainsMode SingleWordContainsMode(ContainsMode containsMode)
        {
            switch (containsMode)
            { 
                case ContainsMode.WildcardRight: 
                case ContainsMode.AnyWordWildcardRight: 
                case ContainsMode.AllWordsWildcardRight: 
                case ContainsMode.FreeText:
                    return ContainsMode.WildcardRight;
                default :
                    return ContainsMode.Default;
            }
        }

        private string FreeText(ColumnContainsWhereFilter where, IQueryParameterManager parameters)
        {
            const string pattern = "[+-]?[\"][^\"]+[\"]|[+-]?['][^']+[']|[+-]?[^\" ]*";
            var regex = new Regex(pattern);

            var phrases = regex.Matches(where.Text);

            var Containss = new List<string>();

            foreach (Match phrase in phrases)
            {
                bool isExclude = phrase.Value.StartsWith("-");
                var word = phrase.Value.Trim(new[] { '+', '-', '"', '\'' });

                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                var Contains = SingleWord(new ColumnContainsWhereFilter()
                                      {
                                          LeftColumn = where.LeftColumn,
                                          Text = word,
                                          ContainsMode = where.ContainsMode
                                      },
                                      parameters,
                                      isExclude);
                Containss.Add(Contains);
            }

            return CombineContainss(Containss);

        }

        private string CombineContainss(List<string> Containss, bool matchAll = true)
        {
            var operatorString = matchAll ? "AND" : "OR";
         
            var result = string.Empty;
            bool first = true;
            foreach (var Contains in Containss)
            {

                result += string.Format("{0} {1} ",
                            !first ? operatorString : null,
                            Contains
                          );

                first = false;
            } 

            return string.Format("({0})", result);
        }
    }
}