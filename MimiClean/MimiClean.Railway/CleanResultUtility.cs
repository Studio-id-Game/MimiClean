using System;
using System.Linq;

namespace StudioIdGames.MimiClean.Railway
{
    internal static class CleanResultUtility
    {
        internal static CleanResult<T> Chain<TResult, T>(TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult, T> chainFunc)
        {
            var newValue = GetChainValue(out var chain, result, state, errorToken, chainFunc);
            return chain.With(newValue);
        }

        internal static CleanResult<NoResult> Chain<TResult>(TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult> chainFunc)
        {
            GetChainValue(out var chain, result, state, errorToken, chainFunc);
            return chain.With<NoResult>(default);
        }

        internal static void ChainTo<TResult, T>(ref CleanResult<T> newResult, TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult, T> chainFunc)
        {
            var newValue = GetChainValue(out var chain, result, state, errorToken, chainFunc);
            newResult = chain.With(newValue);
        }

        internal static void ChainTo<TResult>(ref CleanResult<NoResult> newResult, TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult> chainFunc)
        {
            GetChainValue(out var chain, result, state, errorToken, chainFunc);
            newResult = chain.With<NoResult>(default);
        }

        /// <summary>
        /// <code>
        /// var resultText = result == null ? "&lt;null&gt;" : $"\"{result}\"";
        /// var stateText = errorToken.Any() ?
        ///         $"{state} : \"{string.Join("\", \"", errorToken)}\"" : state.ToString();
        ///
        /// return $"{resultText} ({stateText})";
        /// </code>
        /// </summary>
        /// <returns></returns>
        internal static string ToString<TResult>(TResult result, CleanResultState state, CleanResultErrorToken errorToken)
        {
            var resultText = result == null ?
                    "<null>" : $"\"{result}\"";

            var stateText = errorToken.Any() ?
                    $"{state} : \"{string.Join("\", \"", errorToken)}\"" :
                    state.ToString();

            return $"{resultText} ({stateText})";
        }

        private static T GetChainValue<TResult, T>(out CleanResultErrorChain chain, TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult, T> chainFunc)
        {
            if (chainFunc == null)
            {
                throw new ArgumentNullException(nameof(chainFunc));
            }
            return chainFunc(result, state, chain = new CleanResultErrorChain(errorToken));
        }

        private static void GetChainValue<TResult>(out CleanResultErrorChain chain, TResult result, CleanResultState state, CleanResultErrorToken errorToken, CleanResultChainer<TResult> chainFunc)
        {
            if (chainFunc == null)
            {
                throw new ArgumentNullException(nameof(chainFunc));
            }
            chainFunc(result, state, chain = new CleanResultErrorChain(errorToken));
        }
    }
}
