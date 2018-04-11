using Core.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
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
    public class Blog : Validatable, IExtensibleDataObject
        {
            #region Variables
            int _id;
            string _name;
            string _url;
            string _owner;
            #endregion

            #region Properties
            public int ID
            {
                get
                {
                    return _id;
                }
                set { _id = value; }
            }
            public string Name
            {
                get
                {
                    return _name;
                }
                set { _name = value; }
            }
            public string URL
            {
                get
                {
                    return _url;
                }
                set { _url = value; }
            }
            public string Owner
            {
                get
                {
                    return _owner;
                }
                set { _owner = value; }
            }

            #endregion

            #region IExtensibleDataObject

            public ExtensionDataObject ExtensionData { get; set; }

            #endregion

            #region Validation
            protected override IValidator GetValidator()
            {
                return new BlogValidator();
            }
            #endregion
        }

        // Validator Class
        class BlogValidator : AbstractValidator<Blog>
        {
            public BlogValidator()
            {
                RuleFor(b => b.Name).NotEmpty();
                RuleFor(b => b.Owner).NotEmpty();
                RuleFor(b => b.ID).GreaterThan(0);
            }
        }
    }

