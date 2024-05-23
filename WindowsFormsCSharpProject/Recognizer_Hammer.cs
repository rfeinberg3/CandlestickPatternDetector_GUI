using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify Hammer candlesticks.
    /// </summary>
    internal class Recognizer_Hammer : Recognizer
    {
        public string name;
        public Recognizer_Hammer() : base()
        {
            name = "Hammer";
        }
        /// <summary>
        /// Sets Hammer boolean in Smartcandlestick Dictionary.
        /// if topShadow ~= 0 is true
        /// and bottomShadow > 1.8 deviations is true
        /// and bodyRange < 1.2 deviations is true
        /// then isHammer is set to true
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns>result</returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if ((candlestickList[index].topTail < 0 + candlestickList[index].deviation)
&& (candlestickList[index].topTail > 0 - candlestickList[index].deviation)
&& (candlestickList[index].bottomTail > candlestickList[index].deviation * 1.2)
&& (candlestickList[index].bodyRange < candlestickList[index].deviation * 1.8))
                result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets Hammer boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
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
