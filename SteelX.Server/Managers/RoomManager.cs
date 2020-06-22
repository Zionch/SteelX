using System;
using System.Collections.Generic;
using System.Linq;
using Data.Model;
using GameServer.Game;
using GameServer.Util;

namespace GameServer.Managers
{
    /// <summary>
    /// This class handles rooms, user switches, etc
    /// TODO: See what needs to go into database and what can stay in memory
    /// </summary>
    public static class RoomManager
    {
        /// <summary>
        /// All current rooms
        /// </summary>
        private static readonly SortedList<int, GameInstance> Rooms = new SortedList<int, GameInstance>();

        /// <summary>
        /// Creates a new room and returns its ID
        /// </summary>
        /// <returns></returns>
        public static int CreateRoom(GameInstance room)
        {
            var id = Rooms.AddNext(room);

            room.Id = id;

            return id;
        }

        /// <summary>
        /// Deletes a room by its id
        /// TODO: Kick users back to menu?
        /// TODO: Error handling
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteRoom(int id)
        {
            Rooms.Remove(id);
        }

        /// <summary>
        /// Finds a room by its id
        /// TODO: Error handling
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GameInstance GetRoomById(int id)
        {
            return Rooms[id];
        }

        /// <summary>
        /// Gets all the rooms
        /// TODO: Filters?
        /// </summary>
        /// <returns></returns>
        public static List<GameInstance> GetRooms()
        {
            return Rooms.Values.ToList();
        }
    }
    
    
}