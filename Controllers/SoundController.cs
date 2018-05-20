using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class SoundController : ApiController
    {

        private static WaveOutEvent waveOut;
        [HttpGet]
        public void Play(int id)
        {
            var t = new Thread(() => StartPlay(id));
            t.Start();
        }

        [HttpGet]
        public void Stop()
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Playing)
                waveOut.Stop();
        }



            private void StartPlay(int location)
        {

          //  if (waveOut == null)
           // {
                waveOut = new WaveOutEvent();
                waveOut.DeviceNumber = location;
                //devicenumber - порядковый номер звуковой карты
                var mp3Reader = new Mp3FileReader("C:\\Media\\b.mp3");
                waveOut.Init(mp3Reader);
         //   }
            waveOut.Play();
        }

    }
}

//http://localhost:55525/api/Sound/play