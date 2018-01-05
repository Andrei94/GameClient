using System.Collections.Generic;
using System.Configuration;
using GameClient.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace GameClient.Tests
{
	[TestClass]
	public class Migration
	{
	    private readonly IMongoCollection<GameMongo> mongoCollection;

	    public Migration()
	    {
	        var dbName = ConfigurationManager.AppSettings["DBName"];
	        var collectionName = ConfigurationManager.AppSettings["Collection"];
	        var client = new MongoClient(ConfigurationManager.AppSettings["ConnectionString"]);
	        var db = client.GetDatabase(dbName);
	        mongoCollection = db.GetCollection<GameMongo>(dbName);
	        if (mongoCollection == null)
	            db.CreateCollection(dbName);
	        mongoCollection = db.GetCollection<GameMongo>(collectionName);
	    }

        [TestMethod]
		public void TimespanConversion()
		{
			Assert.AreEqual(323, Game.Game.ConvertToMinutes(0, 5, 23));
		}

		[TestMethod]
		public void WatchProcessesList()
		{
			mongoCollection.InsertMany(new List<GameMongo>
			{
				new GameMongo
				{
					Name = "Warfront Turning Point",
					ProcessName = "WarFront.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 5, 23)
				},
				new GameMongo
				{
					Name = "The Elder Scrolls: Skyrim",
					ProcessName = "SkyrimSE.exe",
					Playtime = Game.Game.ConvertToMinutes(2, 3, 10)
				},
				new GameMongo
				{
					Name = "Cities Skylines",
					ProcessName = "Cities.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 15, 30)
				},
				new GameMongo
				{
					Name = "Battlestations Pacific",
					ProcessName = "bsp.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 0, 0)
				},
				new GameMongo
				{
					Name = "Anno 1701",
					ProcessName = "Anno1701.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 1, 25)
				},
				new GameMongo
				{
					Name = "Anno 1701 The Sunken Dragon",
					ProcessName = "1701-AddOn.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 3, 20)
				},
				new GameMongo
				{
					Name = "Anno 1404",
					ProcessName = "Anno4.exe",
					Playtime = Game.Game.ConvertToMinutes(3, 10, 50)
				},
				new GameMongo
				{
					Name = "Anno 1404 Venice",
					ProcessName = "Addon.exe",
					Playtime = Game.Game.ConvertToMinutes(4, 20, 35)
				},
				new GameMongo
				{
					Name = "Anno 2070",
					ProcessName = "Anno5.exe",
					Playtime = Game.Game.ConvertToMinutes(4, 23, 10)
				},
				new GameMongo
				{
					Name = "Battlefield 1942: The Road To Rome",
					ProcessName = "BF1942.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 10, 32),
					Argument = "XPack1"
				},
				new GameMongo
				{
					Name = "Battlefield 1942: Secret Weapons of WW2",
					ProcessName = "BF1942.exe",
					Playtime = Game.Game.ConvertToMinutes(3, 22, 45),
					Argument = "XPack2"
				},
				new GameMongo
				{
					Name = "Battlefield 1942",
					ProcessName = "BF1942.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 5, 23)
				},
				new GameMongo
				{
					Name = "Battlefield: Bad Company 2",
					ProcessName = "BFBC2Game.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 2, 3)
				},
				new GameMongo
				{
					Name = "Battlefield 3",
					ProcessName = "bf3.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 20, 55)
				},
				new GameMongo
				{
					Name = "Battlefield 4",
					ProcessName = "bf4.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 14, 20)
				},
				new GameMongo
				{
					Name = "Sid Meier's Civilization V",
					ProcessName = "CivilizationV.exe",
					Playtime = Game.Game.ConvertToMinutes(10, 23, 25)
				},
				new GameMongo
				{
					Name = "Sid Meier's Civilization VI",
					ProcessName = "CivilizationVI.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 4, 25)
				},
				new GameMongo
				{
					Name = "Empire Earth",
					ProcessName = "Empire Earth.exe",
					Playtime = Game.Game.ConvertToMinutes(3, 13, 52)
				},
				new GameMongo
				{
					Name = "Empire Earth Art of Conquest",
					ProcessName = "EE-AOC.exe",
					Playtime = Game.Game.ConvertToMinutes(5, 21, 33)
				},
				new GameMongo
				{
					Name = "Empire Earth 2",
					ProcessName = "EE2.exe",
					Playtime = Game.Game.ConvertToMinutes(2, 22, 3)
				},
				new GameMongo
				{
					Name = "Empire Earth 2: The Art of Supremacy",
					ProcessName = "EE2X.exe",
					Playtime = Game.Game.ConvertToMinutes(3, 2, 43)
				},
				new GameMongo
				{
					Name = "Empires: Dawn of the Modern World",
					ProcessName = "Empires_DMW.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 12, 56)
				},
				new GameMongo
				{
					Name = "The Lord of the Rings: The Battle for Middle-Earth II",
					ProcessName = "lotrbfme2.exe",
					Playtime = Game.Game.ConvertToMinutes(3, 2, 11)
				},
				new GameMongo
				{
					Name = "The Lord of the Rings: The Battle for Middle-Earth II - The Rise of the Witch-King",
					ProcessName = "lotrbfme2ep1.exe",
					Playtime = Game.Game.ConvertToMinutes(4, 12, 24)
				},
				new GameMongo
				{
					Name = "The Lord of the Rings: Conquest",
					ProcessName = "Conquest.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 28)
				},
				new GameMongo
				{
					Name = "Wargame: European Escalation",
					ProcessName = "WarGame.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 4, 22)
				},
				new GameMongo
				{
					Name = "Wargame: AirLand Battle",
					ProcessName = "wargame2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 2, 44)
				},
				new GameMongo
				{
					Name = "Wargame: Red Dragon",
					ProcessName = "WarGame3.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 11, 23)
				},
				new GameMongo
				{
					Name = "Call of Duty",
					ProcessName = "CoDSP.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 7)
				},
				new GameMongo
				{
					Name = "Call of Duty - Multiplayer",
					ProcessName = "CoDMP.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 7)
				},
				new GameMongo
				{
					Name = "Call of Duty: United Offensive",
					ProcessName = "CoDUOSP.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 13, 22)
				},
				new GameMongo
				{
					Name = "Call of Duty: United Offensive - Multiplayer",
					ProcessName = "CoDUOMP.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 13, 22)
				},
				new GameMongo
				{
					Name = "Call of Duty: Black Ops",
					ProcessName = "BlackOps.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 19, 22)
				},
				new GameMongo
				{
					Name = "Call of Duty: Black Ops - Multiplayer",
					ProcessName = "BlackOpsMP.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 19, 22)
				},
				new GameMongo
				{
					Name = "Call of Duty: Modern Warfare 2",
					ProcessName = "iw4sp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 30)
				},
				new GameMongo
				{
					Name = "Call of Duty: Modern Warfare 2 - Multiplayer",
					ProcessName = "iw4mp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 30)
				},
				new GameMongo
				{
					Name = "Call of Duty 2 - Multiplayer",
					ProcessName = "CoD2MP_s.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 10, 58)
				},
				new GameMongo
				{
					Name = "Call of Duty 2",
					ProcessName = "CoD2SP_s.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 10, 58)
				},
				new GameMongo
				{
					Name = "Call of Duty: World at War",
					ProcessName = "CoDWaW.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 13, 44)
				},
				new GameMongo
				{
					Name = "Call of Duty: World at War - Multiplayer",
					ProcessName = "CoDWaWmp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 13, 44)
				},
				new GameMongo
				{
					Name = "Call of Duty 4: Modern Warfare",
					ProcessName = "iw3sp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 15, 21)
				},
				new GameMongo
				{
					Name = "Call of Duty 4: Modern Warfare - Multiplayer",
					ProcessName = "iw3mp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 15, 21)
				},
				new GameMongo
				{
					Name = "Call of Duty: Ghosts",
					ProcessName = "iw6sp64_ship.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 57)
				},
				new GameMongo
				{
					Name = "Call of Duty: Ghosts - Multiplayer",
					ProcessName = "iw6mp64_ship.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 57)
				},
				new GameMongo
				{
					Name = "Call of Duty: Modern Warfare 3",
					ProcessName = "iw5sp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 9, 2)
				},
				new GameMongo
				{
					Name = "Call of Duty: Modern Warfare 3 - Multiplayer",
					ProcessName = "iw5mp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 9, 2)
				},
				new GameMongo
				{
					Name = "Company of Heroes",
					ProcessName = "RelicCOH.exe",
					Playtime = Game.Game.ConvertToMinutes(2, 22, 54)
				},
				new GameMongo
				{
					Name = "Company of Heroes 2",
					ProcessName = "RelicCoH2.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 15, 22)
				},
				new GameMongo
				{
					Name = "Harry Potter and the Chamber of Secrets",
					ProcessName = "Game.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 7, 9)
				},
				new GameMongo
				{
					Name = "Harry Potter and the Order of Pheonix",
					ProcessName = "hp.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 21)
				},
				new GameMongo
				{
					Name = "Harry Potter and the Half Blood Prince",
					ProcessName = "hp6.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 23)
				},
				new GameMongo
				{
					Name = "Frontlines: Fuel of War",
					ProcessName = "FFOW.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 50)
				},
				new GameMongo
				{
					Name = "SWAT 4",
					ProcessName = "swat4.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 4, 43)
				},
				new GameMongo
				{
					Name = "SWAT 4: The Stetchkov Syndicate",
					ProcessName = "swat4x.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 4, 43)
				},
				new GameMongo
				{
					Name = "Endless Legend",
					ProcessName = "EndlessLegend.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 23, 43)
				},
				new GameMongo
				{
					Name = "Endless Space",
					ProcessName = "EndlessSpace.exe",
					Playtime = Game.Game.ConvertToMinutes(1, 1, 56)
				},
				new GameMongo
				{
					Name = "Crysis",
					ProcessName = "Crysis64.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 23, 12),
				},
				new GameMongo
				{
					Name = "Crysis: Warhead",
					ProcessName = "Crysis.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 5, 20),
				},
				new GameMongo
				{
					Name = "Crysis 2",
					ProcessName = "Crysis2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 32)
				},
				new GameMongo
				{
					Name = "Crysis 3",
					ProcessName = "Crysis3.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 3, 15)
				},
				new GameMongo
				{
					Name = "Empire: Total War",
					ProcessName = "Empire.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 21, 56)
				},
				new GameMongo
				{
					Name = "Total War: Rome II",
					ProcessName = "Rome2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 16)
				},
				new GameMongo
				{
					Name = "Total War: Warhammer",
					ProcessName = "Warhammer.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 57)
				},
				new GameMongo
				{
					Name = "Command & Conquer: Red Alert 2",
					ProcessName = "game.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 20, 2),
					Argument = "Red Alert II"
				},
				new GameMongo
				{
					Name = "Command & Conquer: Generals - Zero Hour",
					ProcessName = "generals.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 17, 35),
					Argument = "Zero Hour"
				},
				new GameMongo
				{
					Name = "Command & Conquer: Generals",
					ProcessName = "generals.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 40)
				},
				new GameMongo
				{
					Name = "Supreme Commander",
					ProcessName = "SupremeCommander.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 4, 4)
				},
				new GameMongo
				{
					Name = "Supreme Commander: Forged Alliance",
					ProcessName = "ForgedAlliance.exe",
					Playtime = Game.Game.ConvertToMinutes(2, 19, 43)
				},
				new GameMongo
				{
					Name = "Supreme Commander 2",
					ProcessName = "SupremeCommander2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 23, 48)
				},
				new GameMongo
				{
					Name = "Rise of Nations",
					ProcessName = "rise.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 2)
				},
				new GameMongo
				{
					Name = "Medal of Honor: Pacific Assault",
					ProcessName = "mohpa.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 9, 23)
				},
				new GameMongo
				{
					Name = "Medal of Honor: Allied Assault",
					ProcessName = "MOHAA.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 7, 43)
				},
				new GameMongo
				{
					Name = "Medal of Honor: Spearhead",
					ProcessName = "MOHAAS.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 45)
				},
				new GameMongo
				{
					Name = "Medal of Honor: Breakthrough",
					ProcessName = "MOHAAB.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 54)
				},
				new GameMongo
				{
					Name = "Medal of Honor: Airborne",
					ProcessName = "MOHA.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 6, 55)
				},
				new GameMongo
				{
					Name = "Ace Combat: Assault Horizon",
					ProcessName = "Ace Combat_AH.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 7, 32)
				},
				new GameMongo
				{
					Name = "Fighter Ace",
					ProcessName = "FA.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 13, 43)
				},
				new GameMongo
				{
					Name = "Euro Truck Simulator 2",
					ProcessName = "eurotrucks2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 19, 31)
				},
				new GameMongo
				{
					Name = "Mass Effect 2",
					ProcessName = "MassEffect2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 8, 13)
				},
				new GameMongo
				{
					Name = "Grand Ages: Rome",
					ProcessName = "Rome.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 0, 35)
				},
				new GameMongo
				{
					Name = "Grand Theft Auto 5",
					ProcessName = "GTA5.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 5, 34)
				},
				new GameMongo
				{
					Name = "Guitar Hero: World Tour",
					ProcessName = "GHWT.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 5, 42)
				},
				new GameMongo
				{
					Name = "Hearts of Iron III",
					ProcessName = "hoi3game.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 12, 34)
				},
				new GameMongo
				{
					Name = "Hearts of Iron IV",
					ProcessName = "hoi4.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 1, 19)
				},
				new GameMongo
				{
					Name = "Microsoft Flight Simulator",
					ProcessName = "fsx.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 0, 20)
				},
				new GameMongo
				{
					Name = "The Sims 4",
					ProcessName = "TS4.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 23, 49)
				},
				new GameMongo
				{
					Name = "The Sims 4 x64",
					ProcessName = "TS4_x64.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 23, 49)
				},
				new GameMongo
				{
					Name = "Mafia II",
					ProcessName = "Mafia2.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 17, 32)
				},
				new GameMongo
				{
					Name = "Supreme Ruler Ultimate",
					ProcessName = "SupremeRulerUltimate.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 7, 41)
				},
				new GameMongo
				{
					Name = "Supreme Ruler 1936",
					ProcessName = "SupremeRuler1936.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 16, 54)
				},
				new GameMongo
				{
					Name = "Hacknet",
					ProcessName = "Hacknet.exe",
					Playtime = Game.Game.ConvertToMinutes(0, 0, 34)
				}
			});
			Assert.AreEqual(91, mongoCollection.Count(x => true));
		}

	    [TestCleanup]
	    public void Cleanup()
	    {
	        mongoCollection.DeleteMany(doc => true);
	    }
	}
}