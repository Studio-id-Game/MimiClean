using Assets.StudioIdGames.MimiCleanUnity.Runtime.CleanResultUniTask;
using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;
using System;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StudioIdGames.MimiCleanUnity.Sample
{
    public class SampleController2 : MonoBehaviour
    {
        [Serializable]
        public struct NamedText
        {
            public string name;
            public Text text;
        }

        public Button startTrg;
        public Button cancelTrg;
        public TextTimer timer;
        public NamedText[] texts;

        private Repository2 repository;
        private CancellationTokenSource workTaskCts;
        private UniTask? workTask;

        private void OnEnable()
        {
            repository ??= new();
            startTrg.onClick.AddListener(StartTrg_onClick);
            cancelTrg.onClick.AddListener(CancelTrg_onClick);
            timer.TimerStop(this);

            foreach (var namedText in texts)
            {
                namedText.text.text = namedText.name;
            }
        }

        private void OnDisable()
        {
            startTrg.onClick.RemoveListener(StartTrg_onClick);
            cancelTrg.onClick.RemoveListener(CancelTrg_onClick);
            timer.TimerStop(this);

            foreach (var namedText in texts)
            {
                namedText.text.text = namedText.name;
            }
        }

        private void StartTrg_onClick() => StartProcess().Forget();

        private void CancelTrg_onClick() => CancelProcess().Forget();

        private async UniTask StartProcess()
        {
            var cancelResult = await CancelProcess();

            workTask = UniTask.Create(async (workTaskCt) =>
            {
                var runTasks = texts.Length;

                UniTask.Void(async () =>
                {
                    timer.TimerStart(this);
                    await UniTask.WaitWhile(() => runTasks > 0);
                    timer.TimerStop(this);
                });

                var tasks = texts.Select(async namedText =>
                {
                    var result = cancelResult.As("");

                    if (result)
                    {
                        var loadAnimeCts = new CancellationTokenSource();
                        UniTask.Void(async loadAnimeCt =>
                        {
                            namedText.text.text = "Ready";
                            for (int i = 0; i < 30; i++)
                            {
                                await UniTask.Delay(300, cancellationToken: loadAnimeCt);

                                if (loadAnimeCt.IsCancellationRequested)
                                {
                                    break;
                                }
                                else
                                {
                                    namedText.text.text += ".";
                                }
                            }
                        }, loadAnimeCts.Token);

                        try
                        {
                            result = (await repository.GetValue(namedText.name, workTaskCt)).Struct();
                        }
                        catch (Exception e)
                        {
                            result = CleanResultStruct<string>.Failed(e);
                        }

                        loadAnimeCts.Cancel();
                    }

                    runTasks--;

                    UniTask resultDelay;
                    switch (result.State)
                    {
                        case CleanResultState.Success:
                            resultDelay = UniTask.Delay(3000, cancellationToken: workTaskCt);
                            break;

                        case CleanResultState.Canceled:
                            result = CleanResult.Success("Now Stopping...").Struct();
                            resultDelay = UniTask.Delay(1000).AsCleanResult();
                            break;

                        case CleanResultState.Failed:
                        default:
                            result = CleanResult.Success($"Error : {result.Error}").Struct();
                            resultDelay = UniTask.Delay(3000, cancellationToken: workTaskCt);
                            break;
                    }

                    if (result)
                    {
                        namedText.text.text = result;
                        await resultDelay.AsCleanResult();
                        result = result.As(namedText.name);
                    }

                    if (result)
                    {
                        namedText.text.text = result;
                    }
                });

                await UniTask.WhenAll(tasks);

                workTask = null;
            }, workTaskCts.Token);
        }

        private async UniTask<CleanResultStruct<CleanResult.Void>> CancelProcess()
        {
            try
            {
                if (workTaskCts != null)
                {
                    workTaskCts.Cancel();
                    workTaskCts.Dispose();
                }

                workTaskCts = new CancellationTokenSource();

                if (workTask.HasValue)
                {
                    startTrg.interactable = false;
                    cancelTrg.interactable = false;

                    var result = (await workTask.Value.AttachExternalCancellation(workTaskCts.Token).AsCleanResult()).Struct();

                    workTask = null;
                    startTrg.interactable = true;
                    cancelTrg.interactable = true;

                    return result;
                }
                else
                {
                    return CleanResultStruct<CleanResult.Void>.Success(default);
                }
            }
            catch (Exception e)
            {
                return CleanResultStruct<CleanResult.Void>.Failed(e);
            }
        }
    }
}
