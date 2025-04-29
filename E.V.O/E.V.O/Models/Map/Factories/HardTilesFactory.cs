using E.V.O_.Models.Loot;
using E.V.O_.Models.Map.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace E.V.O_.Models.Map.Factories
{
    public class HardTilesFactory : ITileFactory
    {
        public Tile CreateBaseTile(Point coordinates) => new BaseTile(coordinates, null, null);

        public Tile CreateCampTile(Point coordinates)
        {
            CampingSiteTile tile = new(coordinates, new()
            {
                Drops = [
                    new LootDrop(new CannedMeat(), 0.5f, 1, 3),
                    new LootDrop(new FreshWater(), 0.4f, 1, 3),
                    new LootDrop(new Book(), 0.1f, 1, 1),
                    new LootDrop(new Flashlight(), 0.1f, 1, 1),
                    new LootDrop(new FishingRod(), 0.1f, 1, 1),
                    new LootDrop(new Bandage(), 0.4f, 1, 2),
                    new LootDrop(new Sunscreen(), 0.1f, 1, 1),
                    new LootDrop(new Resource(ResourceType.Rope, 0), 0.5f, 1, 3)
                ]
            },
            [
                new DangerousEvent(HazardType.MutantAttack, 0.3f),
            ]);

            return tile;
        }

        public Tile CreateForestTile(Point coordinates)
        {
            ForestTile tile = new(coordinates, new()
            {
                Drops = [
                    new LootDrop(new Resource(ResourceType.Wood, 0), 1, 1, 3),
                    new LootDrop(new Berries(), 0.5f, 1, 3),
                    new LootDrop(new Mushrooms(), 0.5f, 1, 2),
                    new LootDrop(new Axe(), 0.1f, 1, 1),
                ]
            },
            [
                new DangerousEvent(HazardType.BearAttack, 0.3f),
                new DangerousEvent(HazardType.MutantAttack, 0.2f),
                new DangerousEvent(HazardType.Poison, 0.2f)
            ]);

            return tile;
        }

        public Tile CreateHuntersHutTile(Point coordinates)
        {
            HuntersHut tile = new(coordinates, new()
            {
                Drops = [
                    new LootDrop(new Resource(ResourceType.Wood, 0), 1, 1, 2),
                    new LootDrop(new Axe(), 0.4f, 1, 1),
                    new LootDrop(new CannedMeat(), 0.3f, 1, 2),
                    new LootDrop(new FreshWater(), 0.3f, 1, 2),
                    new LootDrop(new Flashlight(), 0.1f, 1, 1),
                    new LootDrop(new Resource(ResourceType.Rope, 0), 1, 1, 3),
                    new LootDrop(new Resource(ResourceType.Metal, 0), 1, 1, 3)
                ]
            },
            [
                new DangerousEvent(HazardType.BearAttack, 0.4f),
                new DangerousEvent(HazardType.MutantAttack, 0.4f),
            ]);

            return tile;
        }

        public Tile CreateFishingDockTile(Point coordinates)
        {
            FishingDockTile tile = new(coordinates, new()
            {
                Drops = [
                    new LootDrop(new UnprocessedWater(), 1, 1, 3),
                    new LootDrop(new Fish(), 1, 1, 3),
                    new LootDrop(new FishingRod(), 0.1f, 1, 1)
                ]
            },
            [
                new DangerousEvent(HazardType.MutantAttack, 0.2f),
                new DangerousEvent(HazardType.Overheating, 0.2f)
            ]);

            return tile;
        }
    }
}
