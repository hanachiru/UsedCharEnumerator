using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UsedCharEnumerator
{
    public class FileTextFormatter
    {
        public IEnumerable<string> Execute(IEnumerable<string> fileText, string fileExtension)
        {
            if (fileExtension != ".asset") return fileText;

            // ScriptableObjectはUnicode 文字のエスケープシーケンスのため
            return fileText.Select(Regex.Unescape);
        }
    }
}