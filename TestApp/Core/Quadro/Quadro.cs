using System;

namespace TestApp.Core.Quadro {
    public class Quadro<T1, T2, T3, T4> {

        public Quadro(Tuple<T1, T2, T3, T4> tuple) {
            this.Item1 = tuple.Item1;
            this.Item2 = tuple.Item2;
            this.Item3 = tuple.Item3;
            this.Item4 = tuple.Item4;
        }

        public Quadro(T1 t1, T2 t2, T3 t3, T4 t4) {
            this.Item1 = t1;
            this.Item2 = t2;
            this.Item3 = t3;
            this.Item4 = t4;
        }

        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }
        public T4 Item4 { get; set; }
    }
}
