using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HClasses
{
    class SerializeToXML
    {
        private DataContractSerializer xmlSerializer;
        public string SerializeToXML(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    this.xmlSerializer = new DataContractSerializer(obj.GetType());
                    this.xmlSerializer.WriteObject((Stream)memoryStream, obj);
                    byte[] bytes = memoryStream.ToArray();
                    return Encoding.UTF8.GetString(bytes, 0, bytes.Length).Replace("\\", "");
                }
                catch (ArgumentNullException ex)
                {
                    this.DebugPrint("Argument exception in serialization while parsing XML " + ex.Message);
                    return (string)null;
                }
                catch (Exception ex)
                {
                    this.DebugPrint("Exception in serialization while parsing XML " + ex.Message);
                    return (string)null;
                }
            }
        }

        private void DebugPrint(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
