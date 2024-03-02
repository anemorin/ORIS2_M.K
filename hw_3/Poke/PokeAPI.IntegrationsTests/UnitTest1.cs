using Poke.Controllers;

namespace PokeAPI.IntegrationsTests;

[TestClass]
public class PokemonControllerTests
{
	private PokemonController _controller;
	[TestInitialize]
	public void Initialize()
	{
		_controller = new PokemonController();
	}
	
	[TestMethod] public void GetAll_WhenQueryIsNull_ReturnData()
	{
		// Arrange
		
		// Act
		
		// Assert
	}
}