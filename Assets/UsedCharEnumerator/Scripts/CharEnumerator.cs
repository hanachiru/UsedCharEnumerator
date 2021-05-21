using System;
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
        /// <param name="absolutePath">検索するフォルダの絶対パス</param>
        /// <param name="fileExtensions">対象の拡張子</param>
        /// <returns>使用されている文字の一覧</returns>
        public string Execute(string absolutePath, IEnumerable<string> fileExtensions)
        {
            if (string.IsNullOrEmpty(absolutePath)) throw new ArgumentException("absolutePathがnullもしくはemptyになっています");
            if(fileExtensions == null) throw new ArgumentException("fileExtensionsはnullにできません");
            if (!fileExtensions.Any()) return "";
            
            var files = FileReader.Get(absolutePath, fileExtensions);
            
            var charSet = new HashSet<char>();

            foreach (var file in files)
                foreach (var line in _formatter.Execute(FileReader.Read(file), file.Extension))
                    foreach (var c in line)
                        charSet.Add(c);
            
            return new string(charSet.ToArray());
        }
    }
}