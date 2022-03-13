using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServisPostYapma.Model
{
    public class GelenXmlVeri
    {
		[XmlRoot(ElementName = "AddResponse", Namespace = "http://tempuri.org/")]
		public class AddResponse
		{
			[XmlElement(ElementName = "AddResult", Namespace = "http://tempuri.org/")]
			public string AddResult { get; set; }
			[XmlAttribute(AttributeName = "xmlns")]
			public string Xmlns { get; set; }
		}

		[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
		public class Body
		{
			[XmlElement(ElementName = "AddResponse", Namespace = "http://tempuri.org/")]
			public AddResponse AddResponse { get; set; }
		}

		[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
		public class Envelope
		{
			[XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
			public Body Body { get; set; }
			[XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Soap { get; set; }
			[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xsi { get; set; }
			[XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2000/xmlns/")]
			public string Xsd { get; set; }
		}
	}
}
