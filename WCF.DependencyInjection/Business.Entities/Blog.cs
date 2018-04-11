using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   
    [DataContract]
    public class Blog : IExtensibleDataObject
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string URL { get; set; }
        [DataMember(Order = 4)]
        public string Owner { get; set; }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
