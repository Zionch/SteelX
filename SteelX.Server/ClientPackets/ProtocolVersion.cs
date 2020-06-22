using System;
using System.Drawing;
using GameServer.ServerPackets;
using Console = Colorful.Console;

namespace GameServer.ClientPackets
{
    /// <summary>
    /// Packet when user reports their protocol version
    /// </summary>
    public class ProtocolVersion : ClientBasePacket
    {
        /// <summary>
        /// The version of protocol the client uses
        /// Currently is 333
        /// </summary>
        private readonly int _version;
        
        public ProtocolVersion(byte[] data, GameSession client) : base(data, client)
        {
            _version = GetInt();
        }

        protected override void RunImpl()
        {
            // TODO: Check version?
            
            // Set on client
            GetClient().Version = _version;
            
            // TODO: If debug
            Console.WriteLine("Client protocol is : {0}", _version, Color.DodgerBlue);
            
            // Send the client their version
            GetClient().SendPacket(new ServerVersion());
        }
        
        public override string GetType()
        {
            return "VERSION";
        }
    }
}