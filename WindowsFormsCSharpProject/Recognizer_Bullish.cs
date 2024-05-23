using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify candlesticks as Bullish or not.
    /// </summary>
    internal class Recognizer_Bullish : Recognizer
    {
        public string name;
        public Recognizer_Bullish() : base() {
            name = "Bullish";
        }
        /// <summary>
        /// Sets Bullish boolean in Smartcandlestick Dictionary
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if (candlestickList[index].bodyRange > 0) result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets Bullish boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
        /// </summary>
        /// <param name="candlestickList"></param>
        public override void RecognizeAll(List<SmartCandlestick> candlestickList)
        {
            for (int i = 0; i < candlestickList.Count(); i++)
            {
                candlestickList[i].booleans[name] = Recognize(candlestickList, i);
            }
        }

        /// <summary>
        /// If the bodyRange and range of the previous candlestick is less then the  bodyRange and range of the current candlestick.
        /// And the previous candlestick is opposite the current candlesticks polarity 
        /// Then add the adjust the candlestick preperto accordingly.
        /// </summary>
        /// <param name="candlestickList"></param>
        public void RecognizeEngulfing(List<SmartCandlestick> candlestickList)
        {
            for (int i = candlestickList.Count - 2; i >= 0; i--)
            {
                if ((candlestickList[i + 1].bodyRange < candlestickList[i].bodyRange)
                    && (candlestickList[i + 1].range < candlestickList[i].range)
                    && (candlestickList[i + 1].high < candlestickList[i].high)
                    && (candlestickList[i + 1].low > candlestickList[i].low)
                    && (!Recognize(candlestickList, i + 1))
                    && (Recognize(candlestickList, i)))
                {
                    candlestickList[i].booleans["BullishEngulfing"] = true;
                }
                else
                {
                    candlestickList[i].booleans["BullishEngulfing"] = false;
                }
            }
        }

        /// <summary>
        /// If the bodyRange and range of the previous candlestick is more then the  bodyRange and range of the current candlestick.
        /// And the previous candlestick is opposite the current candlesticks polarity 
        /// Then add the adjust the candlestick preperto accordingly.
        /// </summary>
        /// <param name="candlestickList"></param>
        public void RecognizeHarami(List<SmartCandlestick> candlestickList)
        {
            for (int i = candlestickList.Count - 2; i >= 0; i--)
            {
                if ((candlestickList[i + 1].bodyRange > candlestickList[i].bodyRange)
                    && (candlestickList[i + 1].range > candlestickList[i].range)
                    && (candlestickList[i + 1].high > candlestickList[i].high)
                    && (candlestickList[i + 1].low < candlestickList[i].low)
                    && (!Recognize(candlestickList, i + 1))
                    && (Recognize(candlestickList, i)))
                {
                    candlestickList[i].booleans["BullishHarami"] = true;
                }
                else
                {
                    candlestickList[i].booleans["BullishHarami"] = false;
                }
            }
        }
    }
}
