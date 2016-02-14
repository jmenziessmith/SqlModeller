namespace SqlModeller.Model
{
    public enum ContainsMode
    {
        Default, // CONTAINS('"hello world"')
        WildcardRight, // CONTAINS('"hello world*"')
        AnyWord, // (CONTAINS('"hello"') OR  CONTAINS('"world"')
        AnyWordWildcardRight, // (CONTAINS('"hello*"') OR  CONTAINS('"world*"')
        AllWords, // (CONTAINS('"hello"') AND  CONTAINS('"world"')
        AllWordsWildcardRight, // (CONTAINS('"hello*"') AND  CONTAINS('"world*"')
        FreeText, // "hello world" - foo => (CONTAINS('"hello world*"' AND NOT CONTAINS '"foo*"')
    }
}