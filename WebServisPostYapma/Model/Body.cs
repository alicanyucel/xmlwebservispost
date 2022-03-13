using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServisPostYapma.Model
{

	[XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
	public class Body
	{
		[XmlElement(ElementName = "AddResponse", Namespace = "http://tempuri.org/")]
		public AddResponse AddResponse { get; set; }
	}
}
