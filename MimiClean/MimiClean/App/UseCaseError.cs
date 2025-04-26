namespace StudioIdGames.MimiClean.App
{
    using IApp;
    using StudioIdGames.MimiClean.Railway;

    /// <summary>
    /// Usecase内で問題があった場合のエラーを表現する抽象クラスです
    /// </summary>
    public abstract class UseCaseError : CleanResultError
    {
        /// <summary>
        /// 問題元のInteractor
        /// </summary>
        public IAppUseCase UseCase { get; }

        /// <summary>
        /// <see cref="UseCaseError"/> のコンストラクタ
        /// </summary>
        /// <param name="useCase">問題元のInteractor</param>
        protected UseCaseError(IAppUseCase useCase)
        {
            UseCase = useCase;
        }

        /// <inheritdoc/>
        public override string Message => DefaultErrorMessage();

        /// <summary>
        /// デフォルトのエラー文
        /// </summary>
        /// <param name="errorName"></param>
        /// <returns></returns>
        protected virtual string DefaultErrorMessage(string errorName = null)
        {
            return $"`{errorName ?? GetType().Name}` Error in Usecase `{UseCase.GetType().Name}`.";
        }

        /// <summary>
        /// 未実装のUsecaseが呼び出された場合のエラーを表現する抽象クラスです
        /// </summary>
        public sealed class NotImplemented : UseCaseError
        {
            /// <summary>
            /// <see cref="NotImplemented"/> のコンストラクタ
            /// </summary>
            /// <param name="useCase">問題元のInteractor</param>
            public NotImplemented(IAppUseCase useCase) : base(useCase)
            {
            }
        }
    }

    /// <summary>
    /// Usecase内で問題があった場合の、情報オブジェクトを持ったエラーを表現する抽象クラスです
    /// </summary>
    public abstract class UseCaseError<TCaseInfo> : UseCaseError
    {
        /// <summary>
        /// エラーの種別情報
        /// </summary>
        public TCaseInfo ErrorCase { get; }

        /// <inheritdoc/>
        protected UseCaseError(IAppUseCase useCase, TCaseInfo errorCase) : base(useCase)
        {
            ErrorCase = errorCase;
        }

        /// <inheritdoc/>
        public sealed override string Message => ErrorCaseMessage(ErrorCase);

        /// <summary>
        /// エラーの種別情報を文字列化するメソッド
        /// </summary>
        /// <param name="caseInfo"></param>
        /// <returns></returns>
        protected virtual string ErrorCaseMessage(TCaseInfo caseInfo)
        {
            return DefaultErrorMessage(caseInfo.ToString());
        }

        /// <inheritdoc/>
        protected override string DefaultErrorMessage(string errorName = null)
        {
            return base.DefaultErrorMessage($"{GetType().Name} - {errorName}");
        }
    }
}
