namespace DB_WordCounter.Classes
{
    public static class Constants
    {
        /// <summary>
        /// Were all words are saved
        /// </summary>
        /// <returns>filepath as string</returns>
        public static string GeneralFilepath()
        {
            return @".\Resources\Output\FILE_GENERAL.txt";
        }
        /// <summary>
        /// Words to be excluded
        /// </summary>
        /// <returns>filepath as string</returns>

        public static string ExclusionSourceFilepath()
        {
            return @".\Resources\Input\Exclude.txt";
        }
        /// <summary>
        /// Excluded words and their occurence count
        /// </summary>
        /// <returns>filepath as string</returns>

        public static string ExclusionFilepath()
        {
            return @".\Resources\Exclude\Exclude.txt";
        }
        /// <summary>
        /// Folder where words are sorted into files
        /// </summary>
        /// <returns>filepath as string</returns>

        public static string OutputFolder()
        {
            return @".\Resources\Output\";
        }
    }
}
