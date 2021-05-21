using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UsedCharEnumerator;
using CharEnumerator = UsedCharEnumerator.CharEnumerator;

namespace Tests
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
