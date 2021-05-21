using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace UsedCharEnumerator.Tests
{
    public class FileReaderTest
    {
        [Test]
        public void GetTest()
        {
            var testDataPass = GetAbsolutePath("");
            var results = FileReader.Get(testDataPass, new[] {".asset"});

            Assert.AreEqual(results.Any(info => info.Name == "TestScriptableObject.asset"), true);
        }

        [Test]
        public void ReadTest()
        {
            var testDataPass = GetAbsolutePath("");
            var results = FileReader.Get(testDataPass, new[] {".cs"});

            var lines = FileReader.Read(results.First(info => info.Name == "TestScript.cs"));
            var text = string.Join("\n", lines);

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
