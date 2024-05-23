using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCSharpProject
{
    /// <summary>
    /// This class object holds all the necessary data elements to display a candlestick on a chart.
    /// </summary>
    internal class Candlestick
    {
        // internal variables
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public UInt64 volume { get; set; }
        public DateTime date { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Candlestick() { }

        /// <summary>
        /// Candlestick(string):
        /// reads in a line of stock data as a string type with 
        /// format roughly equal to "Date,Open,High,Low,Close,Adj Close,Volume".
        /// Parses that line of data and saves it into subsequent internal variables.
        /// </summary>
        /// <param name="dataRow"></param>
        public Candlestick(string dataRow) {
            char[] seperators = new char[] { ',' , ' ' , '"'}; // try all of these seperators on our line of data
            string[] subs = dataRow.Split(seperators, StringSplitOptions.RemoveEmptyEntries); // split the line into tokens
            string dateSub = subs[0];  // Get the date string
            date = DateTime.Parse(dateSub); // Parse the date into a DateTime type variable. save to object

            // Parse open, high, low, close, and volume with TryParse(). save all to object.
            double temp;
            bool success = double.TryParse(subs[1], out temp);
            if (success) open = temp;
            success = double.TryParse(subs[2], out temp);
            if(success) high = temp;
            success = double.TryParse(subs[3], out temp);
            if(success) low = temp;
            success = double.TryParse(subs[4], out temp);
            if(success) close = temp;

            // Parse volume with TryParse(). save to object.
            UInt64 vol_temp;
            success = UInt64.TryParse(subs[6], out vol_temp);
            if (success) volume = vol_temp;

        }

    }
}
