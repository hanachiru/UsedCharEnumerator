using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace UsedCharEnumerator.Tests
{
    public class FileTextFormatterTest
    {
        [Test]
        public void ScriptableObjectTest()
        {
            var assetPath = GetAbsolutePath("TestScriptableObject.asset");

            var results = new FileTextFormatter().Execute(FileReader.Read(assetPath), ".asset");

            var text = string.Join("", results.ToArray());
            Assert.AreEqual(text.Contains("テスト用のスクリプタブルオブジェクトです"), true);
        }

        [Test]
        public void TextTest()
        {
            var assetPath = GetAbsolutePath("TestText.txt");

            var results = new FileTextFormatter().Execute(FileReader.Read(assetPath), ".asset");

            var text = string.Join("", results.ToArray());
            Assert.AreEqual(text.Contains("これはテスト用のテキストファイルです"), true);
        }

        [Test]
        public void ScriptTest()
        {
            var assetPath = GetAbsolutePath("TestScript.cs");

            var results = new FileTextFormatter().Execute(FileReader.Read(assetPath), ".asset");

            var text = string.Join("", results.ToArray());
            Assert.AreEqual(text.Contains("これはテストスクリプトです"), true);
        }

        private static string GetAbsolutePath(string fileName)
        {
            var topDirectoryPath = Directory
                .GetDirectories("Assets", "*", SearchOption.AllDirectories)
                .FirstOrDefault(path => Path.GetFileName(path) == "UsedCharEnumerator");
            
            return Application.dataPath.Remove(Application.dataPath.LastIndexOf("Assets", StringComparison.Ordinal), "Assets".Length) + topDirectoryPath + "/Scripts/Tests/TestData/" + fileName;
        }
    }
}
