namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// デフォルトのServiceTypeが <see cref="MimiServiceType.Singleton"/> である、 <see cref="MimiServiceContainer"/>で利用できるServiceを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Singleton)]
    public interface ISingletonService : IMimiService
    {
    }
}
