namespace Engine.Mediators
{
    public enum EInitializationOrder
    {
        ApplicationVersion = -3,
        SceneSwitcher = -2,
        LastGameTime = 1,

        CanvasUIProvider = 10,
        UIElementsAttacher = 11, //CanvasUIProvider dependent

        WindowsController = 20,
        PanelsController = 21,

        HealthController = 31,
        EventDuckController = 33,
        HardTutorialUiController = 34,

        QuestWindowContainer = 40,

        LevelViewController = 50,
        GameBootstrapper = 51, // LevelViewController dependent

        ShopViewBuilder = 60,
        ShopWindow = 61,

        StoryLevelContextProvider = 90,
        EventChainLevelContextProvider = 91,
        EventChestLevelContextProvider = 92,
        LevelLoader = 95,

        QuestController = 100,
        BuildingController = 101,


        LocalizationController = 999, // Last, dependent on all localized.
    }
}