using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SmartHomeControl.Clients
{
    public class MQTTClient
    {
        private string brokerAdress = "test.mosquitto.org";     //Ignore Warnings fields get initialized with object
        private string room;
        private MqttClient client;
        
        
        public MQTTClient(string room)
        {
            this.room = room;
            client = new MqttClient(brokerAdress);
        }

        public string Publish(string topic, string message)
        {
            if (!topic.Equals(""))
            {
                // whole topic
                string route = "/" + room + "/" + topic;
                // publish a message with QoS 2
                client.Publish(route, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                return "Published to " + topic;
            }
            else
            {
                return "Entered topic invalid";
            }
        }

        public string Subscribe(string topic)
        {
                string route;
                // whole topic
                if (topic.Length > 0) route = "/" + room + "/" + topic;
                else route = "/" + room + "/*";

                // subscribe to the topic with QoS 2
                client.Subscribe(new string[] { route }, new byte[] { 2 });   // we need arrays as parameters because we can subscribe to different topics with one call
                return "Subscribed to " + topic;
        }

        public string Unsubscribe(string topic)
        {
            if (!topic.Equals(""))
            {
                // whole topic
                string Topic = "/" + room + "/" + topic;

                // subscribe to the topic with QoS 2
                client.Unsubscribe(new string[] { Topic });   // we need arrays as parameters because we can subscribe to different topics with one call
                return "Unsubscribed from " + topic;
            }
            else
            {
                return "Entered topic invalid";
            }
        }
    }
}
