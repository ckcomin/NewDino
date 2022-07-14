using Raylib_cs;

using genie;
using genie.cast;
using genie.script;
using genie.test;
using genie.services;
using genie.services.raylib;

using enemy.script;
using enemy.cast;

// using goal.script;
// using goal.cast;

namespace enemy
{
    public static class Program
    {
        public static void Test() {
            // MouseMap mouseMap = new MouseMap();
            // mouseMap.getRaylibMouse(-1);

            // CastScriptTest castScriptTest = new CastScriptTest();
            // castScriptTest.testCast();
            // castScriptTest.testScript();

            ServicesTest servicesTest = new ServicesTest();
            servicesTest.TestScreenService();

            // Director director = new Director();
            // director.DirectScene();
        }

        public static void Main(string[] args)
        {
            // A few game constants
            (int, int) W_SIZE = (500, 700);
            (int, int) START_POSITION = (500, 700);
            int SHIP_WIDTH = 40;
            int SHIP_LENGTH = 50;
            string SCREEN_TITLE = "Enemies";
            int FPS = 120;
            
            // Initiate all services
            RaylibKeyboardService keyboardService = new RaylibKeyboardService();
            RaylibPhysicsService physicsService = new RaylibPhysicsService();
            RaylibScreenService screenService = new RaylibScreenService(W_SIZE, SCREEN_TITLE, FPS);
            RaylibAudioService audioservice = new RaylibAudioService();
            RaylibMouseService mouseService = new RaylibMouseService();

            // Create the director
            Director director = new Director();

            // Create the cast
            Cast cast = new Cast();

            // Create the player
            // Ship ship = new Ship("Dino/assets/spaceship/green_dino.png", 120, 120, W_SIZE.Item1/2, W_SIZE.Item2/10 *9, 0, 0, 0);


            // Create the Start Button
            // StartGameButton startGameButton = new StartGameButton("./enemy/assets/others/start_button.png", 305, 113, W_SIZE.Item1/2, W_SIZE.Item2/2);
            // Goal goal = new Goal("Dino/assets/spaceship/spaceship_red.png", 305, 113, W_SIZE.Item1/2, W_SIZE.Item2/10 , 0, 0, 180);
            // Give actors to cast
            // cast.AddActor("ship", ship);
            // cast.AddActor("start_button", startGameButton);
            // cast.AddActor("goal", goal);
            Background backgroundImage = new Background("Dino/assets/desert-removebg-preview.png", 700, 500, W_SIZE.Item1/2, W_SIZE.Item2/2, 0, 0, 90, 0);
            cast.AddActor("background_image", backgroundImage);


            // Create the script
            Script script = new Script();

            // Add all input actions
            script.AddAction("input", new HandleQuitAction(1,screenService));
            
            // Add actions that must be added to the script when the game starts:
            // Dictionary<string, List<genie.script.Action>> startGameActions = new Dictionary<string, List<genie.script.Action>>();
            // startGameActions["input"] = new List<genie.script.Action>();
            // startGameActions["update"] = new List<genie.script.Action>();
            // startGameActions["output"] = new List<genie.script.Action>();
            script.AddAction("input", new HandleShootingAction(2, (float)0.15, (0, -10), keyboardService));
            script.AddAction("input", new HandleShipMovementAction(2, keyboardService));
            script.AddAction("input", new SpawnEnemiesAction(1, W_SIZE, (float)1.5));
            script.AddAction("input", new SpawnShip(1, W_SIZE));
            script.AddAction("input", new SpawnGoal(1, W_SIZE));


            script.AddAction("update", new HandleEnemiesDirectionAction(1, W_SIZE));

            // script.AddAction("input", new HandleStartGameAction(2, mouseService, physicsService, startGameActions));

            // Add all update actions
            script.AddAction("update", new MoveActorsAction(1, physicsService));
            script.AddAction("update", new HandleEnemiesCollison(1, physicsService));
            script.AddAction("update", new HandleGoalCollison(1, physicsService));
            // , audioservice
            script.AddAction("update", new HandleBulletsEnemyCollisionAction(1, physicsService));
            //script.AddAction("update", new HandleOffscreenAction(1, W_SIZE));

            // Add all output actions
            script.AddAction("output", new DrawActorsAction(1, screenService));
            script.AddAction("output", new UpdateScreenAction(2, screenService));

            // Yo, director, do your thing!
            director.DirectScene(cast, script);
        }
    }
}