using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teorija
{
     class Asmuo : Object, IComparable<Asmuo>, IEquatable<Asmuo>
    {
        public string Vardas { get; private set; }
        public string Pavarde { get; private set; }
        public int Amžius { get; private set; }

        public Asmuo() : base()
        {
        }
        public Asmuo(string vardas, string pavarde, int amžius) : base()
        {
            this.Vardas = vardas;
            this.Pavarde = pavarde;
            this.Amžius = amžius;
        }
        public override string ToString()
        {
            return string.Format(" vardas = {0}; pavardė = {1}; amžius = {2}",
            Vardas, Pavarde, Amžius);
        }
        public int CompareTo(Asmuo kitas)
        {
            int poz = String.Compare(this.Vardas, kitas.Vardas,
            StringComparison.CurrentCulture);
            if (poz > 0)
                return 1;
            if (poz < 0)
                return -1;
            else if (this.Amžius > kitas.Amžius) return 1;
            else if (this.Amžius < kitas.Amžius) return -1;
            else return 0;
        }
        public override bool Equals(object obj)
        {
            //Asmuo other = (Asmuo)obj;
            //return Equals(other); // Using the generic version
            // arba
            return Equals(obj as Asmuo);
        }
        public bool Equals(Asmuo kitas)
        {
            return kitas.Vardas == this.Vardas &&
            kitas.Pavarde == this.Pavarde &&
            kitas.Amžius == this.Amžius;
        }
        public static bool operator ==(Asmuo pirmas, Asmuo antras)
        {
            if (((object)pirmas) == null || ((object)antras) == null)
                return Object.Equals(pirmas, antras);
            return pirmas.Equals(antras);
        }
        public static bool operator !=(Asmuo pirmas, Asmuo antras)
        {
            if (((object)pirmas) == null || ((object)antras) == null)
                return !Object.Equals(pirmas, antras);
            return !(pirmas.Equals(antras));
            // arba
            //return !(pirmas == antras);
        }
        public override int GetHashCode()
        {
            return Vardas.GetHashCode() ^
            Pavarde.GetHashCode() ^
            Amžius.GetHashCode();
        }
       

    }
}
