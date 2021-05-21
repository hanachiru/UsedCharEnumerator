using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace UsedCharEnumerator.Tests
{
    public class CharEnumeratorTest
    {
        [Test]
        public void ExecuteTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".asset", ".txt", ".cs"});
            
            Assert.AreEqual(result.Contains("テスト"), true);
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
