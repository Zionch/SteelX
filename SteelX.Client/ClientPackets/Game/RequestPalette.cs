using System;
using System.Linq;
using SteelX.Shared;
//using GameServer.ServerPackets.Game;

namespace SteelX.Client.Packets.Game
{
	/// <summary>
	/// Seems to be sent by client to request palettes for units
	/// </summary>
	/// Maybe for preloading skills?
	/// Or showing in bar?
	/// Assuming palette is skills currently
	public class RequestPalette : ClientBasePacket
	{
		/// <summary>
		/// The unit ID being requested
		/// </summary>
		private readonly uint _unitId;

		public override Shared.PacketTypes PacketType
		{
			get
			{
				return Shared.PacketTypes.GAME_REQ_PALETTE;
			}
		}

		public RequestPalette(byte[] data, GameSession client) : base(data, client)
		{
			_unitId = GetUInt();
			Console.WriteLine("User wants palette for unit {0}", _unitId);
		}

		/*public override string GetType()
		{
			return "GAME_REQ_PALETTE";
		}*/

		protected override void RunImpl()
		{
			//TODO: Not sure if this should be multicasted
			var client = GetClient();

			// I think we need to find it. Not sure what to do if it fails
			//var unit = client.GameInstance.GetUnitById(_unitId);
			
			//client.SendPacket(new PaletteList(unit));

			//Palette being color for mechs on-screen? like "color palette"?
		}
	}
}