using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO {
    public class Address {
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }

        public Address(string tinh, string huyen, string xa) {
            Tinh = tinh;
            Huyen = huyen;
            Xa = xa;
        }
    }
}
