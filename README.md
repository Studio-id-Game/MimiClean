[English README is here](/README-en.md)

# MimiClean

クリーンアーキテクチャ風の仕組みを提供する、シンプルな C# (.NET Standerd 2.0) 向けライブラリです。

Developed by Studio-id-Games, hirohiroj3cub.

## 用途

このライブラリは以下のような目的に利用できます。
- Clean Architecture っぽく階層設計をしたい。
- Dependency Injection っぽく依存関係を解消したい。
- それらをなるべくシンプルに、様々な環境で、なるべく例外をキャッチせずに実現したい。

# 主な内容

- Microsoft.Extensions.DependencyInjection を拡張・カプセル化した独自のDIContainer（MimiCleanContainer）によるハイパフォーマンスで簡潔な依存関係解消
- ref struct を利用したハイパフォーマンスなレールウェイ指向（Railway-Oriented）エラーハンドリング
- C#の名前解決や文法の仕様に適した、Clean Architecture 的な階層構造設計

# 利用方法

MITライセンスです。今はReleaseを出していないので、各自 VisualStudio 等でビルドして、お好きな場所にdllを配置・参照してご利用ください。.Net Standerd2.0で作成しているので様々な環境で利用できます。

各クラスの利用方法は、[Sampleプロジェクト](/MimiClean/MimiCleanSample)、[API Reference](https://studio-id-game.github.io/MimiClean/api/StudioIdGames)をご参照ください。後日、compile済み.dllの配布、簡単な導入例のドキュメント等も整備する予定です。

# 機能概要と性能

## MimiCleanContainerについて

### Staticモード

Microsoft.Extensions.DependencyInjection の Singleton, Scoped, Transient のサービスタイプに加えて、スタティックジェネリックキャッシュを利用するハイパフォーマンスな Static サービスタイプを実装。
BenchmarkDotNetによる検証の結果、実際にSingletonの約7%の時間コストで動作している事を確認しています。

#### BenchmarkDotNet によるインスタンス呼び出し速度の測定結果 (COUNT = 10,000)

| Method    | Mean      | Error     | StdDev   |
|-----------|----------:|----------:|---------:|
| Scoped    |  55.128 µs |  1.9950 µs | 0.1094 µs |
| Transient |  58.733 µs | 23.3906 µs | 1.2821 µs |
| Singleton |  40.426 µs |  5.9840 µs | 0.3280 µs |
| Static    |   2.823 µs |  0.0584 µs | 0.0032 µs |

#### BenchmarkDotNet によるインスタンス呼び出し速度の測定結果 (COUNT = 1,000,000)

| Method    | Mean      | Error     | StdDev   |
|-----------|----------:|----------:|---------:|
| Scoped    | 5,400.4 µs |  278.15 µs |  15.25 µs |
| Transient | 6,005.7 µs |  410.92 µs |  22.52 µs |
| Singleton | 3,952.1 µs |  123.56 µs |   6.77 µs |
| Static    |   282.7 µs |    5.61 µs |   0.31 µs |

### Defaultファクトリー

`MimiServiceDefault<TInterface>.Set<TInstance>()`による、デフォルトファクトリーの手動事前登録機能
- 設計階層ごとにデフォルトを定義する事により、アセンブリ解析を不要にし、責任の所在を明確にできます。[MimiClean_Sample/Domain/DomainSetup.cs](/MimiClean/MimiClean_Sample/Domain/DomainSetup.cs)
- `MimiServiceDefault<TInterface>.Ref<TRefTo>()`により、派生クラスへの転送のような動作も記述できます。 

### Attributeによるサービスタイプ指定

- MimiServiceTypeAttributeをclassやinterfaceにつけるだけで、サービスタイプを動的に判定できます。（判定結果はキャッシュされる為、大きなコストは掛かりません）

## MimiCleanについて

### MimiCleanにおける Clean Architecture の解釈と実現

- 実際の運用が面倒くさくならないように、極力シンプルな構成を目指しています。
- 基本的に、ライブラリと実際の運用のフォルダ（名前空間）構成が一致するようにしています。
- 抽象度が高い順に、Domain(概念的設計)、App(動作的設計)、Adapter(環境的設計)、フレームワーク（エントリーポイント等）の４層で構成されます。
- フレームワーク層を除く全ての層は、名前空間内で１つ抽象度が高いの層の中に配置されます。（Adapter層の名前空間は `MyNameSpace.Domain.App.Adapter` です）
- フレームワーク層を除く全ての層は、直接の姉妹関係の位置に自身の抽象interfaceを持っています。（`MyNameSpace.Domain.App`と`MyNameSpace.Domain.IApp`）
  -	これらは言い換えると、（Adapterを除く）全ての層は１つ抽象度の低い層の実体とinterfaceを直下に持っているという事です。
- これらの構造により、例えば、Adapter層からAppやDomainのinterfaceを利用したいとき、名前空間内で`using IApp; using IDomain`とするだけで名前空間を解決する事が出来ます。また、誤って具象に依存している場合も一目で確認する事が出来ます。

### レールウェイ指向（Railway-Oriented）エラーハンドリング

- 簡単な実装ですが、`readonly ref struct CleanResult<TResult>`によるハイパフォーマンスな例外回避エラーハンドリングを実装、内部で利用しています。
- `class CleanResultBoxed<TResult>`との相互変換により、Box化やジェネリクス引数の要求にも対応できます。

# バージョン情報

- v0.x bata: とりあえず動く形の物を作成
- v1.x bata: DI Container (MimiCleanContainer) の実装と名前空間設計の見直しで、機能や思想を Clean Architecture に近づけた。
  - v1.1.x bata: Clean Architecture と DI Container と呼べるだけの必要最低限の機能を実装した。
  - v1.2.x bata: v1.1.x bata で実装した機能の小規模な拡張と最適化を実施した。
  - v1.3.x bata: Unityやツール開発での実際の利用を想定し、実用上不可欠な機能のほとんどを実装する。

# 開発背景

基本的にはゲーム開発（Unityや、自作開発ツール）の為に作成しました。色々と厳密に定義しようとすると実装も利用も面倒なので、可能な限り簡略化して利用しやすいライブラリを目指しています。

バグや機能要望があれば、[お気軽にIsuueください！](https://github.com/Studio-id-Game/MimiClean/issues)
