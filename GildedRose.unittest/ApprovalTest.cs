using System;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            string dir = Assembly.GetExecutingAssembly().Location;
            dir = Path.Combine(Path.Combine(Path.Combine(Path.GetDirectoryName(dir), ".."), ".."), "..");
            string[] lines = File.ReadAllLines(dir + Path.DirectorySeparatorChar + "ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            string output = fakeoutput.ToString();

            string[] outputLines = output.Replace("\r", "").Split('\n');
            for (var i = 0; i < Math.Min(lines.Length, outputLines.Length); i++)
            {
                Assert.AreEqual(lines[i], outputLines[i]);
            }
        }
    }
}
