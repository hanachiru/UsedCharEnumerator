# UsedCharEnumerator
<code>UsedCharEnumerator</code>はUnityのAssets内(もしくは特定のフォルダ)で使用されている文字を列挙するエディタ拡張です。  
![Demo](https://user-images.githubusercontent.com/46705432/119090937-3df76580-ba47-11eb-9c92-42ebc007910f.png)

## Dependency
Unity 2018.4.0f1 or later

## Setup
[Releaseページ](https://github.com/hanachiru/UsedCharEnumerator/releases)から`.unitypackage`をインストールしてください。

## Usage
### UsedCharEnumeratorWindowの開き方
<code>Tools -> UsedCharEnumerator</code>を選択し、<code>UsedCharEnumeratorWindow</code>を開きます。  
![UsedCharEnumeratorの開き方](https://user-images.githubusercontent.com/46705432/119091340-dee62080-ba47-11eb-9266-aa512014398e.png)
  
  
### UsedCharEnumeratorWindowの使い方
  
![UsedCharEnumerator](https://user-images.githubusercontent.com/46705432/119091685-6764c100-ba48-11eb-8377-5c03bbdfcab0.png)

1. 検索する対象のフォルダを選択  
Assets以下の全てのファイルに対して走査を行う場合は、<code>Assets以下全てを検索</code>にチェックを入れてください。  
指定のフォルダ以下のファイルを対象にしたい場合は、<code>Assets以下全てを検索</code>にチェックを外し、フォルダを選択してください。

2. 対象の拡張子を選択  
中身を調べるファイルの拡張子を選択してください。複数選択可です。  
また<code>.asset</code>は<code>ScriptableObject</code>も含みます。

3. 実行する  
1,2の設定で検索を行います。

4. 出力  
実行結果が出力されます。  

## Note
このライブラリは[TextMeshPro](https://docs.unity3d.com/ja/2019.4/Manual/com.unity.textmeshpro.html)で日本語に対応する際に非常に効果的です。  

常用漢字を全て入れようと思うと<code>Atlas Resolution</code>を<code>4096x4096</code>もしくは<code>8192x8192</code>にする必要が多々あり、容量が非常に大きくなります。  

その対策として、使用する文字だけをアセットに入れるという方法がよく取られます。  
[【Unity】TextMeshProのフォント用のアセットに指定した文字だけを入れて容量を下げる手順](https://www.hanachiru-blog.com/entry/2019/06/06/114214)
  
使用する文字だけを取り出すという作業をこのライブラリによってボタンを押すだけで可能になります。

## License
This software is released under the MIT License, see LICENSE.

## Authors
Hanachiru([@hanaaaaaachiru](https://twitter.com/hanaaaaaachiru))
