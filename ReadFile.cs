using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Controls
{
    class ReadFile
    {
        private string ReadFile(string fileName) // fileName is the name of the text file, you would like to read
        {
            var resourceStream = Application.GetResourceStream(new Uri(fileName, UriKind.Relative)); // Get resource stream from resource file
            if (resourceStream != null)
            {
                Stream myStream = resourceStream.Stream; 
                if (myStream.CanRead)
                {
                    StreamReader streamReader = new StreamReader(myStream); // Reading data using StreamReader
                    return streamReader.ReadToEnd(); // Reading upto the end of the file using ReadToEnd() function.
                }
            }

            return "Null";
        }
    }
}
