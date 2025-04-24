using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Collections;
using StudioIdGames.MimiClean.Domain.App;
using System.Threading;
using UnityEngine;

namespace Assets.StudioIdGames.MimiCleanUnity.Sample
{
    internal class Repository : RepositoryCleanResultMono<UniTask<string>>
    {
        private class Res : CleanResultMonoCollection<UniTask<string>>
        {
            public override CleanResult<UniTask<string>> Value => CleanResult.Success(GetValueAsync());

            public override CleanResult<UniTask<string>> GetValue(CancellationToken cancellationToken)
            {
                return CleanResult.Success(GetValueAsync(cancellationToken));
            }

            private async UniTask<string> GetValueAsync()
            {
                await UniTask.Delay(Random.Range(1000, 2000));

                if (Random.Range(0f, 1f) > 0.75) throw new System.Exception("Dummy Error");

                if (Random.Range(0.0f, 1.0f) < 0.5f)
                {
                    return "Hi!";
                }
                else
                {
                    return "Hello!";
                }
            }

            private async UniTask<string> GetValueAsync(CancellationToken cancellationToken)
            {
                await UniTask.Delay(Random.Range(1000, 2000), cancellationToken: cancellationToken);

                if (Random.Range(0f, 1f) > 0.75) throw new System.Exception("Dummy Error");

                if (Random.Range(0.0f, 1.0f) < 0.5f)
                {
                    return "Hi!";
                }
                else
                {
                    return "Hello!";
                }
            }
        }

        private readonly Res res = new();

        protected override ICleanResultMonoCollection<UniTask<string>> ValueCleanResultProtected => res;
    }
}
