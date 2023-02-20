namespace M320_SmartHome {
    public class ZimmerMitHeizungsventil : ZimmerMitAktor {
        public ZimmerMitHeizungsventil(Zimmer zimmer) : base(zimmer) {
        }

        public bool HeizungsventilOffen { get; private set; }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur < this.Zimmer.Temperaturvorgabe) {
                // Ventil öffnen
                if(!this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geöffnet.");
                    this.HeizungsventilOffen = true;
                }
            } else {
                // Ventil schliessen
                if (this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geschlossen.");
                    this.HeizungsventilOffen = false;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
