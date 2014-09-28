using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HClasses
{
    class DeserializeFromXML
    {
        private MemoryStream memoryStream;
        private DataContractJsonSerializer jsonSerializer;
        private DataContractSerializer xmlSerializer;
        public object DeserializeFromXML(object obj, string responseString)
        {
            try
            {
                this.memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
                this.xmlSerializer = new DataContractSerializer(obj.GetType());
                obj = this.jsonSerializer.ReadObject((Stream)this.memoryStream);
                return obj;
            }
            catch (ArgumentNullException ex)
            {
                this.DebugPrint("Argument exception in Deserialization while parsing XML " + ex.Message);
                return (object)null;
            }
            catch (Exception ex)
            {
                this.DebugPrint("Exception in Deserialization while parsing XML " + ex.Message);
                return (object)null;
            }
        }

        private void DebugPrint(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
