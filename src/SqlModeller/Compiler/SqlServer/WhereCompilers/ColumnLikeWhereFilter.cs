using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class ColumnLikeWhereFilterCompiler : IWhereCompiler<ColumnLikeWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as ColumnLikeWhereFilter;

            switch (where.LikeMode)
            {
                case LikeMode.AllWords:
                case LikeMode.AnyWord:
                    return MultiWord(where, parameters);

                case LikeMode.Default:
                case LikeMode.Wildcard:
                case LikeMode.WildcardLeft:
                case LikeMode.WildcardRight:
                    return SingleWord(where, parameters);

                case LikeMode.FreeText:
                    return FreeText(where, parameters);
            }

            throw new NotImplementedException();
        }



        private string SingleWord(ColumnLikeWhereFilter where, IQueryParameterManager parameters, bool exclude = false )
        {
            const string wc = "'%'";
            var leftWildCard = (where.LikeMode == LikeMode.WildcardLeft || where.LikeMode == LikeMode.Wildcard);
            var rightWildCard = (where.LikeMode == LikeMode.WildcardRight || where.LikeMode == LikeMode.Wildcard);

            //var textValue = ToStringHelper.ValueString(, DbType.String);

            var parameterisedText = parameters.Parameterize(where.Text, DbType.String, where.LeftColumn.Field.Name);


            return string.Format("{0} {1} {2}{3}{4}",
                                where.LeftColumn.FullName,
                                exclude ? "NOT LIKE" : "LIKE",
                                leftWildCard ? wc + " + " : null,
                                parameterisedText,
                                rightWildCard ? " + " + wc : null 
                                );
        }
         

        private string MultiWord(ColumnLikeWhereFilter where, IQueryParameterManager parameters)
        {
            var words = where.Text.Split(' ');

            var likes = new List<string>();
            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                var like = SingleWord(new ColumnLikeWhereFilter()
                                      {
                                          LeftColumn = where.LeftColumn,
                                          Text = word,
                                          LikeMode = LikeMode.Wildcard
                                      }, 
                                      parameters);
                likes.Add(like);
            }

            
            return CombineLikes(likes, where.LikeMode == LikeMode.AllWords); 
           
        }

        private string FreeText(ColumnLikeWhereFilter where, IQueryParameterManager parameters)
        {
            const string pattern = "[+-]?[\"][^\"]+[\"]|[+-]?['][^']+[']|[+-]?[^\" ]*";
            var regex = new Regex(pattern);

            var phrases = regex.Matches(where.Text);

            var likes = new List<string>();

            foreach (Match phrase in phrases)
            {
                bool isExclude = phrase.Value.StartsWith("-");
                var word = phrase.Value.Trim(new[] { '+', '-', '"', '\'' });

                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }

                var like = SingleWord(new ColumnLikeWhereFilter()
                                      {
                                          LeftColumn = where.LeftColumn,
                                          Text = word,
                                          LikeMode = LikeMode.Wildcard
                                      },
                                      parameters,
                                      isExclude);
                likes.Add(like);
            }

            return CombineLikes(likes);

        }

        private string CombineLikes(List<string> likes, bool matchAll = true)
        {
            var operatorString = matchAll ? "AND" : "OR";
         
            var result = string.Empty;
            bool first = true;
            foreach (var like in likes)
            {

                result += string.Format("{0} {1} ",
                            !first ? operatorString : null,
                            like
                          );

                first = false;
            } 

            return string.Format("({0})", result);
        }
    }
}