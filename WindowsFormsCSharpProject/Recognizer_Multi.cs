using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Class object used to recognize 3 candlestick patterns: Peaks and Valleys.
    /// </summary>
    internal class Recognizer_Multi
    {

        /// <summary>
        /// If the candlestick to the left and right of the current candlestick is less then the 
        /// current candlestick, set the "Peak" value in booleans to true. Otherwise set it to false.
        /// </summary>
        /// <param name="candlestickList"></param>
        public void RecognizePeaks(List<SmartCandlestick> candlestickList)
        {
            for (int i = 1; i < candlestickList.Count-1; i++)
            {
                if ((candlestickList[i - 1].high < candlestickList[i].high)
                    && (candlestickList[i].high > candlestickList[i + 1].high))
                {
                    candlestickList[i].booleans["Peak"] = true;
                }
                else
                {
                    candlestickList[i].booleans["Peak"] = false;
                }
            }
        }

        /// <summary>
        /// If the candlestick to the left and right of the current candlestick is greater then the 
        /// current candlestick, set the "Valley" value in booleans to true. Otherwise set it to false.
        /// </summary>
        /// <param name="candlestickList"></param>
        public void RecognizeValleys(List<SmartCandlestick> candlestickList)
        {
            for (int i = 1; i < candlestickList.Count-1; i++)
            {
                if ((candlestickList[i - 1].low > candlestickList[i].low)
                    && (candlestickList[i].low < candlestickList[i + 1].low))
                {
                    candlestickList[i].booleans["Valley"] = true;
                }
                else
                {
                    candlestickList[i].booleans["Valley"] = false;
                }
            }
        }
    }
}
