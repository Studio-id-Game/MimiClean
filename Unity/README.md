## MimiClean.Unity Project
- MimiCleanUnity package の開発環境
### MimiCleanUnity.Dev
- (機能) `[Dev] Update LibraryDependencies`（開発時のみ、手動）：Packageで利用している依存関係を取得、`LibraryDependencies.json`として保存する
- (機能) `[Dev] Show All Assembly`（開発時のみ、手動）：現在の環境でロードされている全てのアセンブリの名前とバージョンを表示する
### MimiCleanUnity package
- MimiClean を Unity で利用するためのインポーター及び主要な追加機能を提供するUPM対応パッケージ
#### MimiCleanUnity.Runtime.CleanResultUniTask
- `MimiClean<UniTask<T>>` を待機したり変換したりする機能
#### MimiCleanUnity.EditorTools
- gitに乗せたくないバイナリファイルをオンラインからDL、管理する
  - (機能) `Update Remote Resource`（手動）：オンラインリソースを取得、更新する
    - GoogleDriveからzip形式でダウンロード（.dll, .xml, .meta, .gitignore 等）
    - `Assets/StudioIdGames.MimiClean.Library/**` に`**.zip.tmp`として保存、同フォルダに中身を展開
- `LibraryDependencies.json`を元に依存関係をチェックする
  - (機能) `Check Assemblies`（手動）：ライブラリの依存関係をチェックする
  - (機能) `[InitializeOnLoadMethod]`,`CompilationPipeline.compilationFinished`（自動）：必要に応じてオンラインリソースを取得後、ライブラリの依存関係をチェックする
  - ライブラリの依存関係をチェックした時、アセンブリが不足していた場合はダイアログで警告する。ただし、アセンブリ追加直後ならエディターのリロードで解決する場合があるので、ダイアログにはその旨とリロードボタンを表示する。
## MimiClean.UnitySample Project
- MimiCleanUnity package の導入チェックと簡単なサンプル
