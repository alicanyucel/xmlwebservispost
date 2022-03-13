using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebServisPostYapma.Model
{
	[XmlRoot(ElementName = "AddResponse", Namespace = "http://tempuri.org/")]
	public class AddResponse
	{
		[XmlElement(ElementName = "AddResult", Namespace = "http://tempuri.org/")]
		public string AddResult { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }		
	}
}
