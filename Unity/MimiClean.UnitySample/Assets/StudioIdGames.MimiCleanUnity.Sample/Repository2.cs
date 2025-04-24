using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;
using StudioIdGames.MimiClean.Collections;
using StudioIdGames.MimiClean.Domain.App;
using System;
using System.Collections.Generic;
using System.Threading;
using Random = UnityEngine.Random;

namespace Assets.StudioIdGames.MimiCleanUnity.Sample
{
    internal class Repository2 : RepositoryCleanResultMap<string, UniTask<string>>
    {
        private delegate UniTask<string> TaskCreater(CancellationToken ct);

        private readonly IReadOnlyDictionary<string, TaskCreater> dictionary = new Dictionary<string, TaskCreater>(StringComparer.OrdinalIgnoreCase)
        {
            ["Cat"] = async (ct) =>
            {
                await UniTask.Delay(Random.Range(1000, 2000), cancellationToken: ct);
                if (Random.Range(0f, 1f) < 0.75f)
                {
                    return "Cat-Nya!!";
                }
                else
                {
                    throw new Exception("Dummy Error");
                }
            },
            ["Dog"] = async (ct) =>
            {
                await UniTask.Delay(Random.Range(1000, 3000), cancellationToken: ct);
                if (Random.Range(0f, 1f) < 0.75f)
                {
                    return "Dog-Wan!!";
                }
                else
                {
                    throw new Exception("Dummy Error");
                }
            },
            ["Fox"] = async (ct) =>
            {
                await UniTask.Delay(Random.Range(1000, 4000), cancellationToken: ct);
                if (Random.Range(0f, 1f) < 0.75f)
                {
                    return "Fox-Con!!";
                }
                else
                {
                    throw new Exception("Dummy Error");
                }
            },
            ["Fish"] = async (ct) =>
            {
                await UniTask.Delay(Random.Range(1000, 5000), cancellationToken: ct);
                if (Random.Range(0f, 1f) < 0.75f)
                {
                    return "Fish-Pichi!!";
                }
                else
                {
                    throw new Exception("Dummy Error");
                }
            },
            ["Rat"] = async (ct) =>
            {
                await UniTask.Delay(Random.Range(1000, 6000), cancellationToken: ct);
                if (Random.Range(0f, 1f) < 0.75f)
                {
                    return "Rat-Chu!!";
                }
                else
                {
                    throw new Exception("Dummy Error");
                }
            }
        };

        public Repository2()
        {
            CleanResultMapProtected = new Map(dictionary);
        }

        protected override ICleanResultDictionary<string, UniTask<string>> CleanResultMapProtected { get; }

        private class Map : CleanResultDictionary<string, TaskCreater, UniTask<string>>
        {
            public Map(IReadOnlyDictionary<string, TaskCreater> dictionary) : base(dictionary)
            {
            }

            protected override CleanResult<UniTask<string>> GetResult(string key, TaskCreater value, bool isDefined, CancellationToken cancellationToken)
            {
                if (isDefined)
                {
                    return CleanResult.Success(value(cancellationToken));
                }
                else
                {
                    return CleanResult.Failed<UniTask<string>>(new KeyNotFoundException());
                }
            }
        }
    }
}
