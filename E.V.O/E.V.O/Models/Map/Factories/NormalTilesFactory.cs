using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map.Tiles;
using E.V.O_.Models.Map.Tiles.Decorators;
using E.V.O_.Models.Occupation;
using System.Windows;

namespace E.V.O_.Models.Map.Factories
{
    public class NormalTilesFactory : ITileFactory
{
    public Tile CreateBaseTile(Point coordinates) =>
        new BaseTile(coordinates, new NoOccupation());

    public Tile CreateCampTile(Point coordinates)
    {
        CampingSiteTile tile = new(coordinates, new Exploration(
            "Camping Site",
            1,
            new TileLootTable([
                new LootDrop(new CannedMeat(), 50, 1, 3),
                new LootDrop(new FreshWater(), 50, 1, 3),
                new LootDrop(new Book(), 10, 0, 1),
                new LootDrop(new Flashlight(), 10, 0, 1),
                new LootDrop(new FishingRod(), 10, 0, 1),
                new LootDrop(new Bandage(), 40, 1, 2),
                new LootDrop(new Sunscreen(), 10, 0, 1),
            ]),
            OccupationType.CampingSite,
            [new MutantAttack(20)]
        ));

        return tile;
    }

    public Tile CreateForestTile(Point coordinates)
    {
        ForestTile tile = new(coordinates, new Exploration(
            "Forest",
            1,
            new TileLootTable([
                new LootDrop(new Berries(), 50, 1, 3),
                new LootDrop(new Mushrooms(), 50, 1, 2),
                new LootDrop(new Axe(), 10, 0, 1)
            ]),
            OccupationType.Forest,
            [
                new BearAttack(20),
                new MutantAttack(10),
                new Poison(10)
            ]
        ));

        return tile;
    }

    public Tile CreateHuntersHutTile(Point coordinates)
    {
        HuntersHutTile tile = new(coordinates, new Exploration(
            "Hunter's Hut",
            1,
            new TileLootTable([
                new LootDrop(new Axe(), 40, 0, 1),
                new LootDrop(new CannedMeat(), 30, 1, 2),
                new LootDrop(new FreshWater(), 30, 1, 2),
                new LootDrop(new Flashlight(), 10, 0, 1),
            ]),
            OccupationType.HuntersHut,
            [
                new BearAttack(30),
                new MutantAttack(30)
            ]
        ));

        return tile;
    }

    public Tile CreateFishingDockTile(Point coordinates)
    {
        FishingDockTile tile = new(coordinates, new Exploration(
            "Fishing Dock",
            1,
            new TileLootTable([
                new LootDrop(new UnprocessedWater(), 100, 1, 3),
                new LootDrop(new Fish(), 100, 1, 3),
                new LootDrop(new FishingRod(), 10, 0, 1)
            ]),
            OccupationType.FishingDock,
            [
                new MutantAttack(10),
                new Overheating(10)
            ]
        ));

        return tile;
    }
}
}
