using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify GravestoneDoji candlesticks.
    /// </summary>
    internal class Recognizer_GravestoneDoji : Recognizer
    {
        public string name;
        public Recognizer_GravestoneDoji() : base()
        {
            name = "GravestoneDoji";
        }
        /// <summary>
        /// Sets GravestoneDoji boolean in Smartcandlestick Dictionary.
        /// if isDoji is true
        /// and bottomShadow ~= 0 is true
        /// and topShadow > 2 deviations
        /// then isDragonFLyDoji is set to true.
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns>result</returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if (candlestickList[index].booleans["Doji"] && (candlestickList[index].bottomTail < 0 + candlestickList[index].deviation)
&& (candlestickList[index].bottomTail > 0 - candlestickList[index].deviation)
&& (candlestickList[index].topTail > candlestickList[index].deviation * 1.2))
                result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets GravestoneDoji boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
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
