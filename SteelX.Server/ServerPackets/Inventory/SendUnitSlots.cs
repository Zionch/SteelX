using Data.Model;

namespace GameServer.ServerPackets.Inventory
{
    /// <summary>
    /// Send the number of unit slots this user has
    /// </summary>
    public class SendUnitSlots : ServerInventoryBasePacket
    {
        public SendUnitSlots(ExteelUser user) : base(user)
        {
        }

        public override string GetType()
        {
            return "INV_SEND_UNIT_SLOTS";
        }

        public override byte GetId()
        {
            return 0x20;
        }

        protected override void WriteImpl()
        {
            WriteUInt(Inventory.UnitSlots);
        }
    }
}