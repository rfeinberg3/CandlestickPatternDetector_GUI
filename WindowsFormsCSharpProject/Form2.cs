using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsCSharpProject
{
    public partial class Form2 : Form
    {
        // Binding lists to store candlesticks read from file
        List<SmartCandlestick> candlestickList = new List<SmartCandlestick>();
        BindingList<SmartCandlestick> bindingCandlestickList = new BindingList<SmartCandlestick>();


        /// <summary>
        /// Constructor
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize form with specifications from Form1's call.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="tickerName"></param>
        internal Form2(List<SmartCandlestick> list, DateTime StartDate, DateTime EndDate, string tickerName)
        {
            InitializeComponent();
            this.candlestickList = list;
            this.dateTimePicker_Start.Value = StartDate;
            this.dateTimePicker_End.Value = EndDate;
            this.Text = tickerName;
            // moved
            filterCandlesticks(); // filter the data according to date period specifications from the dateTimePickers
            PopulateComboBoxWithPatterns();
            displayCandlesticks(); // bind data, normalize, and display the chart
        }

        /// <summary>
        /// filterCandlestickList takes the current candlestickList global variable and 
        /// copys the candlesticks within the date range specified by the start and end dateTimePickers.
        /// Returns a binding list of candlesticks.
        /// </summary>
        /// <param name="candlesticks">
        /// <param type=List<Candlestick>></param>
        private BindingList<SmartCandlestick> filterCandlesticks(List<SmartCandlestick> candlesticks)
        {
            this.bindingCandlestickList.Clear(); // clear the current bindingList
            DateTime startTime = this.dateTimePicker_Start.Value; // get the start of the specified periodas a DateTime object
            DateTime endTime = this.dateTimePicker_End.Value; // get the end of teh specified period as a DateTime object

            // iterate though the candlestickList and add candlesticks to the bindingList that fit within the specified period
            for (int i = candlesticks.Count-1; i >= 0 ; i--)
            {
                if ((candlesticks[i].date >= startTime) && (candlesticks[i].date <= endTime))
                    bindingCandlestickList.Insert(0, candlesticks[i]);
            }
            return bindingCandlestickList;
        }


        /// <summary>
        /// Function to normalize the Y axis of the OHLC chart area according to the maximum high and minimum low of candlestick values for that display.
        /// </summary>
        private void normalize()
        {
            double maxHigh = double.MinValue; // represents the smallest value of a double
            double minLow = double.MaxValue; // represents the maximum value of a double

            var series = this.chart1.Series[0]; // set series to the OHLC series object
                                                // Find maximum high and minimum low of data points for OHLC
            foreach (DataPoint point in series.Points)  // iterate through all the data points in the series
            {
                maxHigh = Math.Max(maxHigh, point.YValues[1]); // find the highest candlestick value
                minLow = Math.Min(minLow, point.YValues[2]);   // find the lowest candlestick value
            }

            // Set Y axis range with 2% padding for OHLC chart area
            this.chart1.ChartAreas[0].AxisY.Maximum = maxHigh * 1.02;
            this.chart1.ChartAreas[0].AxisY.Minimum = minLow * 0.98;
        }

        /// <summary>
        /// Displays a grid view given our candlestickList, which contains all of our files candlestick data. 
        /// Also displays a candlestick chart with the date adjusted candlesticks contained in our bindingCandlestickList.
        /// 
        /// </summary>
        /// <param name="candlesticks">
        /// <param type=BindingList<SmartCandlestick>></param>
        private void displayCandlesticks(BindingList<SmartCandlestick> candlesticks)
        {
            this.chart1.DataSource = bindingCandlestickList; // tell chart what its data source is
            this.chart1.DataBind(); // bind the data and display chart
            normalize(); // normalize the Y-axis of the OHLC chart area
        }

        /// <summary>
        /// buttonUpdate_Click updates the bindingCandlestickList global variable to contain the candlesticks
        /// that fit within the current dateTimeTickers' values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click_1(object sender, EventArgs e)
        {
            filterCandlesticks();
            displayCandlesticks();
        }

        /// <summary>
        /// Reverse the dates only in the binding list of candlesticks
        /// </summary>
        /// <param name="candlesticks"></param>
        /// <returns></returns>
        private BindingList<SmartCandlestick> ReverseDates(BindingList<SmartCandlestick> candlesticks)
        {
            // Step 1: Extract the dates
            List<DateTime> dates = candlesticks.Select(c => c.date).ToList();

            // Step 2: Reverse the dates
            dates.Reverse();

            // Step 3: Reassign the reversed dates back to the candlesticks
            for (int i = 0; i < candlesticks.Count; i++)
            {
                candlesticks[i].date = dates[i];
            }
            return candlesticks;
        }

        /// <summary>
        /// Iterate through the boolean dictionary within the Smartcandlestick class,
        /// and use all the keys in this dictionary to populate the combobox.
        /// </summary>
        private void PopulateComboBoxWithPatterns()
        {
            RecognizeAll(this.candlestickList);
            List<string> patterns = new List<string>();
            string[] keysArray = new string[candlestickList[0].booleans.Count];
            candlestickList[0].booleans.Keys.CopyTo(keysArray, 0);
            foreach (var pattern in keysArray)
                comboBox_annotate.Items.Add(pattern);

        }

        /// <summary>
        /// Recognize the boolean properties of every candlestick in the list of candlesticks.
        /// And set the Smartcandlestick boolean properties to true or false based on its properties.
        /// </summary>
        /// <param name="candlesticks"></param>
        void RecognizeAll(List<SmartCandlestick> candlesticks)
        {
            Recognizer_Bullish bullish = new Recognizer_Bullish();
            Recognizer_Bearish bearish = new Recognizer_Bearish();
            Recognizer_Neutral neutral = new Recognizer_Neutral();
            Recognizer_Doji doji = new Recognizer_Doji();
            Recognizer_DragonFlyDoji dragonFlyDoji = new Recognizer_DragonFlyDoji();
            Recognizer_GravestoneDoji gravestoneDoji = new Recognizer_GravestoneDoji();
            Recognizer_Hammer hammer = new Recognizer_Hammer();
            Recognizer_Marubozu marubozu = new Recognizer_Marubozu();
            Recognizer_Multi multi = new Recognizer_Multi();
            // One-candle Patterns
            bullish.RecognizeAll(candlesticks);
            bearish.RecognizeAll(candlesticks);
            neutral.RecognizeAll(candlesticks);
            doji.RecognizeAll(candlesticks);
            dragonFlyDoji.RecognizeAll(candlesticks);
            gravestoneDoji.RecognizeAll(candlesticks);
            hammer.RecognizeAll(candlesticks);
            marubozu.RecognizeAll(candlesticks);
            // Two-candle Patterns
            bullish.RecognizeEngulfing(candlesticks);
            bullish.RecognizeHarami(candlesticks);
            bearish.RecognizeEngulfing(candlesticks);
            bearish.RecognizeHarami(candlesticks);
            // Three-candle Patterns
            multi.RecognizePeaks(candlesticks);
            multi.RecognizeValleys(candlesticks);
        }

        /// <summary>
        /// Iterate throught all the SmartCandlestick boolean members to annote the chart accordingly.
        /// </summary>
        /// <param name="index"></param>
        void annotateChart(int index)
        {
            bool annotationProperty = false;

            // iterate through all candlesticks in candlestickList
            for (int i = bindingCandlestickList.Count-1; i >= 0; i--) {
                // set annotation property (the pattern we will be looking to annotate)
                if (index == 1) annotationProperty = bindingCandlestickList[i].booleans["Bearish"];
                else if (index == 2) annotationProperty = bindingCandlestickList[i].booleans["Bullish"];
                else if (index == 3) annotationProperty = bindingCandlestickList[i].booleans["Neutral"];
                else if (index == 4) annotationProperty = bindingCandlestickList[i].booleans["Marubozu"];
                else if (index == 5) annotationProperty = bindingCandlestickList[i].booleans["Doji"];
                else if (index == 6) annotationProperty = bindingCandlestickList[i].booleans["DragonFlyDoji"];
                else if (index == 7) annotationProperty = bindingCandlestickList[i].booleans["GravestoneDoji"];
                else if (index == 8) annotationProperty = bindingCandlestickList[i].booleans["Hammer"];
                else if (index == 9) annotationProperty = bindingCandlestickList[i].booleans["BearishEngulfing"];
                else if (index == 10) annotationProperty = bindingCandlestickList[i].booleans["BearishHarami"];
                else if (index == 11) annotationProperty = bindingCandlestickList[i].booleans["BullishEngulfing"];
                else if (index == 12) annotationProperty = bindingCandlestickList[i].booleans["BullishHarami"];
                else if (index == 13) annotationProperty = bindingCandlestickList[i].booleans["Peak"];
                else if (index == 14) annotationProperty = bindingCandlestickList[i].booleans["Valley"];
                else break;

                if (index < 9)
                {
                    Annotation annotation = new ArrowAnnotation();
                    // annotation area
                    annotation.ClipToChartArea = "ChartArea_OHLC";
                    annotation.AxisX = chart1.ChartAreas["ChartArea_OHLC"].AxisX;
                    annotation.AxisY = chart1.ChartAreas["ChartArea_OHLC"].AxisY;

                    // annotation anchor
                    if (annotationProperty)
                    {
                        // get data point (the point of the candlestick we're looking to annotate)
                        DataPoint point = chart1.Series["OHLC"].Points[i];
                        annotation.AnchorDataPoint = point;
                    }
                    else
                    {
                        // if the annotation property we're looking for is false,
                        // cancel this iteration and move on to the next candle.
                        continue;
                    }
                    // annotation dimensions
                    annotation.Width = 1;
                    annotation.Height = 10;
                    annotation.LineWidth = 2;

                    // annotation alignment
                    annotation.Alignment = ContentAlignment.TopLeft;
                    annotation.AnchorOffsetY = candlestickList[i].range / 2;
                    annotation.AxisX.IsStartedFromZero = false;

                    // add annotation to chart
                    chart1.Annotations.Add(annotation);
                }
                else if (index > 9 && index <=12)
                {
                    Annotation annotation = new RectangleAnnotation();
                    annotation.BackColor = (Color.Transparent);
                    // annotation area
                    annotation.ClipToChartArea = "ChartArea_OHLC";
                    annotation.AxisX = chart1.ChartAreas["ChartArea_OHLC"].AxisX;
                    annotation.AxisY = chart1.ChartAreas["ChartArea_OHLC"].AxisY;

                    // annotation anchor
                    if (annotationProperty)
                    {
                        // get data point (the point of the candlestick we're looking to annotate)
                        DataPoint point = chart1.Series["OHLC"].Points[i];
                        annotation.AnchorDataPoint = point;
                    }
                    else
                    {
                        // if the annotation property we're looking for is false,
                        // cancel this iteration and move on to the next candle.
                        continue;
                    }
                    // annotation dimensions
                    annotation.Width = 4;
                    annotation.Height = 10;
                    annotation.LineWidth = 2;

                    // annotation alignment
                    annotation.Alignment = ContentAlignment.MiddleCenter;
                    annotation.AnchorOffsetY = -candlestickList[i].range * 2.5;
                    annotation.AnchorOffsetX = candlestickList[i].range / 3;
                    annotation.AxisX.IsStartedFromZero = false;

                    // add annotation to chart
                    chart1.Annotations.Add(annotation);
                }
                else
                {
                    Annotation annotation = new RectangleAnnotation();
                    annotation.BackColor = (Color.Transparent);
                    // annotation area
                    annotation.ClipToChartArea = "ChartArea_OHLC";
                    annotation.AxisX = chart1.ChartAreas["ChartArea_OHLC"].AxisX;
                    annotation.AxisY = chart1.ChartAreas["ChartArea_OHLC"].AxisY;

                    // annotation anchor
                    if (annotationProperty)
                    {
                        // get data point (the point of the candlestick we're looking to annotate)
                        DataPoint point = chart1.Series["OHLC"].Points[i];
                        annotation.AnchorDataPoint = point;
                    }
                    else
                    {
                        // if the annotation property we're looking for is false,
                        // cancel this iteration and move on to the next candle.
                        continue;
                    }
                    // annotation dimensions
                    annotation.Width = 6;
                    annotation.Height = 10;
                    annotation.LineWidth = 2;

                    // annotation alignment
                    annotation.Alignment = ContentAlignment.MiddleCenter;
                    annotation.AnchorOffsetY = -candlestickList[i].range * 2.5;
                    annotation.AxisX.IsStartedFromZero = false;

                    // add annotation to chart
                    chart1.Annotations.Add(annotation);
                }
            }
        }

        // Overloaded functions !!!
        private void filterCandlesticks()
        {
            filterCandlesticks(candlestickList);
        }
        private void displayCandlesticks()
        { 
            displayCandlesticks(bindingCandlestickList);
        }

        /// <summary>
        /// Activate chart annotations on combo-box index selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_annotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Annotations.Clear(); // Clear current annotations on chart
            annotateChart(comboBox_annotate.SelectedIndex);
        }
    }
}
