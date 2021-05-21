using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UsedCharEnumerator.Editor
{
    public class UsedCharEnumeratorWindow : EditorWindow
    {
        private DefaultAsset _searchFolder;
        private bool _searchAllFile;
        private string _output;
        
        private readonly CharEnumerator _enumerator = new CharEnumerator();

        private readonly Dictionary<string, bool> _searchFileExtensions = new Dictionary<string, bool>()
        {
            { ".txt", false },
            { ".cs", false },
            { ".asset", false },
            { ".json", false },
            { ".xml", false },
            { ".csv", false },
        };

        [MenuItem("Tools/UsedCharEnumerator")]
        private static void OpenWindow()
        {
            var window = GetWindow<UsedCharEnumeratorWindow>("UsedCharEnumeratorWindow");
            window.minSize = new Vector2(500, 500);
        }

        private void OnGUI()
        {
            _searchAllFile = EditorGUILayout.Toggle("Assets以下全て検索", _searchAllFile);
            
            EditorGUI.BeginDisabledGroup(_searchAllFile);
            var searchFolder = (DefaultAsset)EditorGUILayout.ObjectField("検索フォルダ", _searchFolder, typeof(DefaultAsset), false);

            if (searchFolder == null) EditorGUILayout.HelpBox("中で使用されている文字列を知りたいフォルダを選択してください", MessageType.Info);
            else if (_searchFolder != searchFolder) _searchFolder = searchFolder;
            EditorGUI.EndDisabledGroup();
            
            // 検索対象を選択するボタン
            foreach (var key in _searchFileExtensions.Keys.ToArray())
                _searchFileExtensions[key] = EditorGUILayout.Toggle(key, _searchFileExtensions[key]);

            // 検索ボタン
            if (GUILayout.Button("Search", GUILayout.Height(16)))
            {
                if (_searchAllFile) _output = _enumerator.Execute(Directory.GetCurrentDirectory() + "/Assets/", _searchFileExtensions.Where(f => f.Value).Select(f => f.Key));
                else if (_searchFolder != null) _output = _enumerator.Execute(DefaultAssets2AbsolutePath(_searchFolder),  _searchFileExtensions.Where(f => f.Value).Select(f => f.Key));
            }

            // 結果を出力するテキスト
            GUIStyle style = new GUIStyle(GUI.skin.textArea);
            style.wordWrap = true;
            EditorGUILayout.TextArea(_output, style, GUILayout.MaxHeight(float.MaxValue));
        }

        /// <summary>
        /// アセットを絶対パスに変換して更新しておく
        /// </summary>
        /// <param name="asset">選んだアセット</param>
        private string DefaultAssets2AbsolutePath(DefaultAsset asset)
        {
            var path = AssetDatabase.GetAssetOrScenePath(_searchFolder);
            string[] folderList = path.Split('/');
            if (folderList[folderList.Length - 1].Contains(".")) path = null;

            return path;
        }
    }
}