namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// <see cref="MimiServiceContainer"/> で利用するServiceのタイプを定義します。
    /// </summary>
    public enum MimiServiceType
    {
        None = 0,

        /// <summary>
        /// <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>と同じ内容を表します。
        /// </summary>
        Singleton = 1,

        /// <summary>
        /// <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped"/>と同じ内容を表します。
        /// </summary>
        Scoped = 2,

        /// <summary>
        /// <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient"/>と同じ内容を表します。
        /// </summary>
        Transient = 3,

        /// <summary>
        /// Static Type Caching を利用した高速なシングルトンサービスを表します。
        /// </summary>
        Static = 4,
    }
}
