using Json_Game_Data_Parser.App;

try
{
    var gameDataParser = new GameDataParser(
    new UserInteraction(
            new FileInteraction()));

    gameDataParser.run();
}
catch(Exception ex)
{
    Console.WriteLine("Sorry the app encountered a problem, its still in its early stages of production. ");
    Console.WriteLine($"{Environment.NewLine}Error Message:{Environment.NewLine }{ ex.Message}" );
}