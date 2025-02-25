using System.Collections.Generic;

namespace StudioIdGames.MimiClean.IDomain
{
    /// <summary>
    /// <see cref="IDomainModule"/>の特定の組み合わせを表現するインターフェースです。
    /// </summary>
    public interface IDomainModuleSet : IDomainModule, IEnumerable<IDomainModule>
    {

        /// <summary>
        /// セット内のモジュールの数
        /// </summary>
        int Count { get; }

        /// <summary>
        /// このセットに含まれる<see cref="DomainModule{TDomainEntity}"/>を列挙します。
        /// </summary>
        /// <typeparam name="T">列挙するモジュールの型フィルター</typeparam>
        /// <returns>結果の列挙体</returns>
        IEnumerable<T> Get<T>() where T : class, IDomainModule;

        /// <summary>
        /// デフォルトコンストラクタを持ったモジュールをセットに追加します。
        /// </summary>
        /// <typeparam name="T">追加するモジュールのクラス</typeparam>
        /// <returns>追加に成功した時のみtrue</returns>
        bool Add<T>() where T : class, IDomainModule, new();

        /// <summary>
        /// モジュールをセットに追加します。
        /// </summary>
        /// <typeparam name="T">追加するモジュールのクラス</typeparam>
        /// <param name="value">追加するモジュールのインスタンス</param>
        /// <returns>追加に成功した時のみtrue</returns>
        bool Add<T>(T value) where T : class, IDomainModule;

        /// <summary>
        /// モジュールをセットから除外します。
        /// </summary>
        /// <typeparam name="T">除外するモジュールのクラス</typeparam>
        /// <param name="value">除外するモジュールのインスタンス</param>
        /// <returns>除外に成功した時のみtrue</returns>
        bool Remove<T>(T value) where T : class, IDomainModule;
    }
}
