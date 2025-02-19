namespace StudioIdGames.MimiClean.App
{
    /// <summary>
    /// Interactor内で問題があった場合のエラーを表現する抽象クラスです
    /// </summary>
    public abstract class InteractorError : CleanResultError
    {
        /// <summary>
        /// 問題元のInteractor
        /// </summary>
        public object Interactor { get; }

        /// <summary>
        /// <see cref="InteractorError"/> のコンストラクタ
        /// </summary>
        /// <param name="interactor">問題元のInteractor</param>
        protected InteractorError(object interactor)
        {
            Interactor = interactor;
        }

        /// <summary>
        /// 未実装のInteractorが呼び出された場合のエラーを表現する抽象クラスです
        /// </summary>
        public sealed class NotImplemented : InteractorError
        {
            /// <summary>
            /// <see cref="NotImplemented"/> のコンストラクタ
            /// </summary>
            /// <param name="interactor">問題元のInteractor</param>
            public NotImplemented(object interactor) : base(interactor)
            {
            }

            /// <inheritdoc/>
            public override string Message => $"the class {Interactor.GetType().Name} is not implemented.";
        }
    }
}
