using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HClasses
{
    class SerializeToJSON
    {
        public string SerializeToJson(object obj)
        {
            string str = string.Empty;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    new DataContractJsonSerializer(obj.GetType()).WriteObject((Stream)memoryStream, obj);
                    byte[] bytes = memoryStream.ToArray();
                    str = Encoding.UTF8.GetString(bytes, 0, bytes.Length).Replace("\\", "");
                }
                catch (ArgumentNullException ex)
                {
                    this.DebugPrint("Argument exception in serialization while parsing JSON  " + ex.Message);
                }
                catch (Exception ex)
                {
                    this.DebugPrint("Exception in serialization while parsing JSON " + ex.Message);
                }
            }
            return str;
        }
        private void DebugPrint(string value)
        {
            Debug.WriteLine(value);
        }

    }
}
