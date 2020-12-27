using NUnit.Framework;
using OSD600.GoodLinkOrBadLink;
using System.Net.Http;

namespace GoodLinkOrBadLink.Tests
{
    public class Tests
    {
        private readonly CLIUsage cliU = new CLIUsage();
        // private readonly CheckURL 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Version_ValidOptions_ReturnTrue()
        {
            //arrange
            string isVersionOpt_1 = "--v";
            string isVersionOpt_2 = "--version";
            string isVersionOpt_3 = "/v";

            //act
            var underTestT_1 = CLIUsage.Version(isVersionOpt_1);
            var underTestT_2 = CLIUsage.Version(isVersionOpt_2);
            var underTestT_3 = CLIUsage.Version(isVersionOpt_3);


            //assert
            Assert.IsTrue(underTestT_1);
            Assert.IsTrue(underTestT_2);
            Assert.IsTrue(underTestT_3);

        }

        [Test]
        public void Version_InvalidOptions_ReturnFalse()
        {
            //arrange
            string isNotVersion_1 = "--w";
            string isNotVersion_2 = "-v";

            //act
            var underTestF_1 = CLIUsage.Version(isNotVersion_1);
            var underTestF_2 = CLIUsage.Version(isNotVersion_2);

            //assert
            Assert.IsFalse(underTestF_1);
            Assert.IsFalse(underTestF_2);
        }

        [Test]
        public void WayBack_ValidOptions_ReturnTrue()
        {
            //arrange
            string isWayBackOption_1 = "--w";
            string isWayBackOption_2 = "--wayback";
            string isWayBackOption_3 = "/w";

            //act
            var underTestT_1 = CLIUsage.WayBack(isWayBackOption_1);
            var underTestT_2 = CLIUsage.WayBack(isWayBackOption_2);
            var underTestT_3 = CLIUsage.WayBack(isWayBackOption_3);

            //assert
            Assert.IsTrue(underTestT_1);
            Assert.IsTrue(underTestT_2);
            Assert.IsTrue(underTestT_3);
        }

        [Test]
        public void WayBack_ValidOptions_ReturnFalse()
        {
            //arrange
            string isNotWayBackOption_1 = "--v";
            string isNotWayBackOption_2 = "/j";

            //act
            var underTestF_1 = CLIUsage.WayBack(isNotWayBackOption_1);
            var underTestF_2 = CLIUsage.WayBack(isNotWayBackOption_2);

            //assert
            Assert.IsFalse(underTestF_1);
            Assert.IsFalse(underTestF_2);
        }

        [Test]
        public void isOption_ValidOptions_ReturnTrue()
        {
            //arrange
            string withDashDash = "--";
            string withSlash = "/";
            string jsonOp = "j";
            string versionOp = "v";
            string waybackOp = "w";
            string goodOp = "good";

            //act
            var dashJson = CLIUsage.isOption(withDashDash + jsonOp);
            var slashJson = CLIUsage.isOption(withSlash + jsonOp);
            var dashVersion = CLIUsage.isOption(withDashDash + versionOp);
            var dashGood = CLIUsage.isOption(withDashDash + goodOp);
            var slashWayback = CLIUsage.isOption(withSlash + waybackOp);

            //assert
            Assert.IsTrue(dashJson, "not an option");
            Assert.IsTrue(slashJson, "not an option");
            Assert.IsTrue(dashVersion, "not an option");
            Assert.IsTrue(dashGood, "not an option");
            Assert.IsTrue(slashWayback, "not an option");
        }
        [Test]
        public void isOption_ValidOptions_ReturnFalse()
        {
            //arrange
            string withSlash = "/";       
            string goodOp = "good";

            //act
            var wrongGood = CLIUsage.isOption(withSlash + goodOp);

            //assert
            Assert.IsFalse(wrongGood, "not an option");
        }        

        [Test]
        public void GetURLStatusCode_Return200()
        {
            //arrange
            var url200 = "http://google.ca";

            //act
            var underTest200 = CheckURL.GetURLStatusCode(url200);

            //arrange
            Assert.AreEqual(200, underTest200);
        }

        [Test]
        public void GetURLStatusCode_Return400(){
            //arrange
            var url400 = "https://www.jielselmani.me/blog?category=Open+Source&amp;format=rss";

            //act
            var underTest400 = CheckURL.GetURLStatusCode(url400);            

            //arrange
            Assert.AreEqual(400, underTest400);
        }

        [Test]
        public void GetURLStatusCode_Return404(){
            //arrange
            var url404 = "http://amartinencosbr600.blogspot.com/feeds/posts/default";

            //act
            var underTest404 = CheckURL.GetURLStatusCode(url404);

            //arrange
            Assert.AreEqual(404, underTest404);
        }

        [Test]
        public void GetURLStatusCode_Return0(){
            //arrange
            var urlUnknown = "http://s-aleinikov.blog.ca/feed/atom/posts/";

            //act
            var underTestUnknown = CheckURL.GetURLStatusCode(urlUnknown);

            //arrange
            Assert.AreEqual(0, underTestUnknown);
            Assert.AreNotEqual(200, underTestUnknown);
            Assert.AreNotEqual(400, underTestUnknown);
            Assert.AreNotEqual(404, underTestUnknown);
        }        
    }
}