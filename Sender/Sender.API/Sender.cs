using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Sender.API.Models;

namespace Sender.API
{
    public class Sender
    {

        public void SendMessage(string doc)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.1.7" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs", type: "fanout");

                var body = Encoding.UTF8.GetBytes(doc);
                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", body);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }

        public string CreateVisitorXML(Visitor v)
        {
            // https://www.codeproject.com/Tips/671853/Data-Object-to-XML-Vice-versa-using-Csharp
            XmlDocument xmlDoc = new XmlDocument();

            XmlSerializer xmlSerializer = new XmlSerializer(v.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, v);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }



    }
}
