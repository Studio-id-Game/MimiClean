namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// デフォルトのServiceTypeが <see cref="MimiServiceType.Transient"/> である、 <see cref="MimiServiceContainer"/>で利用できるServiceを抽象化します。
    /// </summary>
    [MimiServiceType(MimiServiceType.Transient)]
    public interface ITransientService : IMimiService
    {
    }
}
