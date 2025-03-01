﻿using StudioIdGames.MimiClean.Domain;
using StudioIdGames.MimiClean.Domain.IApp;
using StudioIdGames.MimiClean.IDomain;

namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using IDomain.IModule;

    /// <summary>
    /// <see cref="IItemModuleSet{TInt2D}"/>を実装します。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    /// <param name="nameModule"></param>
    /// <param name="int2DPosModule"></param>
    /// <param name="currentEntity"></param>
    /// <param name="moduleName"></param>
    public sealed class ItemModuleSet<TInt2D>(INameModule nameModule, IInt2DPosModule<TInt2D> int2DPosModule, ICurrentEntityService currentEntity, string? moduleName = null) : DomainModuleSet(currentEntity, moduleName), IItemModuleSet<TInt2D>
    {
        public override int Count => base.Count + 2;

        public INameModule NameModule { get; } = nameModule;

        public IInt2DPosModule<TInt2D> Int2DPosModule { get; } = int2DPosModule;

        IInt2DPosModule IItemModuleSet.Int2DPosModule => Int2DPosModule;

        public string ItemName { get => NameModule.ItemName; set => NameModule.ItemName = value; }

        public TInt2D XY { get => Int2DPosModule.XY; set => Int2DPosModule.XY = value; }

        public int X { get => Int2DPosModule.X; set => Int2DPosModule.X = value; }

        public int Y { get => Int2DPosModule.Y; set => Int2DPosModule.Y = value; }

        public override IEnumerable<T> Get<T>()
        {
            if (NameModule is T nameModuleT) yield return nameModuleT;
            if (Int2DPosModule is T int2DPosModuleT) yield return int2DPosModuleT;
            foreach (var item in base.Get<T>())
            {
                yield return item;
            }
        }

        public override IEnumerator<IDomainModule> GetEnumerator()
        {
            yield return NameModule;
            yield return Int2DPosModule;
            foreach (var module in CustomModules)
            {
                yield return module;
            }
        }
    }
}
