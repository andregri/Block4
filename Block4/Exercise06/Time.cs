using System;

namespace Exercise06
{
    public struct Time
    {
        private readonly int minutes;

        public Time(int mm)
        {
            minutes = mm;
        }

        public Time(int hh, int mm) : this(60 * hh + mm)
        { }

        public int Hour
        {
            get
            {
                return minutes / 60;
            }
        }

        public int Minute
        {
            get
            {
                return minutes % 60;
            }
        }

        public override string ToString()
        {
            return string.Format("{0:D2}:{1:D2}", Hour, Minute);
        }

        public static Time operator +(Time time1, Time time2)
        {
            int h = time1.Hour + time2.Hour;
            int m = time1.Minute + time2.Minute;
            return new Time(h, m);
        }

        public static Time operator -(Time time1, Time time2)
        {
            int h = time1.Hour - time2.Hour;
            int m = time1.Minute - time2.Minute;
            return new Time(h, m);
        }

        public static implicit operator Time(int m)
        {
            // since midnight
            return new Time(m % (24 * 60));
        }

        public static explicit operator int(Time t)
        {
            // since midnight
            return t.minutes % (24 * 60);
        }
    }
}

//Q: Try to declare a non-static field of type Time in the struct type Time. Why is this illegal?
//A: Non si può creare una Struct ricorsiva perchè le struct sono "Primitive data types",
//   pertanto sono salvate nella stack e la loro dimensione deve essere nota a priori. 
//   Infatti se dicchiarassimo all'interno della struct un membro dello stesso tipo, non 
//   potremmo mai calcolarne la dimensione nel momento in cui istanziamo la struct: alla 
//   somma della dimensione di tutti i membri dovremmo aggiungere la dimensione della 
//   struct (che però è la nostra incognita).
//
//Q: Why is it legal for a class to have a non-static field of the same type as the class?
//A: Perchè le classi sono "Reference type", cioè sono un indirizzo che punta alla locazione
//   in cui è salvato il loro contenuto. Se dichiariamo all'interno della classe, un membro 
//   dello stesso tipo della classe, possiamo calcolare senza problemi la dimensione della
//   classe: essa sarà la somma delle dimensioni di tutti i membri + la dimensione di un 
//   indirizzo.
//
//Q: Can you declare a static field noon of type Time in the struct type? Why?
//A: Sì, perchè i membri statici vengono istanziati una sola volta e sono comuni a tutte le
//   istanze della struct. Inoltre possono essere usati ancora prima di istanziare una struct.
//
//Q: Make the minutes field of struct type Time public (and not readonly) instead of private 
//   readonly. What result do you get? Why?
//A: Le struct sono "primitive" perciò quando asssegnamo una variabile (es t1) a un altra (es t2)
//   con l'operatore '=', stiamo copiando i valori. Quindi quando eseguiamo 't1.minutes = 100;'
//   stiamo modificando solo la variabile, mentre t2 rimane invariata, perchè sono variabili
//   primitive distinte (sono locazioni di memoria diverse).
//   OUTPUT: t1=01:40 and t2=09:30
//
//Q: What result do you get if you change Time to be a class instead of a struct type? Why?
//A: Le classi sono "reference type", quindi quando eseguiamo l'assegnazione tramite '=', 
//   in realtà stiamo copiando l'indirizzo di t1 in t2: addesso le due variabili puntano alle
//   stesse locazioni di memoria. pertanto quando modifichiamo i membri di un'istanza, anche 
//   l'altra sarà modificata.
//   OUTPUT: t1=01:40 and t2=01:40