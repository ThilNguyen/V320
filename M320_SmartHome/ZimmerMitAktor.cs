namespace M320_SmartHome {
    public abstract class ZimmerMitAktor : Zimmer {
        public ZimmerMitAktor(Zimmer zimmer) : base(zimmer.Name) {
           this.Zimmer = zimmer;
        }

        public override double Temperaturvorgabe { get => this.Zimmer.Temperaturvorgabe; set => this.Zimmer.Temperaturvorgabe = value; }
        public override bool PersonenImZimmer { get => this.Zimmer.PersonenImZimmer; set => this.Zimmer.PersonenImZimmer = value; }

        protected Zimmer Zimmer { get; }

        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            Zimmer.VerarbeiteWetterdaten(wetterdaten);
        }

        public T GetZimmerMitAktor<T>() where T: Zimmer {
            if(this is T) {
                return this as T;
            }
            if(this.Zimmer is ZimmerMitAktor) {
                return ((ZimmerMitAktor)this.Zimmer).GetZimmerMitAktor<T>();
            }
            return null;
        }
    }
}
