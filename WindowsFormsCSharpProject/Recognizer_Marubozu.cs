using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify Marubozu candlesticks.
    /// </summary>
    internal class Recognizer_Marubozu : Recognizer
    {
        public string name;
        public Recognizer_Marubozu() : base()
        {
            name = "Marubozu";
        }
        /// <summary>
        /// Sets Marubozu boolean in Smartcandlestick Dictionary.
        /// if topShadow ~= 0 is true
        /// and bottomShadow ~= 0 is true
        /// and range > 5 deviations
        /// then isMarubozu is set to true
        ///
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns>result</returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if (((candlestickList[index].topTail < 0 + candlestickList[index].deviation) && (candlestickList[index].topTail > 0 - candlestickList[index].deviation))
            && ((candlestickList[index].bottomTail < 0 + candlestickList[index].deviation) && (candlestickList[index].bottomTail > 0 - candlestickList[index].deviation))
              && (Math.Abs(candlestickList[index].bodyRange) > candlestickList[index].deviation * 2))
                result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets Marubozu boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
        /// </summary>
        /// <param name="candlestickList"></param>
        public override void RecognizeAll(List<SmartCandlestick> candlestickList)
        {
            for (int i = 0; i < candlestickList.Count(); i++)
            {
                candlestickList[i].booleans[name] = Recognize(candlestickList, i);
            }
        }
    }
}
