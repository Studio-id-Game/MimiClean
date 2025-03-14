﻿using System;

namespace StudioIdGames.MimiCleanContainer
{
    /// <summary>
    /// MimiServiceが実装するカスタム動作を考慮できる <see cref="IServiceProvider"/> のカスタム実装です。
    /// </summary>
    public class MimiServiceProvider : IServiceProvider
    {
        /// <summary>
        /// ベースとなっている<see cref="IServiceProvider"/>
        /// </summary>
        public IServiceProvider BaseProvider { get; }

        /// <summary>
        /// <paramref name="baseProvider"/>を元にして<see cref="MimiServiceProvider"/>インスタンスを作成します。
        /// </summary>
        /// <param name="baseProvider"></param>
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
        /// <typeparamref name="T"/>型のserviceに一時的にアクセスし、<paramref name="config"/> によって読み取りや書き込みをします。また、チェーンで記述できるように戻り値として自身を返します。
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

        /// <inheritdoc/>
        public object GetService(Type serviceType)
        {
            return BaseProvider.GetService(serviceType);
        }
    }
}
