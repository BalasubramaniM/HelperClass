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
    class DeserializeFromJSON
    {
        private MemoryStream memoryStream;
        private DataContractJsonSerializer jsonSerializer;

        #region DESERIALIZE FROM JSON
        public object DeserializeFromJson(object obj, string responseString) // Convert JSON to object ( Object is sender, instance of that class )
        {
            try
            {
                this.memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(responseString));
                this.jsonSerializer = new DataContractJsonSerializer(obj.GetType());
                obj = this.jsonSerializer.ReadObject((Stream)this.memoryStream);
            }
            catch (ArgumentNullException ex)
            {
                this.DebugPrint("Argument exception in Deserialization while parsing JSON " + ex.Message);
            }
            catch (Exception ex)
            {
                this.DebugPrint("Exception in Deserialization while parsing JSON " + ex.Message);
            }
            return obj;
        }
        #endregion

        private void DebugPrint(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
