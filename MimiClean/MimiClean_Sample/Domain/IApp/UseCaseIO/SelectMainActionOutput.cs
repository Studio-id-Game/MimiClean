namespace StudioIdGames.MimiClean_Sample.Domain.IApp.UseCaseIO
{
    using Domain.DomainType;

    /// <summary>
    /// メイン動作を選択して実行した時の出力データ
    /// </summary>
    /// <param name="mainAction">選択した動作</param>
    public readonly struct SelectMainActionOutput(MainActions mainAction)
    {
        /// <summary>
        /// 選択した動作
        /// </summary>
        public readonly MainActions mainAction = mainAction;
    }
}
