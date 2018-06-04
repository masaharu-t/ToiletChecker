using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("トイレチェッカー")]
[assembly: AssemblyDescription("[トイレ時刻の記録方法]\r\n　[大], [小], [大小]のボタンをクリックしますとトイレ時刻を記録します。\r\n\r\n[トイレ時刻の追加]\r\n　[データ追加]をクリックしますと手動でトイレ時刻を追加できます。\r\n\r\n[記録したトイレ時刻の修正方法]\r\n　トイレ時刻一覧の修正したい項目をダブルクリックします。\r\n時刻修正画面が表示されます。記録したデータを修正後、[変更]をクリックして修正されます。\r\n\r\n[記録したトイレ時刻の削除方法]\r\nトイレ時刻一覧の削除したい行を選択して[DEL] キーを押します。確認はありません。\r\n\r\n現在のクリック後の時間とトイレ種別を表示\r\n前回の大からの経過時間を表示\r\n\r\n\r\n[大], [小], [大小]のボタンをクリック後は１分間は続けてクリックすることはできません。\r\n\r\nトイレチェックしたデータは、実行ファイル[ToiletChecker.exe] と同じフォルダにあります。\r\nファイル名は、[ToiletChecker.txt]です。\r\nCSV形式のファイルです。\r\n2016/04/01 06:30:00,小[改行]\r\n~~~~~~~~~~~~~~~~~~~~~~~~~~\r\nのフォーマットになっております。\r\n\r\nアプリの改良についてはお問い合わせください。\r\nEMail：masaharu-takahashi01 @softkobo-t.jp")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ソフト工房たかはし")]
[assembly: AssemblyProduct("トイレチェッカー")]
[assembly: AssemblyCopyright("Copyright © 2016 ソフト工房たかはし")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、その型はこのアセンブリ内で COM コンポーネントから 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// このプロジェクトが COM に公開される場合、次の GUID が typelib の ID になります
[assembly: Guid("137e26ec-50a6-452b-996d-76995d70c95e")]

// アセンブリのバージョン情報は次の 4 つの値で構成されています:
//
//      メジャー バージョン
//      マイナー バージョン
//      ビルド番号
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってビルドおよびリビジョン番号を 
// 既定値にすることができます:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
