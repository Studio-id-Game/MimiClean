namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// デフォルトのServiceTypeが <see cref="MimiServiceType.Static"/> である、 <see cref="MimiServiceContainer"/>で利用できるServiceを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Static)]
    public interface IStaticService : IMimiService
    {
    }
}
