using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// Abstract class method to Recognize candlestick booleans
    /// </summary>
    internal abstract class Recognizer
    {
        string name;
        public Recognizer() {
        } // Constructor

        /// <summary>
        /// Abstract methods to be overwritten by inherited methods
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract bool Recognize(List<SmartCandlestick> candlestickList, int index);
        public abstract void RecognizeAll(List<SmartCandlestick> candlestickList);
    }
}
