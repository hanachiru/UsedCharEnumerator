using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UsedCharEnumerator
{
    public class CharEnumerator
    {
        private readonly FileTextFormatter _formatter = new FileTextFormatter();

        /// <summary>
        /// ファイルを読み込み、使用されている文字列一覧を取得する
        /// </summary>
        /// <param name="infos">ファイル情報群</param>
        /// <returns>使用されている文字列</returns>
        public string Execute(IEnumerable<(FileExtension, FileInfo)> infos)
        {
            var charSet = new HashSet<char>();

            foreach (var info in infos)
                foreach (var line in _formatter.Execute(FileReader.Read(info.Item2), info.Item1))
                    foreach (var c in line)
                        charSet.Add(c);
            
            return new string(charSet.ToArray());
        }
    }

    public enum FileExtension
    {
        cs,
        asset,
        json,
        xml
    }
}