using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace UsedCharEnumerator
{
    internal static class FileReader
    {
        /// <summary>
        /// ファイル情報の一覧を取得する
        /// </summary>
        /// <param name="absolutePath">検索するファイル群のルートフォルダ</param>
        /// <param name="targets">検索する拡張子</param>
        /// <returns>ファイル情報の一覧</returns>
        internal static IEnumerable<FileInfo> Get(string absolutePath, IEnumerable<FileExtension> targets)
        {
            var dir = new DirectoryInfo(absolutePath);

            foreach (var item in targets)
            {
                var files = dir.GetFiles($"*.{item}", SearchOption.AllDirectories);
                foreach (var file in files)
                    yield return file;
            }
        }

        /// <summary>
        /// ファイルを読み込む
        /// </summary>
        /// <param name="info">ファイル情報</param>
        /// <returns>ファイルに記載されている文字列データ</returns>
        internal static IEnumerable<string> Read(FileInfo info)
        {
            using(var reader = new StreamReader(info.FullName, Encoding.UTF8))
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
}
