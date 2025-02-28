namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using Domain.DomainType;

    /// <summary>
    /// メイン動作を選択して実行する時の入力データ
    /// </summary>
    /// <param name="mainAction">選択した動作</param>
    public readonly struct SelectMainActionInput(MainActions mainAction)
    {
        /// <summary>
        /// 選択した動作
        /// </summary>
        public readonly MainActions mainAction = mainAction;
    }
}
