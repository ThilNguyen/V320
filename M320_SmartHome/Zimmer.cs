namespace M320_SmartHome {
    public abstract class Zimmer {
        public virtual double Temperaturvorgabe { get; set; }
        public virtual bool PersonenImZimmer { get; set; }
        public string Name { get; }

        public Zimmer(string name) {
            this.Name = name;
        }
        public virtual void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            Console.WriteLine($"Wetterdaten für {this.Name} verarbeitet: Temperaturvorgabe: {this.Temperaturvorgabe}°C, Personen im Zimmer: {(this.PersonenImZimmer ? "ja" : "nein")}.");
        }
    }
}
