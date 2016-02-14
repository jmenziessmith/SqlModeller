namespace SqlModeller.Model
{
    public enum LikeMode
    {
        Default, // LIKE 'hello world'
        Wildcard, // LIKE '%hello world%'
        WildcardLeft, // LIKE '%hello world'
        WildcardRight, // LIKE 'hello world%'
        AnyWord, // (LIKE '%hello%' OR  LIKE '%world%')
        AllWords, // (LIKE '%hello%' AND  LIKE '%world%')
        FreeText, // "hello world" - foo => (LIKE '%hello world%' AND NOT LIKE '%foo%')
    }
}
