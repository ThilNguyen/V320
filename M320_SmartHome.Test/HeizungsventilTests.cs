using M320_SmartHome;
namespace M320_SmartHome.Test
{
    [TestClass]
    public class HeizungsventilTests
    {
        public class WettersensorMock : IWettersensor
        {
            private Wetterdaten wetterdaten;

            public WettersensorMock(Wetterdaten wetterdaten)
            {
                this.wetterdaten = wetterdaten;
            }

            public Wetterdaten LeseWetterdaten()
            {
                return this.wetterdaten;
            }
        }

        [TestMethod]
        public void TestHeizungsventilOffen()
        {
            // Arrange
            var wohnung = new Wohnung();
            var kueche = new ZimmerMitHeizungsventil(new Zimmer("Küche"));
            kueche.Temperaturvorgabe = 19;
            wohnung.ZimmerHinzufuegen(kueche);

            var wettersensor = new WettersensorMock(new Wetterdaten { Aussentemperatur = 18 });
            wohnung.Wettersensor = wettersensor;

            // Act
            wohnung.GenerateWetterdaten();

            // Assert
            Assert.IsTrue(kueche.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestHeizungsventilGeschlossen()
        {
            // Arrange
            var wohnung = new Wohnung();
            var kueche = new ZimmerMitHeizungsventil(new Zimmer("Küche"));
            kueche.Temperaturvorgabe = 20;
            wohnung.ZimmerHinzufuegen(kueche);

            var wettersensor = new WettersensorMock(new Wetterdaten { Aussentemperatur = 18 });
            wohnung.Wettersensor = wettersensor;

            // Act
            wohnung.GenerateWetterdaten();

            // Assert
            Assert.IsFalse(kueche.HeizungsventilOffen);
        }

        [TestMethod]
        public void TestHeizungsventilGeschlossenBeiGleicherTemperatur()
        {
            // Arrange
            var wohnung = new Wohnung();
            var kueche = new ZimmerMitHeizungsventil(new Zimmer("Küche"));
            kueche.Temperaturvorgabe = 19;
            wohnung.ZimmerHinzufuegen(kueche);

            var wettersensor = new WettersensorMock(new Wetterdaten { Aussentemperatur = 19 });
            wohnung.Wettersensor = wettersensor;
        }
}