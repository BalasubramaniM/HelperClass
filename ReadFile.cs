private string ReadFile(string fileName)
        {
            var resourceStream = Application.GetResourceStream(new Uri(fileName, UriKind.Relative));
            if (resourceStream != null)
            {
                Stream myStream = resourceStream.Stream;
                if (myStream.CanRead)
                {
                    StreamReader streamReader = new StreamReader(myStream);
                    return streamReader.ReadToEnd();
                }
            }

            return "Null";
        }
