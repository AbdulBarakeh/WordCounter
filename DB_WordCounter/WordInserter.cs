namespace DB_WordCounter
{
    public class WordInserter
    {
        internal string FindFilepath(string value)
        {
            return @"C:\Users\abdul\Desktop\Work\DanskeBank\Assignment\DB_WordCounter\Resources\Output\FILE_A.txt";
            //throw new NotImplementedException();
        }

        internal void Insert(string word, StreamWriter writer)
        {
            var firstLetter = word.ToLower().First();
            writer.WriteLineAsync(word + " ");

            //switch (firstLetter)
            //{
            //    case 'a':
            //        writer.WriteLineAsync(word + " ");
            //        break;
            //    case 'b':
            //        break;
            //    case 'c':
            //        break;
            //    case 'd':
            //        break;
            //    case 'e':
            //        break;
            //    case 'f':
            //        break;
            //    case 'g':
            //        break;
            //    case 'h':
            //        break;
            //    case 'i':
            //        break;
            //    case 'j':
            //        break;
            //    case 'k':
            //        break;
            //    case 'l':
            //        break;
            //    case 'm':
            //        break;
            //    case 'n':
            //        break;
            //    case 'o':
            //        break;
            //    case 'p':
            //        break;
            //    case 'q':
            //        break;
            //    case 'r':
            //        break;
            //    case 's':
            //        break;
            //    case 't':
            //        break;
            //    case 'u':
            //        break;
            //    case 'v':
            //        break;
            //    case 'w':
            //        break;
            //    case 'x':
            //        break;
            //    case 'y':
            //        break;
            //    case 'z':
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}