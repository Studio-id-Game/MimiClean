namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// デフォルトのServiceTypeが <see cref="MimiServiceType.Scoped"/> である、 <see cref="MimiServiceContainer"/>で利用できるServiceを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Scoped)]
    public interface IScopedService : IMimiService
    {
    }
}
