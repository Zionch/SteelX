using SteelX.Shared;
using System.Collections.Generic;
using SteelX.Server.Game;

namespace SteelX.Server.Packets.Lobby
{
	/// <summary>
	/// Response to a game search request
	/// </summary>
	public class GameSearched : ServerBasePacket
	{
		/// <summary>
		/// The rooms that were found
		/// </summary>
		private readonly List<GameInstance> _rooms;
		
		public GameSearched(List<GameInstance> rooms)
		{
			_rooms = rooms;
		}

		public override Shared.PacketTypes PacketType
		{
			get
			{
				return Shared.PacketTypes.LOBBY_GAME_SEARCHED;
			}
		}

		/*public override string GetType()
		{
			return "LOBBY_GAME_SEARCHED";
		}

		public override byte GetId()
		{
			return 0x2f;
		}*/

		protected override void WriteImpl()
		{
			WriteInt(_rooms.Count);

			foreach (var room in _rooms)
			{
				this.WriteRoomInfo(room);
			}
		}
	}
}