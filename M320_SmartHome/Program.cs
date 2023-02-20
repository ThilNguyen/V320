namespace M320_SmartHome {
    internal class Program {
        static void Main(string[] args) {
            var wettersensor = new Wettersensor();
            var wohnung = new Wohnung(wettersensor);

            wohnung.SetTemperaturvorgabe("BadWC", 23);
            wohnung.SetTemperaturvorgabe("Kueche", 22);
            wohnung.SetTemperaturvorgabe("Schlafen", 19);
            wohnung.SetTemperaturvorgabe("Wohnen", 22);
            wohnung.SetTemperaturvorgabe("Wintergarten", 20);

            wohnung.SetPersonenImZimmer("Kueche", true);
            wohnung.SetPersonenImZimmer("Schlafen", false);
            wohnung.SetPersonenImZimmer("Wohnen", true);
            wohnung.SetPersonenImZimmer("Wintergarten", true);

            for(var i = 0; i<TimeSpan.FromHours(1).TotalMinutes; i++) {
                wohnung.GenerateWetterdaten();
            }
        }
    }
}