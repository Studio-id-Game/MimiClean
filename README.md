[English README is here](/README-en.md)

# MimiClean
クリーンアーキテクチャ風の仕組みを提供する、シンプルな C# (.NET Standerd 2.0) 向けライブラリです。

Developed by Studio-id-Games, hirohiroj3cub.

# 用途
このライブラリは以下のような目的に利用できます。
- Clean Architecture っぽく階層設計をしたい。
- Dependency Injection っぽく依存関係を解消したい。
- それらをなるべくシンプルに、様々な環境で、なるべく例外をキャッチせずに実現したい。

## 主な機能
- Dependency Injection っぽい依存関係解消手段
- レールウェイ指向（Railway-Oriented） っぽいエラーハンドリング
- Clean Architecture っぽい階層設計構造
  - Domain：システムの概念スケールでの設計
    - Entity：概念スケールのオブジェクト
      - EntityModule/EntityModuleSet : Entityの部分的機能を分割・共有するための機能
    - Service : DIの為のアクセスポイント
  - App(lication) : 動作スケールでの設計
    - Usecase/Interactor : 動作の定義と実装
    - Repository : データアクセスの定義
  - Adapter : 環境スケールでの設計
    - Gateway : 環境にあわせた入力の実装
    - Presenter : 環境にあわせた応答の実装
    - Controller : Gateway -> Interactor -> Presenter -> Framework の抽象的接続
  - Service, Repository は依存性が逆転しない範囲であればどの層でも実装可能 

## 主な性能
- 実際にサンプルを作成した感じ、概ね問題なく運用できました。機能の追加も最低限のコードで実現できます。（後日、詳細を記述）
- Service と Repository は静的な実装ですが、「Static Type Caching」 等と呼ばれる方法を用いて、ほぼ0コストで抽象的に（つまり必要に応じて派生クラスのインスタンスを切り替えながら）アクセス出来ます。
- そのほか、readonly (ref) struct や in 引数を利用して、ある程度パフォーマンスを意識しているつもりです。
- ChatGPTに部分的に相談した所、「実用的だと思います」と言ってくれました！（生成AIの生成したコードは使用していません）

# 利用方法
MITライセンスです。今はReleaseを出していないので、各自 VisualStudio 等でビルドして、お好きな場所にdllを配置・参照してご利用ください。.Net Standerd2.0で作成しているので様々な環境で利用できます。

各クラスの利用方法は、[Sampleプロジェクト](/MimiClean/MimiCleanSample)をご参照ください。後日、compile済み.dllの配布やAPIリファレンス、簡単な導入例のドキュメント等も整備する予定です。

# 開発背景
基本的にはゲーム開発（Unityや、自作開発ツール）の為に作成しました。色々と厳密に定義しようとすると実装も利用も面倒なので、可能な限り簡略化して利用しやすいライブラリを目指しています。

バグや機能要望があれば、[お気軽にIsuueください！](https://github.com/Studio-id-Game/MimiClean/issues)
