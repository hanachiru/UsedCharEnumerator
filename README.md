# UsedCharEnumerator
UnityのAssets内(もしくは特定のフォルダ)で使用されている文字を列挙するエディタ拡張  
![Demo](https://user-images.githubusercontent.com/46705432/104748490-27898680-5795-11eb-98e9-92a05e2ec5ac.gif)

## Dependency
Unity 2018.4.0f1(以上)  

## Setup
[Releaseページ](https://github.com/hanachiru/UsedCharEnumerator/releases)から`.unitypackage`をインストールする

## Usage


## Note
[TextMeshPro](https://docs.unity3d.com/ja/2019.4/Manual/com.unity.textmeshpro.html)で日本語に対応する際に非常に効果的です。  

常用漢字を全て入れようと思うと<code>Atlas Resolution</code>を<code>4096x4096</code>もしくは<code>8192x8192</code>にする必要があり、容量が非常に大きくなります。  

その対策として、使用する文字だけをアセットに入れるという方法がよく取られます。  
[【Unity】TextMeshProのフォント用のアセットに指定した文字だけを入れて容量を下げる手順](https://www.hanachiru-blog.com/entry/2019/06/06/114214)
  
使用する文字だけを取り出すという作業をこのライブラリによってボタンを押すだけで可能となっています。

## License
This software is released under the MIT License, see LICENSE.

## Authors
Hanachiru([@hanaaaaaachiru](https://twitter.com/hanaaaaaachiru))
