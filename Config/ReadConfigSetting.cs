using System.IO;
using System.Xml.XPath;
namespace SpecFlowTest.Config
{

    public class ReadConfigSetting
    {

        public static void setFrameworkSettings()
        {

            XPathItem aut;

            string strFilename = @"E:\Amit\TestSpecflow\SpecFlowTest\Config\GlobalConfig.xml";
            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("SpecflowTest/RunSettings/AUT");
            

            //Set XML Details in the property to be used accross framework
            Setting.AUT = aut.Value.ToString();



        }

    }
}
