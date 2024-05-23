using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify Neutral candlesticks.
    /// </summary>
    internal class Recognizer_Neutral : Recognizer
    {
        public string name;
        public Recognizer_Neutral() : base()
        {
            name = "Neutral";
        }
        /// <summary>
        /// Sets Neutral boolean in Smartcandlestick Dictionary.
        /// if bodyRange ~= 0 is true
        /// and bodyRange <= topShadow is true
        /// and topShadow - bottomShadow ~= 0 is true
        /// then isNeutral is set to true
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns>result</returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if (((candlestickList[index].bodyRange < 0 + candlestickList[index].deviation / 2)
                    && (candlestickList[index].bodyRange > 0 - candlestickList[index].deviation / 2))
                    && ((candlestickList[index].bodyRange < candlestickList[index].topTail + candlestickList[index].deviation)
                    && (candlestickList[index].bodyRange < candlestickList[index].bottomTail + candlestickList[index].deviation))
                    && ((candlestickList[index].topTail - candlestickList[index].bottomTail < 0 + candlestickList[index].deviation)
                    && (candlestickList[index].topTail - candlestickList[index].bottomTail > 0 - candlestickList[index].deviation)))
                result = true; // set isNeutral
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets Neutral boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
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
