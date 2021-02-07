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
        private string brokerAdress = "https://test.mosquitto.org:8883";
        private string room;
        private MqttClient client;

        public MQTTClient(string room)
        {
            this.room = room;
        }

        public string Publish(string topic)
        {
            if (topic != "")
            {
                // whole topic
                string Topic = "/"+ room + "/" + topic;

                // publish a message with QoS 2
                client.Publish(Topic, Encoding.UTF8.GetBytes(topic), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
                return "Published to " + topic;
            }
            else
            {
                return "Entered topic invalid";
            }
        }

        public string Subscribe(string topic)
        {
            if (topic != "")
            {
                // whole topic
                string Topic = "/" + room + "/" + topic;

                // subscribe to the topic with QoS 2
                client.Subscribe(new string[] { Topic }, new byte[] { 2 });   // we need arrays as parameters because we can subscribe to different topics with one call
                return "Subscribed to " + topic;
            }
            else
            {
                return "Entered topic invalid";
            }
        }

        public string Unsubscribe(string topic)
        {
            if (topic != "")
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
