using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// This class object holds all the necessary data elements to display a candlestick on a chart.
    /// As well as the data elements to annotate specific candlestick patterns on the chart.
    /// </summary>
    internal class SmartCandlestick : Candlestick
    {
        /// <summary>
        /// Calculates the deviation of this smart candlestick to be used for recognizing patterns
        /// wih tolerance equal to the return of this function.
        /// </summary>
        /// <param name="openPrice"></param>
        /// <param name="highPrice"></param>
        /// <param name="lowPrice"></param>
        /// <param name="closePrice"></param>
        /// <returns></returns>
        public static double CalculateDeviation(double openPrice, double highPrice, double lowPrice, double closePrice)
        {
            double bodySize = Math.Abs(closePrice - openPrice);
            double upperWick = highPrice - Math.Max(openPrice, closePrice);
            double lowerWick = Math.Min(openPrice, closePrice) - lowPrice;

            // Example composite metric: simple sum or weighted sum
            double deviation = bodySize + upperWick + lowerWick;

            return deviation;
        }

        // range properties
        public double range; // high - low
        public double bodyRange; // |close - open|
        public double topPrice;
        public double bottomPrice;
        public double topTail;
        public double bottomTail;

        // Boolean properties dictionary
        public Dictionary<string, bool> booleans;

        // Deviation
        public double deviation;

        /// <summary>
        /// Constructor to initialize boolean dictionary keys.
        /// </summary>
        public SmartCandlestick() : base()
        {
        }
        public SmartCandlestick(string dataRow) : base(dataRow) {
            // Initialize the dictionary
            booleans = new Dictionary<string, bool>();
            this.booleans["Bearish"] = false;
            this.booleans["Bullish"] = false;
            this.booleans["Neutral"] = false;
            this.booleans["Marubozu"] = false;
            this.booleans["Doji"] = false;
            this.booleans["DragonFlyDoji"] = false;
            this.booleans["GravestoneDoji"] = false;
            this.booleans["Hammer"] = false;
            this.booleans["BearishEngulfing"] = false;
            this.booleans["BearishHarami"] = false;
            this.booleans["BullishEngulfing"] = false;
            this.booleans["BullishHarami"] = false;
            this.booleans["Peak"] = false;
            this.booleans["Valley"] = false;

            // set range properties
            range = high - low;
            bodyRange = close - open;
            if (bodyRange >= 0)
            {
                topTail = high - close;
                bottomTail = open - low;
            }
            else
            {
                topTail = high - open;
                bottomTail = close - low;
            }

            // Set Deviation
            deviation = CalculateDeviation(open, high, low, close)/2;

        }

    }
}
