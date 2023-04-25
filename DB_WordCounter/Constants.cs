namespace DB_WordCounter
{
    public static class Constants
    {
        public static string GeneralFilepath()
        {
            return @".\Resources\Output\FILE_GENERAL.txt";
        }
        public static string ExclusionSourceFilepath()
        {
            return @".\Resources\Input\Exclude.txt";
        }
        public static string ExclusionFilepath()
        {
            return @".\Resources\Exclude\Exclude.txt";
        }

        public static string OutputFolder()
        {
            return @".\Resources\Output\";
        }
    }
}
