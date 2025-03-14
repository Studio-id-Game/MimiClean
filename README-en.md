[日本語READMEはこちら](/README.md)

# MimiClean
Simple Clean-like Architecture Library for C# (.NET Standerd 2.0).

Developed by Studio-id-Games, hirohiroj3cub.

# Uses
This library can be used for the following purposes
- Hierarchical design like Clean Architecture.
- To resolve dependencies like Dependency Injection.
- To achieve these goals as simply as possible, in a variety of environments, and with as few exceptions as possible.

# Main Features

- High-performance, concise dependency resolution using proprietary DIContainer (MimiCleanContainer) that extends and encapsulates Microsoft.Extensions.DependencyInjection
- High-performance Railway-Oriented error handling using ref struct
- Clean-like Architecture hierarchical design suitable for C# name resolution and syntax specification

# How to use

This project is MIT licensed. Since we do not provide the built file now, please build it by yourself with VisualStudio or other software, and place/reference the dll in your favorite place. This project was created with .Net Standerd 2.0, so it can be used in various environments.

Please refer to [Sample Project](/MimiClean/MimiCleanSample) and [API Reference](https://studio-id-game.github.io/MimiClean/api/StudioIdGames) for more information. We plan to distribute compiled .dll files and provide documentation for a simple introduction to the classes at a later date.

# Functional Overview and Performance

## About MimiCleanContainer

### Static Mode

In addition to the Singleton, Scoped, and Transient service types of Microsoft.Extensions.DependencyInjection, we have implemented a high-performance Static service type that uses a static generic cache.
BenchmarkDotNet validation results confirm that it actually works at about 7% of the time cost of Singleton.

#### Instance invocation speed measured by BenchmarkDotNet (COUNT = 10,000)

| Method | Mean | Error | StdDev |
|-----------|----------:|----------:|---------:|
Scoped | 55.128 µs | 1.9950 µs | 0.1094 µs | Transient | 58.733 µs
Transient | 58.733 µs | 23.3906 µs | 1.2821 µs | Singleton | 40.426 µs | 1.9994 µs | 0.1094 µs
Singleton | 40.426 µs | 5.9840 µs | 0.3280 µs | Static | 2.823 µs
| Static | 2.823 µs | 0.0584 µs | 0.0032 µs

#### Instance Call Speed Measured by BenchmarkDotNet (COUNT = 1,000,000)

| Method | Mean | Error | StdDev |
|-----------|----------:|----------:|---------:|
| Scoped | 5,400.4 µs | 278.15 µs | 15.25 µs | Transient | 6,005.5 µs | 6,005.5 µs | 6,005.5 µs
Transient | 6,005.7 µs | 410.92 µs | 22.52 µs | Singleton | 3,952 µs | 3,952 µs | 3,999.5 µs
Singleton | 3,952.1 µs | 123.56 µs | 6.77 µs | Static | 282.7 µs | 15.25 µs
| Static | 282.7 µs | 5.61 µs | 0.31 µs

### Default factory

Manual pre-registration of default factory by `MimiServiceDefault<TInterface>.Set<TInstance>()`.
- Defining a default for each design hierarchy eliminates the need for assembly analysis and clarifies responsibilities. [MimiClean_Sample/Domain/DomainSetup.cs](/MimiClean/MimiClean_Sample/Domain/DomainSetup.cs)
- With `MimiServiceDefault<TInterface>.Ref<TRefTo>()`, you can also describe behavior like transfer to a derived class. 

### Specifying service type by Attribute

- MimiServiceTypeAttribute can be attached to a class or interface to dynamically determine the service type. (The result is cached, so there is no significant cost.)

## About MimiClean

### Interpretation and realization of Clean Architecture in MimiClean

- We aim to keep the architecture as simple as possible so that the actual operation does not become cumbersome.
- Basically, the folder (namespace) structure of the library and the user should be the same.
- In order of increasing abstraction, the architecture consists of four layers: Domain (conceptual design), App (behavioral design), Adapter (Environmental design), and Framework (entry points, etc.).
- All layers except the framework layer are placed under a namespace of layer that one higher level of abstraction layer. (The namespace of the Adapter layer is `MyNameSpace.Domain.App.Adapter`).
- All layers except the framework layer have their own abstract interface at a direct sibling namespace. (`MyNameSpace.Domain.App` and `MyNameSpace.Domain.IApp`)
  - In other words, every layer (except Adapter) has one lower level of abstract layer and concrete layer directly under it.
- With these structures, for example, when you want to use an App or Domain interface from the Adapter layer, you can simply resolve the namespace by `using IApp; using IDomain` inside the namespace. You can also check at a glance if you accidentally depend on a concrete object.

### About Railway-Oriented (Railway-Oriented) Error Handling

- A simple implementation of high-performance exception-avoidance error handling with `readonly ref struct CleanResult<TResult>` is implemented and used internally.
- Interconversion with `class CleanResultBoxed<TResult>` to support Boxing and generics argument requests.

# Version Information

- v0.x : Created a working form for now
- v1.x bata: Implemented DI Container (MimiCleanContainer) and redesigned namespace to make it closer to Clean Architecture in functionality and philosophy.
  - v1.1.x bata: Implemented the minimum functionality required to be called Clean Architecture and DI Container.
  - v1.2.x bata: Minor enhancements and optimizations to the features implemented in v1.1.x bata.
  - v1.3.x bata: Implement most of the essential features for practical use in tool development.
  - v1.4.x bata: Support Unity (UniTask) and make some simple performance improvements.

# Development Background

Basically, it was created for game development (Unity, my own development tool). Since trying to define it strictly would make it cumbersome to implement and use, we aim to make it as simple and easy to use as possible.

If you have any bugs or feature requests, [please feel free to Issue us!] (https://github.com/Studio-id-Game/MimiClean/issues)

# Translation Tool

Translated with DeepL.com (free version)