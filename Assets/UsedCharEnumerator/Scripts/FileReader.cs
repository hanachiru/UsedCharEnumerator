using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UsedCharEnumerator
{
    public static class FileReader
    {
        /// <summary>
        /// ファイル情報の一覧を取得する
        /// </summary>
        /// <param name="absolutePath">検索するファイル群のルートフォルダ</param>
        /// <param name="targets">検索する拡張子</param>
        /// <returns>ファイル情報の一覧</returns>
        public static IEnumerable<FileInfo> Get(string absolutePath, IEnumerable<string> targets)
        {
            if (string.IsNullOrEmpty(absolutePath)) throw new ArgumentException("absolutePathがnullもしくはemptyになっています");
            if(targets == null) throw new ArgumentException("targetsはnullにできません");

            var dir = new DirectoryInfo(absolutePath);

            foreach (var item in targets)
            {
                var files = dir.GetFiles($"*{item}", SearchOption.AllDirectories);
                foreach (var file in files)
                    yield return file;
            }
        }

        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="info">ファイル情報</param>
        /// <returns>ファイルに記載されている文字列データ</returns>
        public static IEnumerable<string> Read(FileInfo info)
            => Read(info.FullName);

        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="filePath">ファイルの絶対パス</param>
        /// <returns>ファイルに記載されている文字列データ</returns>
        public static IEnumerable<string> Read(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("filePathがnullもしくはemptyになっています");
            
            using(var reader = new StreamReader(filePath, Encoding.UTF8))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
}
