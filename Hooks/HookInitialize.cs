using TechTalk.SpecFlow;
namespace SpecFlowTest.Hooks
{
    [Binding]
    public class HookInitialize : TestInitialize
    {
        [BeforeFeature]
        public static void testStart()
        {
            triggerSetting();
        }
        [AfterScenario]
        public void testStop()
        {

            Driver.QADriver.Close();
            Driver.QADriver.Quit();

        }
    }
}
