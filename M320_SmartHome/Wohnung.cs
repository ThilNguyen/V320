namespace M320_SmartHome {
    public class Wohnung {
        private List<Zimmer> zimmerList = new List<Zimmer>();
        private IWettersensor wettersensor;

        public Wohnung(IWettersensor wettersensor) {
            // Wettersensor ggf. in einem ersten Schritt hier generieren. DAnn kann das später beim Testing für den WettersensorMock nach IoC umgebaut werden.
            this.wettersensor = wettersensor;

            this.zimmerList.Add(new ZimmerMitHeizungsventil(new BadWC()));
            this.zimmerList.Add(new ZimmerMitJalousiesteuerung(new ZimmerMitHeizungsventil(new Kueche())));
            this.zimmerList.Add(new ZimmerMitJalousiesteuerung(new ZimmerMitHeizungsventil(new Schlafen())));
            this.zimmerList.Add(new ZimmerMitJalousiesteuerung(new ZimmerMitMarkisensteuerung(new Wintergarten())));
            this.zimmerList.Add(new ZimmerMitJalousiesteuerung(new ZimmerMitHeizungsventil(new Wohnen())));
        }

        public T GetZimmer<T>(string zimmername) where T: Zimmer {
            var zimmer = this.zimmerList.FirstOrDefault(x => x.Name == zimmername);
            if(zimmer is ZimmerMitAktor) {
                return ((ZimmerMitAktor)zimmer).GetZimmerMitAktor<T>();
            }
            return zimmer as T;
        }

        public void SetTemperaturvorgabe(string zimmername, double temperaturvorgabe) {
            var zimmer = this.zimmerList.FirstOrDefault(x => x.Name == zimmername);
            if(zimmer != null) {
                zimmer.Temperaturvorgabe = temperaturvorgabe;
            }
        }

        public void SetPersonenImZimmer(string zimmername, bool personenImZimmer) {
            var zimmer = this.zimmerList.FirstOrDefault(x => x.Name == zimmername);
            if (zimmer != null) {
                zimmer.PersonenImZimmer = personenImZimmer;
            }
        }

        public void GenerateWetterdaten() {
            var wetterdaten = this.wettersensor.GetWetterdaten();

            Console.WriteLine($"\n*** Verarbeite Wetterdaten:\n    Aussentemperatur: {wetterdaten.Aussentemperatur}°C\n    Regen: {(wetterdaten.Regen ? "ja" : "nein")}\n    Windgeschwindigkeit: {wetterdaten.Windgeschwindigkeit}km/h");
            foreach(var zimmer in this.zimmerList) {
                zimmer.VerarbeiteWetterdaten(wetterdaten);
            }
        }
    }
}
