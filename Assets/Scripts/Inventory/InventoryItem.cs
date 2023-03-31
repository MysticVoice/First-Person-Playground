namespace MysticVoice
{
    public class InventoryItem
    {
        public Item item;
        public int ammount;

        public InventoryItem(Item item, int ammount)
        {
            this.item = item;
            this.ammount = ammount;
        }
    }
}