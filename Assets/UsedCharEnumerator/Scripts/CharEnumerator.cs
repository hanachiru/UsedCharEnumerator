using System.Collections.Generic;
using System.Linq;

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
        public string Execute(string absoletePath, IEnumerable<string> fileExtensions)
        {
            var files = FileReader.Get(absoletePath, fileExtensions);
            
            var charSet = new HashSet<char>();

            foreach (var file in files)
                foreach (var line in _formatter.Execute(FileReader.Read(file), file.Extension))
                    foreach (var c in line)
                        charSet.Add(c);
            
            return new string(charSet.ToArray());
        }
    }
}