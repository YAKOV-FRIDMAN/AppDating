using MaterialDesignThemes.Wpf.Converters.CircularProgressBar;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppDating.Utils
{
    class Record
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        public bool RecordOn { get; private set; }
        public void StartRecord()
        {
            RecordOn = true;
            mciSendString("open new Type waveaudio alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
           
        }

       
        public void StopRecord(string fileName)
        {
            RecordOn = false;
            mciSendString($@"save recsound {fileName}.wav", "", 0, 0);
            mciSendString("close recsound ", "", 0, 0);
          
        }
    }
}
