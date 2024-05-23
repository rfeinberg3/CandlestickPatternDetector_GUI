using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Inherits from base Recognizer method to classify Doji candlesticks.
    /// </summary>
    internal class Recognizer_Doji : Recognizer
    {
        public string name;
        public Recognizer_Doji() : base()
        {
            name = "Doji";
        }
        /// <summary>
        /// Sets Doji boolean in Smartcandlestick Dictionary.
        /// if open - close ~= 0 is true
        /// or close - open ~= 0 is true
        /// then isDoji is set to true
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns>result</returns>
        public override bool Recognize(List<SmartCandlestick> candlestickList, int index)
        {
            bool result;
            if (((candlestickList[index].open < candlestickList[index].close + candlestickList[index].deviation / 2) && (candlestickList[index].open > candlestickList[index].close - candlestickList[index].deviation / 2))
            || ((candlestickList[index].close < candlestickList[index].open + candlestickList[index].deviation / 2) && (candlestickList[index].close > candlestickList[index].open - candlestickList[index].deviation / 2)))
                result = true;
            else result = false;
            return result;
        }
        /// <summary>
        /// Sets Doji boolean in Smartcandlestick Dictionary for all candlesticks in the candlestickList.
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
