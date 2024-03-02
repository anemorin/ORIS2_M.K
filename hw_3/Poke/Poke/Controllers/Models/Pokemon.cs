namespace Poke.Controllers.Models;

public class Pokemon
{
	public string name { get; set; }
	public int id { get; set; }
	public int height { get; set; }
	public int weight { get; set; }
	public List<AbilityData> abilities {get;set;}
	public List<Moves> moves { get; set; }
	public List<Stats> stats { get; set; }
	public List<Types> types { get; set; }
	public Sprites sprites { get; set; }
}
public class Ability
{
	public string name { get; set; }
}

public class AbilityData
{
	public Ability ability { get; set; }
}

public class Move
{
	public string name { get; set; }
}

public class Moves
{
	public Move move { get; set; }
}
public class Stat
{
	public string name { get; set; }
}
public class Stats
{
	public Stat stat { get; set; }
	public int base_stat { get; set; }
}
public class Type
{
	public string name { get; set; }
}

public class Types
{
	public Type type { get; set; }
}
public class Other
{
	public Home home { get; set; }
}
public class Home
{
	public string front_default { get; set; }
}
public class Sprites
{
	public string front_default { get; set; }
	public Other other { get; set; }

}