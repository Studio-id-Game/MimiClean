using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.StudioIdGames.MimiCleanUnity.Sample
{
    public class TextTimer : MonoBehaviour
    {
        public Text text;

        private object key;
        private DateTime startTime = DateTime.MinValue;
        private DateTime stopTime = DateTime.MinValue;

        public void TimerStart(object key)
        {
            this.key = key;
            startTime = DateTime.Now;
            stopTime = DateTime.MinValue;
        }

        public void TimerStop(object key)
        {
            if (key == this.key)
            {
                stopTime = DateTime.Now;
                this.key = null;
            }
        }

        private void Update()
        {
            if (key != null)
            {
                text.text = (DateTime.Now - startTime).ToString();
            }
            else
            {
                text.text = (stopTime - startTime).ToString();
            }
        }
    }
}
