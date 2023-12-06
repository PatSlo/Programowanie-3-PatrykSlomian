using System.Xml.Serialization;

namespace Lista3
{
    [XmlRoot(ElementName = "Gry")]
    public class Game
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("platform")]
        public string platform { get; set; }
        [XmlAttribute("price")]
        public string price { get; set; }

        public Game()
        {

        }
        public Game(string name, string platform, string price)
        {
            this.name = name;
            this.platform = platform;
            this.price = price;
        }

        public Game(Game game)
        {
            this.name = game.name;
            this.platform = game.platform;
            this.price = game.price;
        }
    }
}
