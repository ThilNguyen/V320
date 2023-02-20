namespace M320_SmartHome {
    public class ZimmerMitJalousiesteuerung : ZimmerMitAktor {
        public ZimmerMitJalousiesteuerung(Zimmer zimmer) : base(zimmer) {
        }

        public bool JalousieOffen { get; private set; }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur > this.Zimmer.Temperaturvorgabe) {
                // Jalousie schliessen
                if(this.JalousieOffen) {
                    if (this.Zimmer.PersonenImZimmer) {
                        Console.WriteLine($"{this.Name}: Jalousie kann nicht geschlossen werden weil Personen im Zimmer sind.");
                    } else {
                        Console.WriteLine($"{this.Name}: Jalousie wird geschlossen.");
                    }
                }
            } else {
                // Jalousie öffnen
                if (!this.JalousieOffen) {
                    Console.WriteLine($"{this.Name}: Jalousie wird geöffnet.");
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
