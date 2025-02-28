using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// MimiServiceが実装するカスタム動作を考慮できる <see cref="IServiceProvider"/> のカスタム実装です。
    /// </summary>
    public class MimiServiceProvider : IServiceProvider
    {
        public IServiceProvider BaseProvider { get; }

        public MimiServiceProvider(IServiceProvider baseProvider)
        {
            BaseProvider = baseProvider;
        }

        /// <inheritdoc cref="MimiServiceProviderExtension.GetMimiService{T}(IServiceProvider)"/>
        public T GetService<T>()
            where T : class, IMimiService
        {
            return BaseProvider.GetMimiService<T>();
        }

        /// <summary>
        /// <typeparamref name="T"/>型のserviceに一時的にアクセスし、<paramref name="config"/> によって変更を加えます。また、チェーンで記述できるように戻り値として自身を返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config">チェーン可能な自身の参照</param>
        /// <returns></returns>
        public MimiServiceProvider Config<T>(Action<T> config)
            where T : class, IMimiService
        {
            config?.Invoke(BaseProvider.GetMimiService<T>());
            return this;
        }

        public object GetService(Type serviceType)
        {
            return BaseProvider.GetService(serviceType);
        }
    }
}
