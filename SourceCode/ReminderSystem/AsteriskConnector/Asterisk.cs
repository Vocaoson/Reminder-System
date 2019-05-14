using Ami;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteriskConnector
{
    public class Asterisk
    {
        private string asteriskIP;
        private int asteriskPort;
        private string asteriskUserName;
        private string asteriskPassword;

        public Asterisk(string asteriskIP, int asteriskPort, string asteriskUserName, string asteriskPassword)
        {
            AsteriskIP = asteriskIP;
            AsteriskPort = asteriskPort;
            AsteriskUserName = asteriskUserName;
            AsteriskPassword = asteriskPassword;
        }

        public string AsteriskIP { get => asteriskIP; set => asteriskIP = value; }
        public int AsteriskPort { get => asteriskPort; set => asteriskPort = value; }
        public string AsteriskUserName { get => asteriskUserName; set => asteriskUserName = value; }
        public string AsteriskPassword { get => asteriskPassword; set => asteriskPassword = value; }
        public async Task Login()
        {
            using (var socket = new TcpClient(hostname: asteriskIP, port: AsteriskPort))
            using (var client = new AmiClient(socket.GetStream()))
            {
                // At this point, we've completed the AMI protocol handshake and
                // a background I/O Task is consuming data from the socket.

                // Activity on the wire can be observed and logged using the
                // DataSent and DataReceived events...

                client.DataSent += (s, e) => Console.Error.Write(e.Data.GetValue(0));
                client.DataReceived += (s, e) => Console.Error.Write(e.Data.GetValue(0));

                // First, let's authenticate using the Login() helper function...

                if (!await client.Login(username: asteriskUserName, secret: asteriskPassword, md5: true))
                {
                    Console.WriteLine("Login failed");
                    return;
                }

                // In case the Asterisk server hasn't finished booting, let's wait
                // until it's ready...

                await client.Where(message => message["Event"] == "FullyBooted").FirstAsync();
            }
        }

        public async Task<bool> Logout()
        {
            using (var socket = new TcpClient(hostname: asteriskIP, port: AsteriskPort))
            using (var client = new AmiClient(socket.GetStream()))
            {

                client.DataSent += (s, e) => Console.Error.Write(e.Data.GetValue(0));
                client.DataReceived += (s, e) => Console.Error.Write(e.Data.GetValue(0));


                if (!await client.Logoff())
                {
                    Console.WriteLine("Logoff failed");
                    return false;
                }
                return true;
            }
        }
        public async Task<bool> Call(string channel, string variable)
        {
            using (var socket = new TcpClient(hostname: asteriskIP, port: AsteriskPort))
            using (var client = new AmiClient(socket.GetStream()))
            {
                // At this point, we've completed the AMI protocol handshake and
                // a background I/O Task is consuming data from the socket.

                // Activity on the wire can be observed and logged using the
                // DataSent and DataReceived events...

                client.DataSent += (s, e) => Console.Error.Write(e.Data.GetValue(0));
                client.DataReceived += (s, e) => Console.Error.Write(e.Data.GetValue(0));

                // First, let's authenticate using the Login() helper function...

                if (!await client.Login(username: asteriskUserName, secret: asteriskPassword, md5: true))
                {
                    Console.WriteLine("Login failed");
                    return false;
                }

                // In case the Asterisk server hasn't finished booting, let's wait
                // until it's ready...

                await client.Where(message => message["Event"] == "FullyBooted").FirstAsync();

                var response = await client.Publish(new AmiMessage()
            {
                    { "Action", "Originate" },
                   { "Channel", channel },
                    { "Variable", variable },
                     { "Callerid", "Call center" },
                      { "RetryTime", "10" },
                      { "Context", "test-agi" },
                       { "Exten", "1003" },
                             { "Priority", "1" },
                                   { "Archive", "yes" }

            });

                // Because we didn't specify an ActionID, one was implicitly
                // created for us by the AmiMessage object. That's how we track
                // requests and responses, allowing this client to be used
                // by multiple threads or tasks.

                if (response["Response"] == "Success")
                {
                    return true;
                    //await client
                    //   .Where(message => message["ActionID"] == response["ActionID"])
                    //   .TakeWhile(message => message["Event"] != "PeerlistComplete")
                    //   .Do(message => Console.Out.WriteLine($"~~~ \"{message["ObjectName"]}\" ({message["DeviceState"]}) ~~~"));
                }
                return false;
            }
        }
        public async Task Test()
        {
            using (var socket = new TcpClient(hostname: asteriskIP, port: AsteriskPort))
            using (var client = new AmiClient(socket.GetStream()))
            {

                var response = await client.Publish(new AmiMessage()
            {
                    { "Action", "UpdateConfig" },
                     { "reload", "chan_sip" },
                      { "srcfilename", "sip.conf" },
                       { "dstfilename", "sip.conf" },
                        { "action-000000", "newcat" },
                         { "cat-000000", "King" },
                             { "options-000000", "inherit=1004" },
                    //{ "Action", "DialplanExtensionRemove" },
                    //{ "Context", "sms-me-out" },
                    //{ "Extension", "_X" }

            });

                // Because we didn't specify an ActionID, one was implicitly
                // created for us by the AmiMessage object. That's how we track
                // requests and responses, allowing this client to be used
                // by multiple threads or tasks.

                if (response["Response"] == "Success")
                {
                    // After the PJSIPShowEndpoints command successfully executes,
                    // Asterisk will begin emitting EndpointList events.

                    // Each EndpointList event represents a single PJSIP endpoint,
                    // and has the same ActionID as the PJSIPShowEndpoints command
                    // that caused it.

                    // Once events have been emitted for all PJSIP endpoints,
                    // an EndpointListComplete event will be emitted, again with
                    // the same ActionID as the PJSIPShowEndpoints command
                    // that caused it.

                    // Using System.Reactive.Linq, all of that can be modeled with
                    // a simple Rx IObservable consumer...

                    //await client
                    //   .Where(message => message["ActionID"] == response["ActionID"])
                    //   .TakeWhile(message => message["Event"] != "PeerlistComplete")
                    //   .Do(message => Console.Out.WriteLine($"~~~ \"{message["ObjectName"]}\" ({message["DeviceState"]}) ~~~"));
                }
            }
        }
    }
}
