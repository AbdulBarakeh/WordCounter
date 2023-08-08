namespace DB_WordCounter.Classes
{
    public class DirectorySetter
    {
        private string SourceDirectory { get; set; }
        public DirectorySetter(string directoryPath)
        {
            SourceDirectory = directoryPath;
            Directory.CreateDirectory($@"{SourceDirectory}\Output");
            Directory.CreateDirectory($@"{SourceDirectory}\Exclude");
        }

        /// <summary>
        /// Root directory
        /// </summary>
        /// <returns>filepath as string</returns>
        public string RootFilepath()
        {
            return $@"{SourceDirectory}";
        }
        /// <summary>
        /// Were all words are saved
        /// </summary>
        /// <returns>filepath as string</returns>
        public string GeneralFilepath()
        {
            return $@"{SourceDirectory}\Output\FILE_GENERAL.txt";
        }
        /// <summary>
        /// Words to be excluded
        /// </summary>
        /// <returns>filepath as string</returns>

        public string ExclusionSourceFilepath()
        {
            return $@"{SourceDirectory}\Exclude.txt";
        }
        /// <summary>
        /// Excluded words and their occurence count
        /// </summary>
        /// <returns>filepath as string</returns>

        public string ExclusionFilepath()
        {
            return $@"{SourceDirectory}\Exclude\Exclude.txt";
        }
        /// <summary>
        /// Folder where words are sorted into files
        /// </summary>
        /// <returns>filepath as string</returns>

        public string OutputFolder()
        {
            return $@"{SourceDirectory}\Output\";
        }
    }
}
