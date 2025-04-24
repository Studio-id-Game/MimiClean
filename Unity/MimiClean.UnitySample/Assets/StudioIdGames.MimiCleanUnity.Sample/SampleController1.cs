using Cysharp.Threading.Tasks;
using StudioIdGames.MimiClean;
using Assets.StudioIdGames.MimiCleanUnity.Runtime.CleanResultUniTask;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StudioIdGames.MimiCleanUnity.Sample
{
    public class SampleController1 : MonoBehaviour
    {
        private const string DEFAULT_TEXT = "Push Button";

        public Button startTrg;
        public Button cancelTrg;
        public TextTimer timer;
        public Text text;

        private Repository repository;
        private CancellationTokenSource workTaskCts;
        private UniTask? workTask;

        private void OnEnable()
        {
            workTaskCts = new CancellationTokenSource();

            repository ??= new();
            startTrg.onClick.AddListener(StartTrg_onClick);
            cancelTrg.onClick.AddListener(CancelTrg_onClick);
            text.text = DEFAULT_TEXT;
            timer.TimerStop(this);
        }

        private void OnDisable()
        {
            startTrg.onClick.RemoveListener(StartTrg_onClick);
            cancelTrg.onClick.RemoveListener(CancelTrg_onClick);
            text.text = DEFAULT_TEXT;
            timer.TimerStop(this);

            workTaskCts.Dispose();
            workTask = null;
        }

        private async void StartTrg_onClick() => await StartProcess();

        private async void CancelTrg_onClick() => await CancelProcess();

        private async UniTask StartProcess()
        {
            var cancelResult = await CancelProcess();
            var result = cancelResult.As("");

            var workTaskCt = workTaskCts.Token;
            workTask = UniTask.Create(async (workTaskCt) =>
            {
                timer.TimerStart(this);

                if (result)
                {
                    using var loadAnimeCts = new CancellationTokenSource();
                    UniTask.Create(async loadAnimeCt =>
                    {
                        text.text = "Ready";
                        for (int i = 0; i < 30; i++)
                        {
                            await UniTask.Delay(100, cancellationToken: loadAnimeCt);

                            if (loadAnimeCt.IsCancellationRequested)
                            {
                                break;
                            }
                            else
                            {
                                text.text += ".";
                            }
                        }
                    }, loadAnimeCts.Token).Forget();

                    try
                    {
                        result = (await repository.GetValue(workTaskCt)).Struct();
                    }
                    catch (System.Exception e)
                    {
                        result = CleanResultStruct<string>.Failed(e);
                    }
                    finally
                    {
                        loadAnimeCts.Cancel();
                    }
                }

                timer.TimerStop(this);

                UniTask resultDelay;
                switch (result.State)
                {
                    case CleanResultState.Success:
                        resultDelay = UniTask.Delay(3000, cancellationToken: workTaskCt);
                        break;

                    case CleanResultState.Canceled:
                        result = CleanResult.Success("Now Stopping...").Struct();
                        resultDelay = UniTask.Delay(1000);
                        break;

                    case CleanResultState.Failed:
                    default:
                        result = CleanResult.Success($"Error : {result.Error}\n\n Please retry!").Struct();
                        resultDelay = UniTask.Delay(3000, cancellationToken: workTaskCt);
                        break;
                }

                if (result)
                {
                    text.text = result;
                    await resultDelay.AsCleanResult();
                    result = CleanResult.Success(DEFAULT_TEXT).Struct();
                }

                if (result)
                {
                    text.text = result;
                }

                workTask = null;
            }, workTaskCt);
        }

        private async UniTask<CleanResultStruct<CleanResult.Void>> CancelProcess()
        {
            CleanResultStruct<CleanResult.Void> result;

            try
            {
                if (workTask.HasValue)
                {
                    startTrg.interactable = false;
                    cancelTrg.interactable = false;

                    workTaskCts.Cancel();
                    result = (await workTask.Value.AsCleanResult()).Struct();
                    workTaskCts.Dispose();
                    workTaskCts = new CancellationTokenSource();

                    workTask = null;
                    startTrg.interactable = true;
                    cancelTrg.interactable = true;
                }
                else
                {
                    result = CleanResult.Success().Struct();
                }
            }
            catch (System.Exception e)
            {
                result = CleanResult.Failed(e).Struct();
            }

            return result;
        }
    }
}
