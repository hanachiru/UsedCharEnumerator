﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UsedCharEnumerator
{
    public class FileTextFormatter
    {
        public IEnumerable<string> Execute(IEnumerable<string> fileText, FileExtension fileExtension)
        {
            if (fileExtension != FileExtension.asset) return fileText;

            // ScriptableObjecはUnicode 文字のエスケープシーケンスのため
            return fileText.Select(Regex.Unescape);
        }
    }
}