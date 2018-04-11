using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    [MessageContract(IsWrapped = true, WrapperName = "BlogRequestObject", WrapperNamespace = "http://www.MyCompany.com/Blog")]
    public class BlogRequest
    {
        [MessageHeader(Namespace = "http://www.MyCompany.com/Blog")]
        public string LicenseKey { get; set; }
        [MessageBodyMember(Namespace = "http://www.MyCompany.com/Blog")]
        public int BlogId { get; set; }
    }
    [MessageContract(IsWrapped = true, WrapperName = "BlogInfoObject", WrapperNamespace = "http://www.MyCompany.com/Blog")]
    public class BlogInfo
    {
        public BlogInfo()
        { }
        public BlogInfo(Blog blog)
        {
            this.ID = blog.ID;
            this.Name = blog.Name;
            this.URL = blog.URL;
            this.Owner = blog.Owner;
        }
        [MessageBodyMember(Order = 1, Namespace = "http://www.MyCompany.com/Blog")]
        public int ID { get; set; }
        [MessageBodyMember(Order = 2, Namespace = "http://www.MyCompany.com/Blog")]
        public string Name { get; set; }
        [MessageBodyMember(Order = 3, Namespace = "http://www.MyCompany.com/Blog")]
        public string URL { get; set; }
        [MessageBodyMember(Order = 4, Namespace = "http://www.MyCompany.com/Blog")]
        public string Owner { get; set; }
    }

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
