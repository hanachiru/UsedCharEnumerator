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
            // NOTE: 一部パースできない記号()を確認したためtry-catchで対応（英語・日本語を取りこぼす事例は今のところなし）
            return fileText.Select(t =>
            {
                try
                {
                    return Regex.Unescape(t);
                }
                catch
                {
                    return "";
                }
            });
        }
    }
}