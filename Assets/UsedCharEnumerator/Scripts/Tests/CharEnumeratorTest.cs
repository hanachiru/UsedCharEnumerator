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
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".asset", ".txt", ".cs", ".xml", ".json", ".csv"});
            
            Assert.AreEqual(result.Contains("テスト"), true);
        }
        
        [Test]
        public void AssetTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".asset"});

            Assert.AreEqual(result.Contains("テスト用"), true);
        }
        
        [Test]
        public void TxtTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".txt"});

            Assert.AreEqual(result.Contains("テスト用"), true);
        }
        
        [Test]
        public void CsTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".cs"});
    
            Assert.AreEqual(result.Contains("テスト"), true);
        }
        
        [Test]
        public void XmlTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".xml"});
            
            Assert.AreEqual(result.Contains("テスト用"), true);
        }
        
        [Test]
        public void JsonTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".json"});
            
            Assert.AreEqual(result.Contains("テスト"), true);
        }
        
        [Test]
        public void CsvTest()
        {
            var result = new CharEnumerator().Execute(GetAbsolutePath(""), new[] {".csv"});
            
            Assert.AreEqual(result.Contains("エクセル"), true);
        }

        [Test]
        public void ErrorTest1()
        {
            try
            {
                var result = new CharEnumerator().Execute(null, new[] {".csv"});
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void ErrorTest2()
        {
            try
            {
                var result = new CharEnumerator().Execute(GetAbsolutePath(""), null);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
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
