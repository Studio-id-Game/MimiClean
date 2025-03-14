namespace StudioIdGames.MimiClean_Sample.Domain.Module
{
    using IApp.IService;
    using StudioIdGames.MimiClean.Domain;
    using StudioIdGames.MimiClean_Sample.IDomain;

    /// <summary>
    /// <see cref="IInt2DPosProperty{TInt2D}"/>を実装するモジュールです。
    /// </summary>
    /// <typeparam name="TInt2D"></typeparam>
    public sealed class Int2DPosModule<TInt2D> : DomainModule, IInt2DPosProperty<TInt2D>
    {
        /// <param name="int2d"></param>
        /// <param name="entity"></param>
        /// <param name="moduleName"></param>
        public Int2DPosModule(DomainEntity entity, Func<IInt2DService<TInt2D>> int2d, string? moduleName = null) :
            base(entity, moduleName)
        {
            this.int2d = int2d ?? throw new ArgumentNullException(nameof(int2d));
            XY = Int2d.New(0, 0);
        }

        private readonly Func<IInt2DService<TInt2D>> int2d;

        private IInt2DService<TInt2D> Int2d => int2d();

        /// <inheritdoc/>
        public TInt2D XY { get; set; }

        /// <inheritdoc/>
        public int X
        {
            get => Int2d.GetX(XY);
            set => XY = Int2d.New(value, Int2d.GetY(XY));
        }

        /// <inheritdoc/>
        public int Y
        {
            get => Int2d.GetY(XY);
            set => XY = Int2d.New(Int2d.GetX(XY), value);
        }
    }
}
