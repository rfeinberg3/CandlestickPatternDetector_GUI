using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsCSharpProject
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Initializes the chart and datagridview display sequence.
        /// If this event is called it means that a file was selected in the openFileDialog box.
        /// That file will then be read to display its stock data to a Chart object.
        /// The chart display will be within the range specifed by the start and end datTimePicker objects.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog_Stocks_FileOk(object sender, CancelEventArgs e)
        {
            getSafeFileNames();
            readFilesAndDisplay(); // read and display each selected files data to seperate form(s)

        }

        /// <summary>
        ///  Initiate a new form to display the stock data for each selected file
        /// </summary>
        /// <param name="candlestickList"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        private void createForm(List<SmartCandlestick> candlestickList, DateTime Start, DateTime End, string safeFileName)
        {
            // intitiate and show form
            Form2 showStocksForm = new Form2(candlestickList, Start, End, safeFileName);
            showStocksForm.Show();
        }

        /// <summary>
        /// Read in all the files and create a new form to display the data
        /// </summary>
        private void readFilesAndDisplay()
        {
            string[] fileList = getFilenames(); // get the names of all the files from the openFileDialog
            string[] safeFiles = getSafeFileNames();
            int i = 0;
            foreach (string file in fileList)
            {  // iterate through each file
                List<SmartCandlestick> listOfSticks = new List<SmartCandlestick>();
                listOfSticks = readStockFile(file); // read that file data to a candlestick list

                // display a form with this files candlesticks data
                createForm(listOfSticks, this.dateTimePickerStart.Value, this.dateTimePickerEnd.Value, safeFiles[i]);
                i++;
            }

        }

        /// <summary>
        /// button_FileSelect_Click initializes the show dialog sequence.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_FileSelect_Click(object sender, EventArgs e)
        {
            // Show the openFileDialog
            openFileDialogTicker.ShowDialog(this);
        }


        /// <summary>
        /// getFilename() sets the form name to the name of the current file.
        /// And returns the full path.
        /// </summary>
        /// <returns> the file path received from the openFileDialogTicker </returns>
        private string getFilename() {
            // Get path name of file selected by user
            string filename = openFileDialogTicker.FileName;
            return filename;
        }

        /// <summary>
        ///  Ge the names of all the files
        /// </summary>
        /// <returns></returns>
        private string[] getFilenames() {
            string[] listOfFiles = new string[256];
            listOfFiles = openFileDialogTicker.FileNames;
            return listOfFiles;
        }

        /// <summary>
        /// Get only the last name of each file name (safe names)
        /// </summary>
        /// <returns></returns>
        private string[] getSafeFileNames()
        {
            string[] listOfSafeFileNames = new string[256];
            listOfSafeFileNames = openFileDialogTicker.SafeFileNames;
            return listOfSafeFileNames;
        }

        /// <summary>
        /// reads the full path of a file containing stock data and returns a list of candlestick objects containing the data.
        /// </summary>
        /// <param name="filename">
        /// <param type=string</param>
        private List<SmartCandlestick> readStockFile(string filename) {
            const string headerString = "Date,Open,High,Low,Close,Adj Close,Volume"; // header string for yahoo finance stock files
            using (StreamReader readRow = new StreamReader(filename)) // open a steam reader to read the file
            {
                List<SmartCandlestick> candlestickList = new List<SmartCandlestick>();
                candlestickList.Clear(); // clear the current candlestick list 
                // Read in first line from file
                string candlestickRow = readRow.ReadLine();
                // If the header is valid read file until the end
                if (candlestickRow == headerString)
                {
                    while (!readRow.EndOfStream) // read all rows of data into candlestick list as Candlestick objects
                    {
                        candlestickRow = readRow.ReadLine(); // read next line from file
                        SmartCandlestick candlestick = new SmartCandlestick(candlestickRow); // parse and store data in Candlestick object
                        candlestickList.Add(candlestick); // add to list
                    }
                }
               // else { this.Text = "BAD FILE FORMAT ---> " + this.Text; } // if the file can't be parsed this will display on the form. (see header string for correct format of file).
                candlestickList.Reverse();
                return candlestickList;
            }
        }
        
  

        // Overloaded functions!:
        private void readStockFile() {
            string filename = getFilename();  // get the filename desired by the user from the openFileDialog
            readStockFile(filename);
        }

    }
}
